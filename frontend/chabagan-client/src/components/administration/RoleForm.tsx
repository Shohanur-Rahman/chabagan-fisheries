import { Box, Button, Card, CardContent, CardHeader, FormGroup, TextField } from "@mui/material";
import { useAddRoleMutation, useUpdateRoleMutation } from "../../redux/features/administration/rolesApi";
import { useFormik } from "formik";
import * as Yup from "yup";
import { IRoleModel } from "../../interfaces/model/user/IRoleModel";
import { useEffect } from "react";
import { showAddNotification, showErrorNotification, showUpdateNotification } from "../../data/Config";



const RoleForm: React.FC<{ props: IRoleModel, title: String }> = ({ props, title }) => {

    // api handle using rtk query
    const [addRole, { isLoading, isError, isSuccess, data, error }] = useAddRoleMutation();
    const [updateRole, { isLoading: isUpdateLoading, isError: isUpdateError, isSuccess: isUpdateSuccess, data: updateData, error: updateError }] = useUpdateRoleMutation();
    const validationSchema = Yup.object({
        name: Yup.string().required('Role name is required')
    });

    const resetFields = () => {
        formik.resetForm();
        title = "Add Role";
        props.id = 0;
        props.name = "";
    }

    const formik = useFormik({
        initialValues: props,
        validationSchema: validationSchema,
        onSubmit: (values) => {
            if (values.id > 0) {
                updateRole(values);
            } else {
                addRole(values);
            }
        }
    });


    useEffect(() => {
        if (isSuccess && data) {
            resetFields();
            showAddNotification();
        }
        if (isError && error) {
            alert("Something went wrong. Please try again");
        }
    }, [isSuccess, isError, data, error]);


    useEffect(() => {
        if (isUpdateSuccess && updateData) {
            resetFields();
            showUpdateNotification();
        }
        if (isUpdateError && updateError) {
            showErrorNotification();
        }
    }, [isUpdateSuccess, isUpdateError, updateData, updateError]);

    return (
        <Card className="card w-100">
            <CardHeader title={title} className="card-header" />
            <CardContent>
                <Box component="form" className="w-100 card-form" noValidate onSubmit={formik.handleSubmit}>
                    <FormGroup>
                        <TextField
                            margin="normal"
                            required
                            fullWidth
                            id="txtRoleName"
                            label="Role Name"
                            {...formik.getFieldProps("name")}
                            autoComplete="role"
                            autoFocus
                        />
                        {formik.touched.name && formik.errors.name ? (
                            <p className="validation-error text-danger">{formik.errors.name}</p>
                        ) : null}
                    </FormGroup>
                    <Button
                        type="submit"
                        fullWidth
                        variant="contained"
                        sx={{ mt: 3, mb: 2 }}
                        disabled={(isLoading || isUpdateLoading)}
                    >
                        {(isLoading || isUpdateLoading) ? <span>Processing...</span> : "Save Changes"}
                    </Button>
                </Box>
            </CardContent>
        </Card>
    )
}

export default RoleForm;