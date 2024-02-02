import { useFormik } from "formik";
import * as Yup from "yup";
import { Box, Button, Card, CardContent, CardHeader, FormGroup, TextField } from "@mui/material";
import { FileURL, showAddNotification, showErrorNotification, showUpdateNotification } from "../../data/Config";
import { ChangeEvent, SetStateAction, useEffect, useState } from "react";
import { IProjectModel } from "../../interfaces/model/setup/IProjectModel";
import { useAddProjectMutation, useUpdateProjectMutation } from "../../redux/features/setup/projectApi";
import noImage from './../../assets/img/no-image-found.png';

const ProjectForm: React.FC<{ info: IProjectModel, setState: React.Dispatch<SetStateAction<IProjectModel>> }> = ({ info, setState }) => {

    const [attachment, setAttachment] = useState<any>(null);
    const [preview, setPreview] = useState<string | ArrayBuffer | null>((info.id > 0 && info.avatar) ? `${FileURL}${info.avatar}` : noImage);
    const [addProject, { isLoading, isError, isSuccess, data, error }] = useAddProjectMutation();
    const [updateProject, { isLoading: isUpdateLoading, isError: isUpdateError, isSuccess: isUpdateSuccess, data: updateData, error: updateError }] = useUpdateProjectMutation();
    const [formTitle, setFormTitle] = useState((info.id > 0) ? `Edit Project` : `Add Project`);

    const emptyModel: IProjectModel = {
        id: 0,
        name: '',
        union: '',
        wordNumber: '',
        avatar: '',
        attachment: null
    }
    const validationSchema = Yup.object({
        name: Yup.string().required('Project name is required'),
        union: Yup.string().required('Union is required'),
        wordNumber: Yup.string().required('Word number is required'),
    });
    const formik = useFormik({
        initialValues: info,
        enableReinitialize: true,
        validationSchema: validationSchema,
        onSubmit: (values) => {

            const submitData: Record<string, any> = {
                id: values.id ?? 0,
                name: values.name,
                union: values.union,
                wordNumber: values.wordNumber,
                attachment: attachment,
                avatar: values.avatar
            };

            const formData = new FormData();
            for (const key in submitData) {
                formData.append(key, submitData[key]);
            }

            if (values.id > 0) {
                updateProject(formData);
            } else {
                addProject(formData);
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
        setFormTitle("Add Project");
        setState(emptyModel);
    }
    const getShrink = (value: any) => {
        return value ? true : false;
    }

    useEffect(() => {
        setPreview((info.id > 0 && info.avatar) ? `${FileURL}${info.avatar}` : noImage);
        setFormTitle((info.id > 0) ? `Edit Project` : `Add Project`);

        if (!info || !info.id) {
            setState(emptyModel);
        }

    }, [info]);

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
                    <FormGroup>
                        <TextField
                            margin="normal"
                            required
                            fullWidth
                            label="Project Name"
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
                            label="Union"
                            {...formik.getFieldProps("union")}
                            InputLabelProps={{ shrink: getShrink(formik.values.union) }}
                        />
                        {formik.touched.union && formik.errors.union ? (
                            <p className="validation-error text-danger">{formik.errors.union}</p>
                        ) : null}
                    </FormGroup>

                    <FormGroup>
                        <TextField
                            type="number"
                            margin="normal"
                            required
                            fullWidth
                            label="Word"
                            {...formik.getFieldProps("wordNumber")}
                            InputLabelProps={{ shrink: getShrink(formik.values.wordNumber) }}
                        />
                        {formik.touched.wordNumber && formik.errors.wordNumber ? (
                            <p className="validation-error text-danger">{formik.errors.wordNumber}</p>
                        ) : null}
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

export default ProjectForm;