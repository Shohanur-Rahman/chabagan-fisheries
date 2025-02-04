import { useEffect, useState } from "react"; import DeleteForeverIcon from '@mui/icons-material/DeleteForever';
import EditIcon from '@mui/icons-material/Edit';
import { IconBreadcrumbs } from "../../components/common/IconBreadcrumbs";
import projectBreadCrumb from '../../data/Breadcrumbs';
import { IProjectModel } from "../../interfaces/model/setup/IProjectModel";
import { useDeleteProjectMutation, useGetProjectMutation, useGetProjectsQuery } from "../../redux/features/setup/projectApi";
import { Box, Button, Grid } from "@mui/material";
import ProjectForm from "../../components/setup/ProjectForm";
import { GridCellParams, GridColDef } from "@mui/x-data-grid";
import { FileURL, ProjectTitle, showDeleteNotification, showErrorNotification } from "../../data/Config";
import Swal from "sweetalert2";
import noImage from './../../assets/img/no-image-found.png';
import LoadDataGrid from "../../components/common/LoadDataGrid";

export default function Project() {

    const [rows, setRows] = useState([]);
    const [initialValues, setInitialValues] = useState<IProjectModel>({} as IProjectModel);
    const { data, isSuccess } = useGetProjectsQuery(null);

    const [getProject, { isSuccess: isSingleSuccess, data: singleData, error: singleError }] = useGetProjectMutation();
    const [deleteProject, { isSuccess: isDeleteSuccess, data: deleteData, error: deleteError }] = useDeleteProjectMutation();

    const onEditClick = (row: GridCellParams<IProjectModel>) => {
        getProject(row.id);
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
                deleteProject(row.id);
            }
        });
    }
    const columns: GridColDef[] = [
        { field: 'id', headerName: 'ID', flex: 1, filterable: true, headerClassName: "primary-header" },
        {
            field: 'avatar', headerName: '', flex: 1, headerClassName: "primary-header", renderCell: (params) => {
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
            flex: 4,
            headerClassName: "primary-header"
        },
        {
            field: 'union',
            headerName: 'Union',
            flex: 3,
            headerClassName: "primary-header"
        },
        {
            field: 'wordNumber',
            headerName: 'Word',
            flex: 2,
            headerClassName: "primary-header"
        },
        {
            field: 'action', headerName: 'Actions',
            headerClassName: "primary-header", flex: 2, renderCell: (params) => {
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
        document.title = `Projects | ${ProjectTitle}`;
    }, []);

    useEffect(() => {
        if (isSuccess && data) {
            setRows(data?.result);
        }
    }, [data, isSuccess]);

    useEffect(() => {
        if (singleError) {
            showErrorNotification(deleteError);
        }
        else if (isSingleSuccess && singleData) {
            setInitialValues(singleData.result as IProjectModel || {})
        }
    }, [singleData, isSingleSuccess]);

    useEffect(() => {
        if (deleteError) {
            showErrorNotification(deleteError);
        }
        else if (isDeleteSuccess && deleteData) {
            showDeleteNotification();
            setInitialValues({} as IProjectModel || {})
        }
    }, [deleteData, isDeleteSuccess, deleteError]);

    return (
        <>
            <IconBreadcrumbs props={projectBreadCrumb.projectBreadCrumb} />
            <Box mt={2}>
                <Grid container spacing={2}>
                    <Grid item xs={12} sm={12} md={4} lg={4}>
                        <ProjectForm info={initialValues} setState={setInitialValues} />
                    </Grid>
                    <Grid item xs={12} sm={12} md={8}>
                        <LoadDataGrid title="Projects" rows={rows} columns={columns} />
                    </Grid>
                </Grid>
            </Box>
        </>
    )
}