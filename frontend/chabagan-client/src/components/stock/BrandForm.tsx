import { useFormik } from "formik";
import * as Yup from "yup";
import { Box, Button, Card, CardContent, CardHeader, FormGroup, TextField } from "@mui/material";
import { IBrandModel } from "../../interfaces/model/stock/IBrandModel";
import { useAddBrandMutation, useUpdateBrandMutation } from "../../redux/features/stock/brandApi";
import { showAddNotification, showErrorNotification, showUpdateNotification } from "../../data/Config";
import { SetStateAction, useEffect } from "react";

const BrandForm: React.FC<{ info: IBrandModel, title: String, setState: React.Dispatch<SetStateAction<IBrandModel>> }> = ({ info, title, setState }) => {

    const [addBrand, { isLoading, isError, isSuccess, data, error }] = useAddBrandMutation();
    const [updateBrand, { isLoading: isUpdateLoading, isError: isUpdateError, isSuccess: isUpdateSuccess, data: updateData, error: updateError }] = useUpdateBrandMutation();
    const emptyModel: IBrandModel = {
        id: 0,
        name: ""
    }
    const validationSchema = Yup.object({
        name: Yup.string().required('Brand name is required')
    });
    const formik = useFormik({
        initialValues: info,
        enableReinitialize: true,
        validationSchema: validationSchema,
        onSubmit: (values) => {
            if (values.id > 0) {
                updateBrand(values);
            } else {
                addBrand(values);
            }
        }
    });

    const resetFields = () => {
        formik.resetForm();
        title = "Add Brand";
        setState(emptyModel);
    }
    const getShrink = (value: any) => {
        return value ? true : false;
    }

    useEffect(() => {
        if (isSuccess && data) {
            showAddNotification();
            resetFields();
        }
        if (isError && error) {
            showErrorNotification(error);
        }
    }, [isSuccess, isError, data, error]);

    useEffect(() => {
        if (isUpdateSuccess && updateData) {
            showUpdateNotification();
            resetFields();
        }
        if (isUpdateError && updateError) {
            showErrorNotification(updateError);
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
                            id="txtBrandName"
                            label="Brand Name"
                            {...formik.getFieldProps("name")}
                            InputLabelProps={{ shrink: getShrink(formik.values.name) }}
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

export default BrandForm;