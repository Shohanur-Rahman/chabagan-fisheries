import { Box, Button, Card, CardContent, CardHeader, Grid } from "@mui/material";
import { IconBreadcrumbs } from "../../components/common/IconBreadcrumbs";
import brandsBreadCrumb from '../../data/Breadcrumbs';
import BrandForm from "../../components/setup/BrandForm";
import DeleteForeverIcon from '@mui/icons-material/DeleteForever';
import EditIcon from '@mui/icons-material/Edit';
import { IBrandModel } from "../../interfaces/model/setup/IBrandModel";
import { useEffect, useState } from "react";
import { DataGrid, GridCellParams, GridColDef, GridToolbar } from "@mui/x-data-grid";
import { ProjectTitle, showDeleteNotification, showErrorNotification } from "../../data/Config";
import { useDeleteBrandMutation, useGetBrandMutation, useGetBrandsQuery } from "../../redux/features/setup/brandApi";
import Swal from "sweetalert2";

export default function Brands() {

    const [rows, setRows] = useState([]);
    const [initialValues, setInitialValues] = useState<IBrandModel>({} as IBrandModel);
    const { data, isSuccess } = useGetBrandsQuery(null);
    const [getBrand, { isSuccess: isSingleSuccess, data: singleData, error: singleError }] = useGetBrandMutation();
    const [deleteBrand, { isSuccess: isDeleteSuccess, data: deleteData, error: deleteError }] = useDeleteBrandMutation();


    const onEditClick = (row: GridCellParams<IBrandModel>) => {
        getBrand(row.id);
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
                deleteBrand(row.id);
            }
        });
    }

    const columns: GridColDef[] = [
        { field: 'id', headerName: 'ID', filterable: true, headerClassName: "primary-header", flex: 1 },
        {
            field: 'name',
            headerName: 'Brand',
            headerClassName: "primary-header", 
            flex: 4
        },
        {
            field: 'action', flex: 1, headerName: 'Actions', headerClassName: "primary-header",  renderCell: (params) => {
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
        if (isSuccess && data) {
            setRows(data?.result);
        }
    }, [data, isSuccess]);

    useEffect(() => {
        document.title = `Brands | ${ProjectTitle}`;
    }, []);

    useEffect(() => {
        if (singleError) {
            showErrorNotification();
        }
        else if (isSingleSuccess && singleData) {
            setInitialValues(singleData.result as IBrandModel)
        }
    }, [singleData, isSingleSuccess]);

    useEffect(() => {
        if (deleteError) {
            showErrorNotification();
        }
        else if (isDeleteSuccess && deleteData) {
            showDeleteNotification();
            setInitialValues({} as IBrandModel)
        }
    }, [deleteData, isDeleteSuccess, deleteError]);

    return (
        <>
            <IconBreadcrumbs props={brandsBreadCrumb.brandsBreadCrumb} />
            <Box mt={2}>
                <Grid container spacing={2}>
                    <Grid item xs={12} sm={12} md={4} lg={4}>
                        <BrandForm info={initialValues} setState={setInitialValues} />
                    </Grid>

                    <Grid item xs={12} sm={12} md={8}>
                        <Card sx={{ minWidth: 275 }} className="card w-100">
                            <CardHeader title="Brands" className="card-header" />
                            <CardContent className="table-content">
                                <DataGrid
                                    className="data-table small"
                                    rows={rows}
                                    columns={columns}
                                    slots={{ toolbar: GridToolbar }}
                                    slotProps={{ toolbar: { showQuickFilter: true } }}
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
                                    rowHeight={40}
                                    columnHeaderHeight={40}
                                    disableColumnMenu
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