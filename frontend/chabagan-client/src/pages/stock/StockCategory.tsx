import { Box, Button, Card, CardContent, CardHeader, Grid } from "@mui/material";
import { IconBreadcrumbs } from "../../components/common/IconBreadcrumbs";
import categoryBreadCrumb from '../../data/Breadcrumbs';
import StockCategoryForm from "../../components/stock/StockCategoryForm";
import DeleteForeverIcon from '@mui/icons-material/DeleteForever';
import EditIcon from '@mui/icons-material/Edit';
import { useEffect, useState } from "react";
import { IStockCatModel } from "../../interfaces/model/stock/IStockCatModel";
import Swal from "sweetalert2";
import { DataGrid, GridCellParams, GridColDef } from "@mui/x-data-grid";
import { useDeleteStockCategoryMutation, useGetStockCategoryByIdMutation, useGetStockCategoryQuery } from "../../redux/features/stock/stockCategoryApi";
import { ProjectTitle, showDeleteNotification, showErrorNotification } from "../../data/Config";
export default function StockCategory() {
    const [formTitle, setFormTitle] = useState("Add Category");
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
        { field: 'id', headerName: 'ID', width: 90, filterable: true },
        {
            field: 'name',
            headerName: 'Category',
            width: 500
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
        document.title = `Categories | ${ProjectTitle}`;
    }, []);

    useEffect(() => {
        if (isSuccess && data) {
            setRows(data?.result);
            setFormTitle("Add Category");
        }
    }, [data, isSuccess]);

    useEffect(() => {
        if (singleError) {
            showErrorNotification();
        }
        else if (isSingleSuccess && singleData) {
            setFormTitle("Edit Category");
            setInitialValues(singleData.result as IStockCatModel)
        }
    }, [singleData, isSingleSuccess]);

    useEffect(() => {
        if (deleteError) {
            showErrorNotification();
        }
        else if (isDeleteSuccess && deleteData) {
            showDeleteNotification();
            setFormTitle("Add Brand");
            setInitialValues({} as IStockCatModel)
        }
    }, [deleteData, isDeleteSuccess, deleteError]);

    return (
        <>
            <IconBreadcrumbs props={categoryBreadCrumb.categoryBreadCrumb} />
            <Box mt={2}>
                <Grid container spacing={2}>
                    <Grid item xs={12} sm={12} md={4} lg={4}>
                        <StockCategoryForm info={initialValues} title={formTitle} setState={setInitialValues} />
                    </Grid>
                    <Grid item xs={12} sm={12} md={8}>
                        <Card sx={{ minWidth: 275 }} className="card w-100">
                            <CardHeader title="Categories" className="card-header" />
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