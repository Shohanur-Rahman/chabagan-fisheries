import { useFormik } from "formik";
import * as Yup from "yup";
import { IProductModel } from "../../interfaces/model/setup/IProductModel"
import { ChangeEvent, SetStateAction, useEffect, useState } from "react";
import { Box, Button, Card, CardContent, CardHeader, FormGroup, InputLabel, MenuItem, Select, TextField } from "@mui/material";
import { useAddProductMutation, useUpdateProductMutation } from "../../redux/features/setup/productApi";
import { FileURL, showAddNotification, showErrorNotification, showUpdateNotification } from "../../data/Config";
import { useGetStockCategoryQuery } from "../../redux/features/setup/stockCategoryApi";
import { IStockCatModel } from "../../interfaces/model/setup/IStockCatModel";
import noImage from './../../assets/img/no-image-found.png';

const ProductForm: React.FC<
    {
        info: IProductModel,
        setState: React.Dispatch<SetStateAction<IProductModel>>
    }> = ({ info, setState }) => {

        const [attachment, setAttachment] = useState<any>(null);
        const [preview, setPreview] = useState<string | ArrayBuffer | null>((info.id > 0 && info.avatar) ? `${FileURL}${info.avatar}` : noImage);
        const [addProduct, { isLoading, isError, isSuccess, data, error }] = useAddProductMutation();
        const [updateProduct, { isLoading: isUpdateLoading, isError: isUpdateError, isSuccess: isUpdateSuccess, data: updateData, error: updateError }] = useUpdateProductMutation();
        const { data: categories, isSuccess: isCategorySuccess } = useGetStockCategoryQuery(null);
        const [formTitle, setFormTitle] = useState((info.id > 0) ? `Edit Product` : `Add Product`);

        const emptyModel: IProductModel = {
            id: 0,
            name: '',
            categoryId: 0,
            description: '',
            mrp: 0,
            avatar: '',
            attachment: null
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
                const submitData: Record<string, any> = {
                    id: values.id ?? 0,
                    name: values.name,
                    categoryId: values.categoryId,
                    description: values.description,
                    mrp: values.mrp,
                    attachment: attachment,
                    avatar: values.avatar
                };

                const formData = new FormData();
                for (const key in submitData) {
                    formData.append(key, submitData[key]);
                }

                if (values.id > 0) {
                    updateProduct(formData);
                } else {
                    addProduct(formData);
                }
            }
        });

        const handleFileChange = (event: ChangeEvent<HTMLInputElement>) => {
            const file = event.target.files && event.target.files[0];

            if (file) {
                setAttachment(file);
                const reader = new FileReader();

                reader.onloadend = () => {
                    setPreview(reader.result);
                };

                reader.readAsDataURL(file);
            }
        };

        const resetFields = () => {
            formik.resetForm();
            setFormTitle("Add Product");
            setState(emptyModel);
        }
        const getShrink = (value: any) => {
            return value ? true : false;
        }
        useEffect(() => {
            setPreview((info.id > 0 && info.avatar) ? `${FileURL}${info.avatar}` : noImage);
            setFormTitle((info.id > 0) ? `Edit Product` : `Add Product`);
        }, [info]);

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
                <CardHeader title={formTitle} className="card-header" />
                <CardContent>
                    <Box component="form" className="w-100 card-form" noValidate onSubmit={formik.handleSubmit}>
                        <FormGroup className="d-none">
                            <TextField
                                type="hidden"
                                size="small"
                                margin="normal"
                                required
                                fullWidth
                                {...formik.getFieldProps("avatar")}
                                className="d-none"
                            />
                        </FormGroup>
                        <FormGroup>
                            <TextField
                                size="small"
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
                                size="small"
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
                            <InputLabel id="category-label">Category</InputLabel>
                            <Select
                                size="small"
                                labelId="category-label"
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
                                size="small"
                                margin="normal"
                                fullWidth
                                id="txtDescription"
                                label="Description"
                                multiline
                                rows={3}
                                {...formik.getFieldProps("description")}
                                InputLabelProps={{ shrink: getShrink(formik.values.description) }}
                            />
                        </FormGroup>
                        <FormGroup className="img-preview">
                            <input type="file" className="d-none" id="fileProductImage" onChange={handleFileChange} />
                            <label htmlFor="fileProductImage" className="preview-label">
                                <img src={preview as string} alt="File Preview" className="img-prev-elem" />
                            </label>
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