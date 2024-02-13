import { Box, Button, Grid } from "@mui/material";
import { IconBreadcrumbs } from "../../components/common/IconBreadcrumbs";
import categoryBreadCrumb from '../../data/Breadcrumbs';
import StockCategoryForm from "../../components/setup/StockCategoryForm";
import DeleteForeverIcon from '@mui/icons-material/DeleteForever';
import EditIcon from '@mui/icons-material/Edit';
import { useEffect, useState } from "react";
import { IStockCatModel } from "../../interfaces/model/setup/IStockCatModel";
import Swal from "sweetalert2";
import { GridCellParams, GridColDef } from "@mui/x-data-grid";
import { useDeleteStockCategoryMutation, useGetStockCategoryByIdMutation, useGetStockCategoryQuery } from "../../redux/features/setup/stockCategoryApi";
import { ProjectTitle, showDeleteNotification, showErrorNotification } from "../../data/Config";
import LoadDataGrid from "../../components/common/LoadDataGrid";
export default function StockCategory() {
    const [initialValues, setInitialValues] = useState<IStockCatModel>({} as IStockCatModel);
    const [rows, setRows] = useState([]);
    const { data, isSuccess } = useGetStockCategoryQuery(null);
    const [getStockCategoryById, { isSuccess: isSingleSuccess, data: singleData, error: singleError }] = useGetStockCategoryByIdMutation();
    const [deleteStockCategory, { isSuccess: isDeleteSuccess, data: deleteData, error: deleteError }] = useDeleteStockCategoryMutation();

    const onEditClick = (row: GridCellParams<IStockCatModel>) => {
        getStockCategoryById(row.id);
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
                deleteStockCategory(row.id);
            }
        });
    }
    const columns: GridColDef[] = [
        { field: 'id', headerName: 'ID', flex: 1, filterable: true, headerClassName: "primary-header" },
        {
            field: 'name',
            headerName: 'Category',
            headerClassName: "primary-header",
            flex: 4
        },
        {
            field: 'action', headerName: 'Actions', flex: 1, headerClassName: "primary-header", renderCell: (params) => {
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
        document.title = `Categories | ${ProjectTitle}`;
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
            setInitialValues(singleData.result as IStockCatModel)
        }
    }, [singleData, isSingleSuccess]);

    useEffect(() => {
        if (deleteError) {
            showErrorNotification();
        }
        else if (isDeleteSuccess && deleteData) {
            showDeleteNotification();
            setInitialValues({} as IStockCatModel)
        }
    }, [deleteData, isDeleteSuccess, deleteError]);

    return (
        <>
            <IconBreadcrumbs props={categoryBreadCrumb.categoryBreadCrumb} />
            <Box mt={2}>
                <Grid container spacing={2}>
                    <Grid item xs={12} sm={12} md={4} lg={4}>
                        <StockCategoryForm info={initialValues} setState={setInitialValues} />
                    </Grid>
                    <Grid item xs={12} sm={12} md={8}>
                        <LoadDataGrid title="Categories" rows={rows} columns={columns} />
                    </Grid>
                </Grid>
            </Box>
        </>
    )
}