import { SetStateAction, useEffect } from "react";
import { ISupplierModel } from "../../interfaces/model/setup/ISupplierModel";
import { useFormik } from "formik";
import * as Yup from "yup";
import { Box, Button, Card, CardContent, CardHeader, FormGroup, TextField } from "@mui/material";
import { useAddSupplierMutation, useUpdateSupplierMutation } from "../../redux/features/setup/supplierApi";
import { showAddNotification, showErrorNotification, showUpdateNotification } from "../../data/Config";

const SupplierForm: React.FC<{
    info: ISupplierModel,
    title: String,
    setState: React.Dispatch<SetStateAction<ISupplierModel>>
}> = ({ info, title, setState }) => {


    const [addSupplier, { isLoading, isError, isSuccess, data, error }] = useAddSupplierMutation();
    const [updateSupplier, { isLoading: isUpdateLoading, isError: isUpdateError, isSuccess: isUpdateSuccess, data: updateData, error: updateError }] = useUpdateSupplierMutation();
    const emptyModel: ISupplierModel = {
        id: 0,
        name: "",
        shopName: "",
        mobile: ""
    }
    const validationSchema = Yup.object({
        name: Yup.string().required('Supplier name is required'),
        shopName: Yup.string().required('Shop name is required'),
        mobile: Yup.string().required('Mobile is required')
    });

    const formik = useFormik({
        initialValues: info,
        enableReinitialize: true,
        validationSchema: validationSchema,
        onSubmit: (values) => {
            if (values.id > 0) {
                updateSupplier(values);
            } else {
                addSupplier(values);
            }
        }
    });

    const resetFields = () => {
        formik.resetForm();
        title = "Add Supplier";
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
                            label="Supplier Name"
                            {...formik.getFieldProps("name")}
                            InputLabelProps={{ shrink: getShrink(formik.values.name) }}
                        />
                        {formik.touched.name && formik.errors.name ? (
                            <p className="validation-error text-danger">{formik.errors.name}</p>
                        ) : null}
                    </FormGroup>

                    <FormGroup>
                        <TextField
                            margin="normal"
                            required
                            fullWidth
                            label="Shop Name"
                            {...formik.getFieldProps("shopName")}
                            InputLabelProps={{ shrink: getShrink(formik.values.shopName) }}
                        />
                        {formik.touched.shopName && formik.errors.shopName ? (
                            <p className="validation-error text-danger">{formik.errors.shopName}</p>
                        ) : null}
                    </FormGroup>

                    <FormGroup>
                        <TextField
                            margin="normal"
                            required
                            fullWidth
                            label="Mobile"
                            {...formik.getFieldProps("mobile")}
                            InputLabelProps={{ shrink: getShrink(formik.values.mobile) }}
                        />
                        {formik.touched.mobile && formik.errors.mobile ? (
                            <p className="validation-error text-danger">{formik.errors.mobile}</p>
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

export default SupplierForm;