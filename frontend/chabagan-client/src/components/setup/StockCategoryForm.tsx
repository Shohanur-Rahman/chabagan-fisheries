import { SetStateAction, useEffect, useState } from "react";
import { useFormik } from "formik";
import * as Yup from "yup";
import { IStockCatModel } from "../../interfaces/model/setup/IStockCatModel";
import { Box, Button, Card, CardContent, CardHeader, FormGroup, TextField } from "@mui/material";
import { useAddStockCategoryMutation, useUpdateStockCategoryMutation } from "../../redux/features/setup/stockCategoryApi";
import { showAddNotification, showErrorNotification, showUpdateNotification } from "../../data/Config";

const StockCategoryForm: React.FC<{
    info: IStockCatModel,
    setState: React.Dispatch<SetStateAction<IStockCatModel>>
}> = ({
    info, setState
}) => {

        const [title, setTitle] = useState("Add Category");
        const [addStockCategory, { isLoading, isError, isSuccess, data, error }] = useAddStockCategoryMutation();
        const [updateStockCategory, { isLoading: isUpdateLoading, isError: isUpdateError, isSuccess: isUpdateSuccess, data: updateData, error: updateError }] = useUpdateStockCategoryMutation();
        const emptyModel: IStockCatModel = {
            id: 0,
            name: ''
        }
        const validationSchema = Yup.object({
            name: Yup.string().required('Category name is required')
        });

        const formik = useFormik({
            initialValues: info,
            enableReinitialize: true,
            validateOnBlur: false,
            validationSchema: validationSchema,
            onSubmit: (values) => {
                if (values.id > 0) {
                    updateStockCategory(values);
                } else {
                    addStockCategory(values);
                }
            }
        });

        const resetFields = () => {
            formik.resetForm();
            setTitle("Add Category");
            setState(emptyModel);
        }

        useEffect(() => {
            if (isSuccess && data) {
                showAddNotification();
                resetFields();
            }
            if (isError && error) {
                showErrorNotification();
            }
        }, [isSuccess, isError, data, error]);

        useEffect(() => {
            if (isUpdateSuccess && updateData) {
                showUpdateNotification();
                resetFields();
            }
            if (isUpdateError && updateError) {
                showErrorNotification();
            }
        }, [isUpdateSuccess, isUpdateError, updateData, updateError]);

        const getShrink = (value: any) => {
            return value ? true : false;
        }
        useEffect(() => {
            if (info && info.id > 0) {
                setTitle("Edit Category");
            }else{
                setState(emptyModel);
            }
        }, [info]);
        return (
            <Card className="card w-100">
                <CardHeader title={title} className="card-header" />
                <CardContent>
                    <Box component="form" className="w-100 card-form" onSubmit={formik.handleSubmit}>
                        <FormGroup>
                            <TextField
                                margin="normal"
                                fullWidth
                                label="Category Name"
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

export default StockCategoryForm;