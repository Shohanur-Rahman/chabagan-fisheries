import { Box, Button, Card, CardContent, CardHeader, Grid } from "@mui/material";
import { IconBreadcrumbs } from "../../components/common/IconBreadcrumbs";
import productBreadCrumb from '../../data/Breadcrumbs';
import { useEffect, useState } from "react";
import DeleteForeverIcon from '@mui/icons-material/DeleteForever';
import EditIcon from '@mui/icons-material/Edit';
import { IProductModel } from "../../interfaces/model/stock/IProductModel";
import ProductForm from "../../components/stock/ProductForm";
import { DataGrid, GridCellParams, GridColDef } from "@mui/x-data-grid";
import Swal from "sweetalert2";
import { useGetProductsQuery } from "../../redux/features/stock/productApi";
import { ProjectTitle } from "../../data/Config";
export default function Product() {
    const [rows, setRows] = useState([]);
    const [formTitle, setFormTitle] = useState("Add Product");
    const [initialValues, setInitialValues] = useState<IProductModel>({} as IProductModel);
    const { data, isSuccess } = useGetProductsQuery(null);

    const onEditClick = (row: GridCellParams<IProductModel>) => {
        console.log(row.id);
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
                console.log(row.id);
            }
        });
    }
    const columns: GridColDef[] = [
        { field: 'id', headerName: 'ID', width: 90, filterable: true },
        {
            field: 'name',
            headerName: 'Name',
            width: 300
        },
        {
            field: 'mrp',
            headerName: 'Price',
            width: 200
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
            setFormTitle("Add Product");
        }
    }, [data, isSuccess]);

    return (
        <>
            <IconBreadcrumbs props={productBreadCrumb.productBreadCrumb} />
            <Box mt={2}>
                <Grid container spacing={2}>
                    <Grid item xs={12} sm={12} md={4} lg={4}>
                        <ProductForm info={initialValues} setState={setInitialValues} title={formTitle} />
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