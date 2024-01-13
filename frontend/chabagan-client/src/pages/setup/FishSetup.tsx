import { Box, Button, Card, CardContent, CardHeader, FormGroup, Grid, TextField } from "@mui/material";
import { DataGrid, GridColDef, GridValueGetterParams } from '@mui/x-data-grid';
import { IconBreadcrumbs } from "../../components/common/IconBreadcrumbs";
import fishBreadCrumb from '../../data/Breadcrumbs'
import { Link } from "react-router-dom";
import { useFormik } from "formik";
import * as Yup from "yup";
import { useEffect } from "react";
import { ProjectTitle } from "../../data/Config";

const columns: GridColDef[] = [
    { field: 'id', headerName: 'ID', width: 90 },
    {
        field: 'firstName',
        headerName: 'First name',
        width: 150,
        editable: true,
    },
    {
        field: 'lastName',
        headerName: 'Last name',
        width: 150,
        editable: true,
    },
    {
        field: 'age',
        headerName: 'Age',
        type: 'number',
        width: 110,
        editable: true,
    },
    {
        field: 'fullName',
        headerName: 'Full name',
        description: 'This column has a value getter and is not sortable.',
        sortable: false,
        width: 160,
        valueGetter: (params: GridValueGetterParams) =>
            `${params.row.firstName || ''} ${params.row.lastName || ''}`,
    },
];

const rows = [
    { id: 1, lastName: 'Snow', firstName: 'Jon', age: 14 },
    { id: 2, lastName: 'Lannister', firstName: 'Cersei', age: 31 },
    { id: 3, lastName: 'Lannister', firstName: 'Jaime', age: 31 },
    { id: 4, lastName: 'Stark', firstName: 'Arya', age: 11 },
    { id: 5, lastName: 'Targaryen', firstName: 'Daenerys', age: null },
    { id: 6, lastName: 'Melisandre', firstName: null, age: 150 },
    { id: 7, lastName: 'Clifford', firstName: 'Ferrara', age: 44 },
    { id: 8, lastName: 'Frances', firstName: 'Rossini', age: 36 },
    { id: 9, lastName: 'Roxie', firstName: 'Harvey', age: 65 },
];

export default function FishSetup() {

    const formik = useFormik({
        initialValues: [],
        validationSchema: [],
        onSubmit: (values) => {

        }
    });

    useEffect(() => {
        document.title = `Fishes | ${ProjectTitle}`;
    }, []);
    return (
        <>
            <IconBreadcrumbs props={fishBreadCrumb.fishBreadCrumb} />
            <Box mt={2}>
                <Grid container spacing={2}>
                    <Grid item xs={12} sm={12} md={4} lg={4}>
                        <Card className="card w-100">
                            <CardHeader title="Add Fish" className="card-header" />
                            <CardContent>
                                <Box component="form" className="w-100 card-form" noValidate onSubmit={formik.handleSubmit}>
                                    <FormGroup>
                                        <TextField
                                            margin="normal"
                                            required
                                            fullWidth
                                            id="email"
                                            label="Email Address"
                                            autoComplete="email"
                                            autoFocus
                                        />
                                    </FormGroup>
                                    <FormGroup>
                                        <TextField
                                            margin="normal"
                                            required
                                            fullWidth
                                            type="file"
                                            id="password"
                                        />
                                    </FormGroup>
                                    <Button
                                        type="submit"
                                        fullWidth
                                        variant="contained"
                                        sx={{ mt: 3, mb: 2 }}
                                    >
                                        Save Changes
                                    </Button>
                                </Box>
                            </CardContent>
                        </Card>
                    </Grid>
                    <Grid item xs={12} sm={12} md={8}>
                        <Card sx={{ minWidth: 275 }} className="card w-100">
                            <CardHeader title="Fishes" className="card-header" />
                            <CardContent className="table-content">
                                <DataGrid
                                    className="data-table"
                                    rows={rows}
                                    columns={columns}
                                    initialState={{
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