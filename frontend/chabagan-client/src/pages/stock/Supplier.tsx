import { useEffect, useState } from "react";
import { IconBreadcrumbs } from "../../components/common/IconBreadcrumbs";
import supplierBreadCrumb from '../../data/Breadcrumbs';
import DeleteForeverIcon from '@mui/icons-material/DeleteForever';
import EditIcon from '@mui/icons-material/Edit';
import { ISupplierModel } from "../../interfaces/model/stock/ISupplierModel";
import Swal from "sweetalert2";
import { useDeleteSupplierMutation, useGetSupplierMutation, useGetSuppliersQuery } from "../../redux/features/stock/supplierApi";
import { DataGrid, GridCellParams, GridColDef } from "@mui/x-data-grid";
import { Box, Button, Card, CardContent, CardHeader, Grid } from "@mui/material";
import { ProjectTitle, showDeleteNotification, showErrorNotification } from "../../data/Config";
import SupplierForm from "../../components/stock/SupplierForm";
export default function Supplier() {
    const [formTitle, setFormTitle] = useState("Add Supplier");
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
        { field: 'id', headerName: 'ID', width: 90, filterable: true },
        {
            field: 'name',
            headerName: 'Brand',
            width: 200
        },
        {
            field: 'shopName',
            headerName: 'Shop',
            width: 250
        },
        {
            field: 'mobile',
            headerName: 'Mobile',
            width: 150
        },
        {
            field: 'action', headerName: 'Actions', width: 100, renderCell: (params) => {
                return (
                    <>
                        <Button
                            className="grid-btn"
                            onClick={() => onEditClick(params.row)}
                            variant="contained"
                        >
                            <EditIcon />
                        </Button>
                        <Button
                            className="grid-btn"
                            onClick={() => onDeleteClickEvent(params.row)}
                            variant="contained"
                            color="error"
                        >
                            <DeleteForeverIcon />
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
            setFormTitle("Add Supplier");
        }
    }, [data, isSuccess]);

    useEffect(() => {
        if (singleError) {
            showErrorNotification();
        }
        else if (isSingleSuccess && singleData) {
            setFormTitle("Edit Supplier");
            setInitialValues(singleData.result as ISupplierModel)
        }
    }, [singleData, isSingleSuccess]);

    useEffect(() => {
        if (deleteError) {
            showErrorNotification();
        }
        else if (isDeleteSuccess && deleteData) {
            showDeleteNotification();
            setFormTitle("Add Supplier");
            setInitialValues({} as ISupplierModel)
        }
    }, [deleteData, isDeleteSuccess, deleteError]);

    return (
        <>
            <IconBreadcrumbs props={supplierBreadCrumb.supplierBreadCrumb} />

            <Box mt={2}>
                <Grid container spacing={2}>
                    <Grid item xs={12} sm={12} md={4} lg={4}>
                        <SupplierForm info={initialValues} title={formTitle} setState={setInitialValues} />
                    </Grid>

                    <Grid item xs={12} sm={12} md={8}>
                        <Card sx={{ minWidth: 275 }} className="card w-100">
                            <CardHeader title="Suppliers" className="card-header" />
                            <CardContent className="table-content">
                                <DataGrid
                                    className="data-table"
                                    rows={rows}
                                    columns={columns}
                                    initialState={{
                                        filter: {
                                            filterModel: {
                                                items: [],
                                                quickFilterExcludeHiddenColumns: true,
                                            },
                                        },
                                        pagination: {
                                            paginationModel: {
                                                pageSize: 5,
                                            },
                                        },
                                    }}
                                    pageSizeOptions={[5]}
                                    disableRowSelectionOnClick
                                />
                            </CardContent>
                        </Card>
                    </Grid>
                </Grid>
            </Box>

        </>
    )
}