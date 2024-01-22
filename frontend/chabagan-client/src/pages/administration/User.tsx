import { useEffect, useState } from "react";
import DeleteForeverIcon from '@mui/icons-material/DeleteForever';
import EditIcon from '@mui/icons-material/Edit';
import PersonAddIcon from '@mui/icons-material/PersonAdd';
import { IconBreadcrumbs } from "../../components/common/IconBreadcrumbs";
import userBreadCrumb from '../../data/Breadcrumbs';
import { ProjectTitle, showDeleteNotification, showErrorNotification } from "../../data/Config";
import { DataGrid, GridCellParams, GridColDef } from "@mui/x-data-grid";
import { Button, Card, CardContent, CardHeader, Grid } from "@mui/material";
import { useNavigate } from "react-router-dom";
import { useDeleteUserMutation, useGetUsersQuery } from "../../redux/features/administration/userApi";
import Swal from "sweetalert2";


export default function User() {
    const { data, isSuccess } = useGetUsersQuery(null);
    const navigate = useNavigate();
    const [rows, setRows] = useState([]);
    const [deleteUser, { isSuccess: isDeleteSuccess, data: deleteData, error: deleteError }] = useDeleteUserMutation();


    const columns: GridColDef[] = [
        { field: 'id', headerName: 'ID', width: 90 },
        {
            field: 'name',
            headerName: 'Name',
            width: 260
        },
        {
            field: 'email',
            headerName: 'Email',
            width: 250
        },
        {
            field: 'mobile',
            headerName: 'Mobile',
            width: 200
        },
        {
            field: 'role.name',
            headerName: 'Role',
            width: 200,
        },
        {
            field: 'action', headerName: 'Actions', width: 100, renderCell: (params) => {
                return (
                    <>
                        <Button
                            className="grid-btn"
                            onClick={() => onEditClickEvent(params.row)}
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


    const onEditClickEvent = (row: GridCellParams) => {
        navigate(`/admin/users/edit-user/${row.id}`);
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
                deleteUser(row.id);
            }
        });
    }

    const handleAddClick = () => {
        navigate('/admin/users/add-user');
    }
    useEffect(() => {
        document.title = `Users | ${ProjectTitle}`;
    }, []);


    useEffect(() => {
        if (deleteError) {
            showErrorNotification();
        }
        else if (isDeleteSuccess && deleteData) {
            showDeleteNotification();
        }
    }, [deleteData, isDeleteSuccess, deleteError]);

    useEffect(() => {
        if (isSuccess && data) {
            console.log(data)
            setRows(data?.result);
        }
    }, [data, isSuccess]);

    return (
        <>
            <IconBreadcrumbs props={userBreadCrumb.userBreadCrumb} />
            <Grid item xs={12} sm={12} md={12} mt={2} className="d-block">
                <Button variant="contained" className="pull-right" onClick={handleAddClick}><PersonAddIcon /> &nbsp; Add User</Button>
            </Grid>

            <Grid item xs={12} sm={12} md={12} mt={2}>
                <Card sx={{ minWidth: 275 }} className="card w-100">
                    <CardHeader title="Users" className="card-header" />
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
        </>
    )
}