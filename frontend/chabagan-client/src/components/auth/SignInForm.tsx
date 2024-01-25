import { Box, Button, FormGroup, Grid, TextField, } from "@mui/material";
import { Link, useNavigate } from "react-router-dom";
import { useFormik } from "formik";
import * as Yup from "yup";
import { useSigninMutation } from "../../redux/features/auth/authApi";
import { ILoginModel } from "../../interfaces/model/user/ILoginModel";
import { useEffect } from "react";

const initialValues: ILoginModel = {
    email: "",
    password: ""
};

export default function SignInForm() {

    // api handle using rtk query
    const [signin, { isLoading, isError, isSuccess, data, error }] = useSigninMutation();
    const navigate = useNavigate();

    const validationSchema = Yup.object({
        email: Yup.string().required('Email is required'),
        password: Yup.string().required('Password is required'),
    });

    const formik = useFormik({
        initialValues: initialValues,
        validationSchema: validationSchema,
        onSubmit: (values) => {
            signin(values);
        }
    });

    useEffect(() => {
        if (isSuccess && data) {
          navigate("/dashboard");
        }
        if (isError && error) {
          alert("Something went wrong. Please try again");
        }
      }, [isSuccess, isError, data, navigate, error])

    return (
        <>
            <Box component="form" className="w-100" noValidate onSubmit={formik.handleSubmit} sx={{ mt: 1 }}>
                <FormGroup>
                    <TextField
                        margin="normal"
                        required
                        fullWidth
                        id="email"
                        label="Email Address"
                        {...formik.getFieldProps("email")}
                        autoComplete="email"
                        autoFocus
                    />
                    {formik.touched.email && formik.errors.email ? (
                        <p className="validation-error text-danger">{formik.errors.email}</p>
                    ) : null}
                </FormGroup>
                <FormGroup>
                    <TextField
                        margin="normal"
                        required
                        fullWidth
                        {...formik.getFieldProps("password")}
                        label="Password"
                        type="password"
                        id="password"
                        autoComplete="current-password"
                    />
                    {formik.touched.password && formik.errors.password ? (
                        <p className="validation-error text-danger">
                            {formik.errors.password}
                        </p>
                    ) : null}
                </FormGroup>
                <Button
                    type="submit"
                    fullWidth
                    variant="contained"
                    sx={{ mt: 3, mb: 2 }}
                    disabled={isLoading}
                >
                    Sign In
                </Button>
                <Grid container>
                    <Grid item xs>
                        <Link to="#">
                            Forgot password?
                        </Link>
                    </Grid>
                </Grid>
            </Box>
        </>
    )
}