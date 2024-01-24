import { Autocomplete, Box, Button, Card, CardContent, CardHeader, FormGroup, Grid, Table, TableBody, TableCell, TableHead, TableRow, TextField } from "@mui/material";
import DoneAllIcon from '@mui/icons-material/DoneAll';
import KeyboardDoubleArrowLeftIcon from '@mui/icons-material/KeyboardDoubleArrowLeft';
import { AdapterDayjs } from '@mui/x-date-pickers/AdapterDayjs';
import { LocalizationProvider } from '@mui/x-date-pickers/LocalizationProvider';
import { DatePicker } from '@mui/x-date-pickers/DatePicker';
import { IconBreadcrumbs } from "../../components/common/IconBreadcrumbs";
import purchaseBreadCrumb from '../../data/Breadcrumbs';
import dayjs from "dayjs";
export default function Purchase() {
    const products = [
        { label: 'Option 1', value: 'option1' },
        { label: 'Option 2', value: 'option2' },
        { label: 'Option 3', value: 'option3' },
    ];

    return (
        <>
            <IconBreadcrumbs props={purchaseBreadCrumb.purchaseBreadCrumb} />
            <Box mt={2}>
                <Grid container spacing={2}>
                    <Grid item xs={12} sm={12} md={12} lg={12}>
                        <Card sx={{ minWidth: 275 }} className="card w-100">
                            <CardHeader title="Purchase" className="card-header" />
                            <CardContent className="table-content">
                                <Grid container spacing={2}>
                                    <Grid md={3} item xs={6}>
                                        <FormGroup>
                                            <TextField
                                                margin="normal"
                                                required
                                                fullWidth
                                                label="Bill No"
                                                className="mt-0"
                                            />
                                        </FormGroup>
                                    </Grid>
                                    <Grid md={3} item xs={6}>
                                        <FormGroup>
                                            <LocalizationProvider dateAdapter={AdapterDayjs}>
                                                <DatePicker value={dayjs('2024-01-25T15:30')}
                                                    className="mt-0" />
                                            </LocalizationProvider>
                                        </FormGroup>
                                    </Grid>
                                    <Grid md={3} item xs={6}>
                                        <FormGroup>
                                            <TextField
                                                margin="normal"
                                                required
                                                fullWidth
                                                label="Location"
                                                className="mt-0"
                                            />
                                        </FormGroup>
                                    </Grid>

                                    <Grid md={3} item xs={6}>
                                        <FormGroup>
                                            <Autocomplete
                                                disablePortal
                                                id="combo-box-demo"
                                                options={products}
                                                sx={{ width: 300 }}
                                                renderInput={(params) => <TextField {...params} label="Supplier" />}
                                            />
                                        </FormGroup>
                                    </Grid>
                                </Grid>
                                <Grid container spacing={2}>
                                    <Grid md={2} item xs={6}>
                                        <FormGroup className="mt-15">
                                            <Autocomplete
                                                disablePortal
                                                id="combo-box-demo"
                                                options={products}
                                                renderInput={(params) => <TextField {...params} label="Product" />}
                                            />
                                        </FormGroup>
                                    </Grid>

                                    <Grid md={2} item xs={6}>
                                        <FormGroup className="mt-15">
                                            <Autocomplete
                                                disablePortal
                                                id="combo-box-demo"
                                                options={products}
                                                renderInput={(params) => <TextField {...params} label="Brand" />}
                                            />
                                        </FormGroup>
                                    </Grid>
                                    <Grid md={2} item xs={6}>
                                        <FormGroup>
                                            <TextField
                                                type="number"
                                                margin="normal"
                                                required
                                                fullWidth
                                                label="Qty"
                                            />
                                        </FormGroup>
                                    </Grid>
                                    <Grid md={2} item xs={6}>
                                        <FormGroup>
                                            <TextField
                                                type="number"
                                                margin="normal"
                                                required
                                                fullWidth
                                                label="Rate"
                                            />
                                        </FormGroup>
                                    </Grid>
                                    <Grid md={2} item xs={6}>
                                        <FormGroup>
                                            <TextField
                                                type="number"
                                                margin="normal"
                                                required
                                                fullWidth
                                                label="Discount"
                                            />
                                        </FormGroup>
                                    </Grid>
                                    <Grid md={2} item xs={6}>
                                        <FormGroup>
                                            <TextField
                                                type="number"
                                                margin="normal"
                                                required
                                                fullWidth
                                                label="Total"
                                                disabled={true}
                                            />
                                        </FormGroup>
                                    </Grid>
                                </Grid>
                                <Grid container spacing={2} mt={2}>
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
                                    <Grid md={4} item xs={6}>
                                        <Grid md={12} item xs={12}>
                                            <FormGroup className="mt-0">
                                                <TextField
                                                    type="number"
                                                    margin="normal"
                                                    required
                                                    fullWidth
                                                    label="Total"
                                                    size="small"
                                                    className="mt-0"
                                                />
                                            </FormGroup>
                                        </Grid>
                                        <Grid md={12} item xs={12}>
                                            <FormGroup>
                                                <TextField
                                                    type="number"
                                                    margin="normal"
                                                    required
                                                    fullWidth
                                                    label="Discount"
                                                    size="small"
                                                    className="mt-0"
                                                />
                                            </FormGroup>
                                        </Grid>
                                        <Grid md={12} item xs={12}>
                                            <FormGroup>
                                                <TextField
                                                    type="number"
                                                    margin="normal"
                                                    required
                                                    fullWidth
                                                    label="Net Amount"
                                                    size="small"
                                                    className="mt-0"
                                                />
                                            </FormGroup>
                                        </Grid>
                                        <Grid md={12} item xs={12}>
                                            <FormGroup>
                                                <TextField
                                                    type="number"
                                                    margin="normal"
                                                    required
                                                    fullWidth
                                                    label="Paid"
                                                    size="small"
                                                    className="mt-0"
                                                />
                                            </FormGroup>
                                        </Grid>
                                        <Grid md={12} item xs={12}>
                                            <FormGroup>
                                                <TextField
                                                    type="number"
                                                    margin="normal"
                                                    required
                                                    fullWidth
                                                    label="Dues"
                                                    size="small"
                                                    className="mt-0"
                                                />
                                            </FormGroup>
                                        </Grid>
                                    </Grid>
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