
import { LockOutlined } from "@mui/icons-material";
import { Avatar, Box, createTheme, CssBaseline, Grid, Paper, ThemeProvider, Typography } from "@mui/material";
import SignInSidebar from "../../components/auth/SignInSidebar";
import SignInForm from "../../components/auth/SignInForm";

const defaultTheme = createTheme();

export default function SignIn() {

    return (
        <>
            <ThemeProvider theme={defaultTheme}>
                <Grid container component="main" sx={{ height: '100vh' }}>
                    <CssBaseline />
                    <SignInSidebar />
                    <Grid item xs={12} sm={8} md={4} component={Paper} elevation={6} square>
                        <Box
                            sx={{
                                my: 8,
                                mx: 4,
                                display: 'flex',
                                flexDirection: 'column',
                                alignItems: 'center',
                            }}
                        >
                            <Avatar sx={{ m: 1, bgcolor: 'secondary.main' }}>
                                <LockOutlined />
                            </Avatar>
                            <Typography component="h1" variant="h5">
                                Sign in
                            </Typography>
                            <SignInForm />
                        </Box>
                    </Grid>
                </Grid>
            </ThemeProvider>
        </>
    )
}