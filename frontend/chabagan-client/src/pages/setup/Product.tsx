import { Box, Button, Card, CardContent, CardHeader, Grid } from "@mui/material";
import { IconBreadcrumbs } from "../../components/common/IconBreadcrumbs";
import productBreadCrumb from '../../data/Breadcrumbs';
import { useEffect, useState } from "react";
import DeleteForeverIcon from '@mui/icons-material/DeleteForever';
import EditIcon from '@mui/icons-material/Edit';
import { IProductModel } from "../../interfaces/model/setup/IProductModel";
import ProductForm from "../../components/setup/ProductForm";
import { DataGrid, GridCellParams, GridColDef } from "@mui/x-data-grid";
import Swal from "sweetalert2";
import noImage from './../../assets/img/no-image-found.png';
import { useDeleteProductMutation, useGetProductMutation, useGetProductsQuery } from "../../redux/features/setup/productApi";
import { FileURL, ProjectTitle, showDeleteNotification, showErrorNotification } from "../../data/Config";
export default function Product() {
    const [rows, setRows] = useState([]);
    const [initialValues, setInitialValues] = useState<IProductModel>({} as IProductModel);
    const { data, isSuccess } = useGetProductsQuery(null);
    const [getProduct, { isSuccess: isSingleSuccess, data: singleData, error: singleError }] = useGetProductMutation();
    const [deleteProduct, { isSuccess: isDeleteSuccess, data: deleteData, error: deleteError }] = useDeleteProductMutation();

    const onEditClick = (row: GridCellParams<IProductModel>) => {
        getProduct(row.id);
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
                deleteProduct(row.id);
            }
        });
    }
    const columns: GridColDef[] = [
        { field: 'id', headerName: 'ID', width: 40, filterable: true },
        {
            field: 'avatar', headerName: '', width: 60, renderCell: (params) => {
                if (params.row?.avatar) {
                    return (
                        <img src={`${FileURL}${params.row?.avatar}`} alt="File Preview" className="grid-photo" />
                    )
                } else {
                    return (
                        <img src={noImage} alt="File Preview" className="grid-photo" />
                    )
                }

            }
        },
        {
            field: 'name',
            headerName: 'Name',
            width: 200
        },
        {
            field: 'mrp',
            headerName: 'Price',
            width: 150
        },
        {
            field: 'category', headerName: 'Category', width: 200, renderCell: (params) => {
                return (
                    <>
                        {params.row?.category?.name}
                    </>
                );
            }
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
        document.title = `Products | ${ProjectTitle}`;
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
            setInitialValues(singleData.result as IProductModel || {})
        }
    }, [singleData, isSingleSuccess]);

    useEffect(() => {
        if (deleteError) {
            showErrorNotification();
        }
        else if (isDeleteSuccess && deleteData) {
            showDeleteNotification();
            setInitialValues({} as IProductModel || {})
        }
    }, [deleteData, isDeleteSuccess, deleteError]);

    return (
        <>
            <IconBreadcrumbs props={productBreadCrumb.productBreadCrumb} />
            <Box mt={2}>
                <Grid container spacing={2}>
                    <Grid item xs={12} sm={12} md={4} lg={4}>
                        <ProductForm info={initialValues} setState={setInitialValues}/>
                    </Grid>
                    <Grid item xs={12} sm={12} md={8}>
                        <Card sx={{ minWidth: 275 }} className="card w-100">
                            <CardHeader title="Products" className="card-header" />
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
                                                pageSize: 10,
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