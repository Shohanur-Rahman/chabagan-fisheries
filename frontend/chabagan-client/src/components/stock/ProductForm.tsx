import { useFormik } from "formik";
import * as Yup from "yup";
import { IProductModel } from "../../interfaces/model/stock/IProductModel"
import { SetStateAction } from "react";
import { Box, Button, Card, CardContent, CardHeader, FormGroup, TextField } from "@mui/material";

const ProductForm: React.FC<
    {
        info: IProductModel,
        title: String,
        setState: React.Dispatch<SetStateAction<IProductModel>>
    }> = ({ info, title, setState }) => {

        const emptyModel: IProductModel = {
            id: 0,
            name: '',
            categoryId: 0,
            description: '',
            mrp: 0.00
        }

        const validationSchema = Yup.object({
            name: Yup.string().required('Product name is required'),
            mrp: Yup.number().min(1).required('Price is required')
        });
        const formik = useFormik({
            initialValues: info,
            enableReinitialize: true,
            validationSchema: validationSchema,
            onSubmit: (values) => {
                console.log(values);
            }
        });

        const resetFields = () => {
            formik.resetForm();
            title = "Add Product";
            setState(emptyModel);
        }

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
                            />
                            {formik.touched.mrp && formik.errors.mrp ? (
                                <p className="validation-error text-danger">{formik.errors.mrp}</p>
                            ) : null}
                        </FormGroup>
                        <FormGroup>
                            <TextField
                                margin="normal"
                                required
                                fullWidth
                                id="txtDescription"
                                label="Description"
                                multiline
                                rows={4}
                                {...formik.getFieldProps("description")}
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
        )
    }

export default ProductForm;