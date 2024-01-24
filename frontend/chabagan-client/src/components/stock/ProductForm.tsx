import { useFormik } from "formik";
import * as Yup from "yup";
import { IProductModel } from "../../interfaces/model/stock/IProductModel"
import { SetStateAction, useEffect } from "react";
import { Box, Button, Card, CardContent, CardHeader, FormGroup, InputLabel, MenuItem, Select, TextField } from "@mui/material";
import { useAddProductMutation, useUpdateProductMutation } from "../../redux/features/stock/productApi";
import { showAddNotification, showErrorNotification, showUpdateNotification } from "../../data/Config";
import { useGetStockCategoryQuery } from "../../redux/features/stock/stockCategoryApi";
import { IStockCatModel } from "../../interfaces/model/stock/IStockCatModel";


const ProductForm: React.FC<
    {
        info: IProductModel,
        title: String,
        setState: React.Dispatch<SetStateAction<IProductModel>>
    }> = ({ info, title, setState }) => {

        const [addProduct, { isLoading, isError, isSuccess, data, error }] = useAddProductMutation();
        const [updateProduct, { isLoading: isUpdateLoading, isError: isUpdateError, isSuccess: isUpdateSuccess, data: updateData, error: updateError }] = useUpdateProductMutation();
        const { data: categories, isSuccess: isCategorySuccess } = useGetStockCategoryQuery(null);

        const emptyModel: IProductModel = {
            id: 0,
            name: '',
            categoryId: 0,
            description: '',
            mrp: 0.00
        }

        const validationSchema = Yup.object({
            name: Yup.string().required('Product name is required'),
            mrp: Yup.number().min(1).required('Price is required'),
            categoryId: Yup.number().min(1).required('Category is required'),
        });
        const formik = useFormik({
            initialValues: info,
            enableReinitialize: true,
            validationSchema: validationSchema,
            onSubmit: (values) => {
                console.log(values)
                if (values.id > 0) {
                    updateProduct(values);
                } else {
                    addProduct(values);
                }
            }
        });

        const resetFields = () => {
            formik.resetForm();
            title = "Add Product";
            setState(emptyModel);
        }
        const getShrink = (value: any) => {
            return value ? true : false;
        }

        useEffect(() => {
            if (isCategorySuccess && categories) {
                if (categories?.result) {
                }
            }
        }, [categories, isCategorySuccess]);

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
                                id="txtProductName"
                                label="Product Name"
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
                                id="txtPrice"
                                label="Price"
                                type="number"
                                {...formik.getFieldProps("mrp")}
                                InputLabelProps={{ shrink: getShrink(formik.values.mrp) }}
                            />
                            {formik.touched.mrp && formik.errors.mrp ? (
                                <p className="validation-error text-danger">{formik.errors.mrp}</p>
                            ) : null}
                        </FormGroup>
                        <FormGroup>
                            <InputLabel id="role-label">Category</InputLabel>
                            <Select
                                labelId="role-label"
                                id="ddlCategory"
                                {...formik.getFieldProps("categoryId")}
                                label="Role"
                                value={formik.values.categoryId || ''}
                                placeholder="--Please Select --"
                            >
                                <MenuItem value={0} selected={true}>--Please Select --</MenuItem>
                                {categories?.result.map((item: IStockCatModel, index: number) => {
                                    return (<MenuItem value={item.id} key={index}>{item.name}</MenuItem>)
                                })}
                            </Select>
                            {formik.touched.categoryId && formik.errors.categoryId ? (
                                <p className="validation-error text-danger">{formik.errors.categoryId}</p>
                            ) : null}
                        </FormGroup>
                        <FormGroup>
                            <TextField
                                margin="normal"
                                fullWidth
                                id="txtDescription"
                                label="Description"
                                multiline
                                rows={4}
                                {...formik.getFieldProps("description")}
                                InputLabelProps={{ shrink: getShrink(formik.values.description) }}
                            />
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

export default ProductForm;