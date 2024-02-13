import { useEffect, useState } from "react";
import { IconBreadcrumbs } from "../../components/common/IconBreadcrumbs";
import supplierBreadCrumb from '../../data/Breadcrumbs';
import DeleteForeverIcon from '@mui/icons-material/DeleteForever';
import EditIcon from '@mui/icons-material/Edit';
import { ISupplierModel } from "../../interfaces/model/setup/ISupplierModel";
import Swal from "sweetalert2";
import { useDeleteSupplierMutation, useGetSupplierMutation, useGetSuppliersQuery } from "../../redux/features/setup/supplierApi";
import { GridCellParams, GridColDef } from "@mui/x-data-grid";
import { Box, Button, Grid } from "@mui/material";
import { ProjectTitle, showDeleteNotification, showErrorNotification } from "../../data/Config";
import SupplierForm from "../../components/setup/SupplierForm";
import LoadDataGrid from "../../components/common/LoadDataGrid";
export default function Supplier() {

    const [rows, setRows] = useState([]);
    const [initialValues, setInitialValues] = useState<ISupplierModel>({} as ISupplierModel);
    const { data, isSuccess } = useGetSuppliersQuery(null);
    const [getSupplier, { isSuccess: isSingleSuccess, data: singleData, error: singleError }] = useGetSupplierMutation();
    const [deleteSupplier, { isSuccess: isDeleteSuccess, data: deleteData, error: deleteError }] = useDeleteSupplierMutation();

    const onEditClick = (row: GridCellParams<ISupplierModel>) => {
        getSupplier(row.id);
    }

    const onDeleteClickEvent = (row: GridCellParams) => {
        Swal.fire({
            title: "Are you sure?",
            text: "You won't be able to revert this!",
            icon: "warning",
            showCancelButton: true,
            confirmButtonColor: "#d33",
            cancelButtonColor: "#3085d6",
            confirmButtonText: "Yes, delete it!"
        }).then((result) => {
            if (result.isConfirmed) {
                deleteSupplier(row.id);
            }
        });
    }


    const columns: GridColDef[] = [
        { field: 'id', flex: 1, headerName: 'ID', headerClassName: "primary-header", filterable: true },
        {
            field: 'name',
            headerName: 'Brand',
            headerClassName: "primary-header",
            flex: 4
        },
        {
            field: 'shopName',
            headerName: 'Shop',
            headerClassName: "primary-header",
            flex: 4
        },
        {
            field: 'mobile',
            headerName: 'Mobile',
            headerClassName: "primary-header",
            flex: 2
        },
        {
            field: 'action', flex: 2, headerName: 'Actions', headerClassName: "primary-header", renderCell: (params) => {
                return (
                    <>
                        <Button
                            className="grid-btn"
                            onClick={() => onEditClick(params.row)}
                            variant="contained"
                        >
                            <EditIcon className="f-16" />
                        </Button>
                        <Button
                            className="grid-btn"
                            onClick={() => onDeleteClickEvent(params.row)}
                            variant="contained"
                            color="error"
                        >
                            <DeleteForeverIcon className="f-16" />
                        </Button>
                    </>
                );
            }
        }
    ];


    useEffect(() => {
        document.title = `Suppliers | ${ProjectTitle}`;
    }, []);

    useEffect(() => {
        if (isSuccess && data) {
            setRows(data?.result);
        }
    }, [data, isSuccess]);

    useEffect(() => {
        if (singleError) {
            showErrorNotification();
        }
        else if (isSingleSuccess && singleData) {
            setInitialValues(singleData.result as ISupplierModel)
        }
    }, [singleData, isSingleSuccess]);

    useEffect(() => {
        if (deleteError) {
            showErrorNotification();
        }
        else if (isDeleteSuccess && deleteData) {
            showDeleteNotification();
            setInitialValues({} as ISupplierModel)
        }
    }, [deleteData, isDeleteSuccess, deleteError]);

    return (
        <>
            <IconBreadcrumbs props={supplierBreadCrumb.supplierBreadCrumb} />

            <Box mt={2}>
                <Grid container spacing={2}>
                    <Grid item xs={12} sm={12} md={4} lg={4}>
                        <SupplierForm info={initialValues} setState={setInitialValues} />
                    </Grid>

                    <Grid item xs={12} sm={12} md={8}>
                        <LoadDataGrid title="Suppliers" rows={rows} columns={columns} />
                    </Grid>
                </Grid>
            </Box>

        </>
    )
}