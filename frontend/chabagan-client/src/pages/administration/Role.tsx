import { Box, Button, Card, CardContent, CardHeader, Grid } from "@mui/material";
import DeleteForeverIcon from '@mui/icons-material/DeleteForever';
import EditIcon from '@mui/icons-material/Edit';
import { IconBreadcrumbs } from "../../components/common/IconBreadcrumbs";
import { IRoleModel } from "../../interfaces/model/user/IRoleModel";
import roleBreadCrumb from '../../data/Breadcrumbs';
import RoleForm from "../../components/administration/RoleForm";
import { DataGrid, GridCellParams, GridColDef } from '@mui/x-data-grid';
import { useEffect, useState } from "react";
import { ProjectTitle, showDeleteNotification, showErrorNotification } from "../../data/Config";
import { useDeleteRoleMutation, useGetRoleMutation, useGetRolesQuery } from "../../redux/features/administration/rolesApi";
import Swal from 'sweetalert2'

const initialValues: IRoleModel = {
    id: 0,
    name: ""
}

export default function Role() {

    const { data, isSuccess } = useGetRolesQuery(null);
    const [deleteRole, { isSuccess: isDeleteSuccess, data: deleteData, error: deleteError }] = useDeleteRoleMutation();
    const [getRole, { isSuccess: isRoleSuccess, data: roleData, error: roleError }] = useGetRoleMutation();
    const [rows, setRows] = useState([]);
    const [formTitle, setFormTitle] = useState("Add Role");

    const onButtonClick = (row: GridCellParams) => {
        getRole(row.id);
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
                deleteRole(row.id);
            }
        });
    }

    const columns: GridColDef[] = [
        { field: 'id', headerName: 'ID', width: 90, filterable: true },
        {
            field: 'name',
            headerName: 'Role',
            width: 500
        },
        {
            field: 'action', headerName: 'Actions', width: 100, renderCell: (params) => {
                return (
                    <>
                        <Button
                            className="grid-btn"
                            onClick={() => onButtonClick(params.row)}
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
        if (isSuccess && data) {
            setRows(data?.result);
            setFormTitle("Add Role");
        }
    }, [data, isSuccess]);

    useEffect(() => {
        if (roleError) {
            showErrorNotification();
        }
        else if (isRoleSuccess && roleData) {
            setFormTitle("Edit Role");
            initialValues.id = roleData.result.id;
            initialValues.name = roleData.result.name;
        }
    }, [roleData, isRoleSuccess]);

    useEffect(() => {
        if (deleteError) {
            showErrorNotification();
        }
        else if (isDeleteSuccess && deleteData) {
            showDeleteNotification();
            setFormTitle("Add Role");
        }
    }, [deleteData, isDeleteSuccess, deleteError]);

    useEffect(() => {
        document.title = `Roles | ${ProjectTitle}`;
    }, []);

    return (
        <>
            <IconBreadcrumbs props={roleBreadCrumb.roleBreadCrumb} />
            <Box mt={2}>
                <Grid container spacing={2}>
                    <Grid item xs={12} sm={12} md={4} lg={4}>
                        <RoleForm props={initialValues} title={formTitle} />
                    </Grid>
                    <Grid item xs={12} sm={12} md={8}>
                        <Card sx={{ minWidth: 275 }} className="card w-100">
                            <CardHeader title="Roles" className="card-header" />
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