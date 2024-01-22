import { ChangeEvent, useEffect, useState } from "react";
import { useFormik } from "formik";
import * as Yup from "yup";
import DoneAllIcon from '@mui/icons-material/DoneAll';
import KeyboardDoubleArrowLeftIcon from '@mui/icons-material/KeyboardDoubleArrowLeft';
import { IconBreadcrumbs } from "../../components/common/IconBreadcrumbs";
import userAddBreadCrumb from '../../data/Breadcrumbs';
import { ProjectTitle, showAddNotification, showErrorNotification } from "../../data/Config";
import { Box, Button, Card, CardContent, CardHeader, FormGroup, Grid, InputLabel, MenuItem, Select, TextField } from "@mui/material";
import { IUserModel } from "../../interfaces/model/user/IUserModel";
import { useGetRolesQuery } from "../../redux/features/administration/rolesApi";
import { IRoleModel } from "../../interfaces/model/user/IRoleModel";
import { useNavigate, useParams } from "react-router-dom";
import { useAddUserMutation, useGetUserQuery } from "../../redux/features/administration/userApi";


const initialValues: IUserModel = {
    id: 0,
    name: "",
    email: "",
    mobile: "",
    roleId: 0,
    password: "",
    confirmPassword: "",
    attachment: null,
    address: ""
}

export default function AddEditUser() {
    const { id } = useParams();
    const [pageTitle, setPageTitle] = useState("Add User");
    const { data: roles, isSuccess } = useGetRolesQuery(null);
    const { data: users, isSuccess: isUserSuccess } = useGetUserQuery(id);
    const [attachment, setUserAttachment] = useState<any>(null);
    const navigate = useNavigate();
    const [addUser, { isError, error, isSuccess: isAddSuccess }] = useAddUserMutation();
    const [userInfo, setUserInfo] = useState<IUserModel>({} as IUserModel);
    const getCharacterValidationError = (str: string) => {
        return `Your password must have at least 1 ${str}`;
    };

    const validationSchema = Yup.object({
        name: Yup.string().required('Name is required'),
        email: Yup.string().email().required('Email is required'),
        mobile: Yup.string().required('Mobile is required'),
        password: Yup.string().required('Password is required')
            .min(8, 'Password should be at least 8 characters')
            .matches(/[0-9]/, getCharacterValidationError(`digit`))
            .matches(/[a-z]/, getCharacterValidationError(`lowercase`))
            .matches(/[A-Z]/, getCharacterValidationError(`uppercase`)),
        roleId: Yup.number().min(1, 'Role is required'),
        confirmPassword: Yup.string()
            .required('Password not matched!').oneOf([Yup.ref("password")])
    });

    /*const getInitialValues = () => {
        if (id && userInfo) {
            return userInfo;
        } else {
            return initialValues;
        }
    }
*/

    const formik = useFormik({
        initialValues: userInfo,
        enableReinitialize: true,
        validationSchema: validationSchema,
        onSubmit: (values) => {

            const submitData: Record<string, any> = {
                id: values.id,
                name: values.name,
                email: values.email,
                mobile: values.mobile,
                roleId: values.roleId,
                password: values.password,
                attachment: attachment,
                address: values.address
            };

            const formData = new FormData();

            for (const key in submitData) {
                formData.append(key, submitData[key]);
            }

            addUser(formData);
        }
    });

    const handleFileChange = (e: ChangeEvent<HTMLInputElement>) => {
        if (e.target.files?.length) {
            setUserAttachment(e.target.files[0]);
        } else {
            setUserAttachment(null);
        }

    }

    useEffect(() => {
        console.log(error)
        if (isError && error) {
            showErrorNotification();
        }
        if (isAddSuccess) {
            showAddNotification()
            navigate('/admin/users');
        }
    }, [isError, isAddSuccess]);

    useEffect(() => {
        if (isUserSuccess && users) {
            if (users?.result) {
                setUserInfo(users?.result);
                console.log(userInfo);
                console.log("users", users?.result);
            }
        }
    }, [users, isUserSuccess]);

    useEffect(() => {
        console.log("userInfo", userInfo);
    }, [userInfo]);

    useEffect(() => {
        if (isSuccess && roles) {
            if (roles?.result) {
            }
        }
    }, [roles, isSuccess]);

    useEffect(() => {
        document.title = `Add User | ${ProjectTitle}`;
        if (id) {
            document.title = `Edit User | ${ProjectTitle}`;
            setPageTitle(`Edit User`);
        }

    }, []);

    return (
        <>
            <IconBreadcrumbs props={userAddBreadCrumb.userAddBreadCrumb} />
            <Grid item xs={12} sm={12} md={12} mt={2}>
                <Card sx={{ minWidth: 275 }} className="card w-100">
                    <CardHeader title={pageTitle} className="card-header" />
                    <CardContent>
                        <Box component="form" className="w-100 card-form" noValidate onSubmit={formik.handleSubmit}>
                            <Grid container spacing={2}>
                                <Grid item xs={4}>
                                    <FormGroup>
                                        <TextField
                                            margin="normal"
                                            required
                                            fullWidth
                                            id="txtName"
                                            label="Name"
                                            {...formik.getFieldProps("name")}
                                        />
                                        {formik.touched.name && formik.errors.name ? (
                                            <p className="validation-error text-danger">{formik.errors.name}</p>
                                        ) : null}
                                    </FormGroup>
                                </Grid>

                                <Grid item xs={4}>
                                    <FormGroup>
                                        <TextField
                                            margin="normal"
                                            required
                                            fullWidth
                                            id="txtEmail"
                                            label="Email"
                                            {...formik.getFieldProps("email")}
                                        />
                                        {formik.touched.email && formik.errors.email ? (
                                            <p className="validation-error text-danger">{formik.errors.email}</p>
                                        ) : null}
                                    </FormGroup>
                                </Grid>

                                <Grid item xs={4}>
                                    <FormGroup>
                                        <TextField
                                            margin="normal"
                                            required
                                            fullWidth
                                            id="txtMobile"
                                            label="Mobile"
                                            {...formik.getFieldProps("mobile")}
                                        />
                                        {formik.touched.mobile && formik.errors.mobile ? (
                                            <p className="validation-error text-danger">{formik.errors.mobile}</p>
                                        ) : null}
                                    </FormGroup>
                                </Grid>

                                <Grid item xs={4}>
                                    <FormGroup>
                                        <InputLabel id="role-label">Role</InputLabel>
                                        <Select
                                            labelId="role-label"
                                            id="ddlRole"
                                            {...formik.getFieldProps("roleId")}
                                            label="Role"
                                            value={formik.values.roleId}
                                        >
                                            {roles?.result.map((item: IRoleModel, index: number) => {
                                                return (<MenuItem value={item.id} key={index}>{item.name}</MenuItem>)
                                            })}
                                        </Select>
                                        {formik.touched.roleId && formik.errors.roleId ? (
                                            <p className="validation-error text-danger">{formik.errors.roleId}</p>
                                        ) : null}
                                    </FormGroup>
                                </Grid>
                                <Grid item xs={4}>
                                    <FormGroup>
                                        <TextField
                                            type="password"
                                            margin="normal"
                                            required
                                            fullWidth
                                            id="txtPassword"
                                            label="Password"
                                            {...formik.getFieldProps("password")}
                                        />
                                        {formik.touched.password && formik.errors.password ? (
                                            <p className="validation-error text-danger">{formik.errors.password}</p>
                                        ) : null}
                                    </FormGroup>
                                </Grid>

                                <Grid item xs={4}>
                                    <FormGroup>
                                        <TextField
                                            type="password"
                                            margin="normal"
                                            required
                                            fullWidth
                                            id="txtConfirmedPassword"
                                            label="Confirmed Password"
                                            {...formik.getFieldProps("confirmPassword")}
                                        />
                                        {formik.touched.confirmPassword && formik.errors.confirmPassword ? (
                                            <p className="validation-error text-danger">{formik.errors.confirmPassword}</p>
                                        ) : null}
                                    </FormGroup>
                                </Grid>

                                <Grid item xs={4}>
                                    <FormGroup>
                                        <TextField
                                            type="file"
                                            margin="normal"
                                            required
                                            fullWidth
                                            id="fileAttachement"
                                            onChange={handleFileChange}
                                        />
                                    </FormGroup>
                                </Grid>

                                <Grid item xs={8}>
                                    <FormGroup>
                                        <TextField
                                            margin="normal"
                                            fullWidth
                                            id="txtAddress"
                                            label="Address"
                                            {...formik.getFieldProps("address")}
                                        />
                                    </FormGroup>
                                </Grid>
                                <Grid item xs={12}>
                                    <hr />
                                </Grid>
                                <Grid item xs={12}>
                                    <Button variant="outlined" onClick={() => navigate('/admin/users')}> <KeyboardDoubleArrowLeftIcon />Back</Button>
                                    <Button type="submit" variant="contained" color="success" className="pull-right">
                                        Save Changes &nbsp;<DoneAllIcon />
                                    </Button>
                                </Grid>
                            </Grid>
                        </Box>
                    </CardContent>
                </Card>

            </Grid >
        </>
    )
}