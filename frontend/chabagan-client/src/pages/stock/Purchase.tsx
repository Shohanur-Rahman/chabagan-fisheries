import { Box, Button, Card, CardContent, CardHeader, Grid, Table, TableBody, TableCell, TableHead, TableRow } from "@mui/material";
import DoneAllIcon from '@mui/icons-material/DoneAll';
import KeyboardDoubleArrowLeftIcon from '@mui/icons-material/KeyboardDoubleArrowLeft';
import { IconBreadcrumbs } from "../../components/common/IconBreadcrumbs";
import purchaseBreadCrumb from '../../data/Breadcrumbs';
import { useEffect } from "react";
import { ProjectTitle } from "../../data/Config";
import PurchaseInfo from "../../components/stock/PurchaseInfo";
import PurchaseCalculation from "../../components/stock/PurchaseCalculation";
import PurchaseForm from "./PurchaseForm";
export default function Purchase() {

    useEffect(() => {
        document.title = `Purchase | ${ProjectTitle}`;
    }, []);

    return (
        <>
            <IconBreadcrumbs props={purchaseBreadCrumb.purchaseBreadCrumb} />
            <Box mt={2}>
                <Grid container spacing={2}>
                    <Grid item xs={12} sm={12} md={12} lg={12}>
                        <Card sx={{ minWidth: 275 }} className="card w-100">
                            <CardHeader title="Purchase" className="card-header" />
                            <CardContent className="table-content">
                                <PurchaseInfo />
                                <PurchaseForm />
                                <Grid container spacing={2} mt={0}>
                                    <Grid md={8} item xs={6}>
                                        <Table size="small" className="hov-table">
                                            <TableHead>
                                                <TableRow className="bg-tblue">
                                                    <TableCell>Item</TableCell>
                                                    <TableCell align="right">Brand</TableCell>
                                                    <TableCell align="right">QTY</TableCell>
                                                    <TableCell align="right">Price</TableCell>
                                                    <TableCell align="right">Total</TableCell>
                                                </TableRow>
                                            </TableHead>
                                            <TableBody>
                                                <TableRow>
                                                    <TableCell component="th" scope="row">
                                                        Samsung M20
                                                    </TableCell>
                                                    <TableCell align="right">Samsung</TableCell>
                                                    <TableCell align="right">1</TableCell>
                                                    <TableCell align="right">19000</TableCell>
                                                    <TableCell align="right">1900</TableCell>
                                                </TableRow>
                                                <TableRow>
                                                    <TableCell component="th" scope="row">
                                                        Samsung M20
                                                    </TableCell>
                                                    <TableCell align="right">Samsung</TableCell>
                                                    <TableCell align="right">1</TableCell>
                                                    <TableCell align="right">19000</TableCell>
                                                    <TableCell align="right">1900</TableCell>
                                                </TableRow>
                                                <TableRow>
                                                    <TableCell component="th" scope="row">
                                                        Samsung M20
                                                    </TableCell>
                                                    <TableCell align="right">Samsung</TableCell>
                                                    <TableCell align="right">1</TableCell>
                                                    <TableCell align="right">19000</TableCell>
                                                    <TableCell align="right">1900</TableCell>
                                                </TableRow>
                                                <TableRow>
                                                    <TableCell component="th" scope="row">
                                                        Samsung M20
                                                    </TableCell>
                                                    <TableCell align="right">Samsung</TableCell>
                                                    <TableCell align="right">1</TableCell>
                                                    <TableCell align="right">19000</TableCell>
                                                    <TableCell align="right">1900</TableCell>
                                                </TableRow>
                                                <TableRow>
                                                    <TableCell component="th" scope="row">
                                                        Samsung M20
                                                    </TableCell>
                                                    <TableCell align="right">Samsung</TableCell>
                                                    <TableCell align="right">1</TableCell>
                                                    <TableCell align="right">19000</TableCell>
                                                    <TableCell align="right">1900</TableCell>
                                                </TableRow>
                                            </TableBody>
                                        </Table>
                                    </Grid>
                                    <PurchaseCalculation />
                                </Grid>
                                <Grid item xs={12}>
                                    <hr />
                                </Grid>
                                <Grid item xs={12}>
                                    <Button variant="outlined"> <KeyboardDoubleArrowLeftIcon />Back</Button>
                                    <Button type="submit" variant="contained" color="success" className="pull-right">
                                        Save Changes &nbsp;<DoneAllIcon />
                                    </Button>
                                </Grid>
                            </CardContent>
                        </Card>
                    </Grid>
                </Grid>
            </Box >
        </>
    )
}