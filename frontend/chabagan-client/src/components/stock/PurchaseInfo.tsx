import { FormikValues } from "formik";
import { Autocomplete, FormGroup, Grid, TextField } from "@mui/material";
import { AdapterDayjs } from '@mui/x-date-pickers/AdapterDayjs';
import { LocalizationProvider } from '@mui/x-date-pickers/LocalizationProvider';
import { DatePicker } from '@mui/x-date-pickers/DatePicker';
import React, { useEffect, useState } from "react";
import { IAutocompleteModel } from "../../interfaces/model/IDropdownModel";
import { useGetSupplierAutocompleteQuery } from "../../redux/features/setup/supplierApi";
import dayjs from "dayjs";


const PurchaseInfo: React.FC<{
    formik: FormikValues
}> = ({ formik }) => {

    const { data: supplierData, isSuccess: isSupplierSuccess } = useGetSupplierAutocompleteQuery(null);
    const [suppliers, setSuppliers] = useState<IAutocompleteModel[]>([] as IAutocompleteModel[]);

    const handleSupplierChange = (event: React.SyntheticEvent, newValue: IAutocompleteModel | null) => {
        console.log(event.type);
        formik.setFieldValue('supplierId', newValue?.value ? parseInt(newValue?.value) : 0);
    }

    const handlePurchageDateChange = (date: Date | null) => {
        formik.setFieldValue('purchaseDate', date);
    }

    useEffect(() => {
        if (isSupplierSuccess && supplierData) {
            setSuppliers(supplierData?.result as IAutocompleteModel[]);
        }
    }, [supplierData, isSupplierSuccess]);


    return (
        <Grid container spacing={2}>
            <Grid md={2} item xs={6}>
                <FormGroup>
                    <TextField
                        margin="normal"
                        required
                        fullWidth
                        label="Bill No"
                        className="mt-0"
                        size="small"
                        {...formik.getFieldProps("billNo")}
                    />
                    {formik.touched.billNo && formik.errors.billNo ? (
                        <p className="validation-error text-danger">{formik.errors.billNo}</p>
                    ) : null}
                </FormGroup>
            </Grid>
            <Grid md={2} item xs={6}>
                <FormGroup>
                    <LocalizationProvider dateAdapter={AdapterDayjs}>
                        <DatePicker
                            // value={dayjs('2024-01-25T15:30')}
                            onChange={handlePurchageDateChange}
                            className="mt-0 datepicker-sm" />
                    </LocalizationProvider>
                    {formik.touched.purchaseDate && formik.errors.purchaseDate ? (
                        <p className="validation-error text-danger">{formik.errors.purchaseDate}</p>
                    ) : null}
                </FormGroup>
            </Grid>
            <Grid md={3} item xs={6}>
                <FormGroup>
                    <Autocomplete
                        onChange={handleSupplierChange}
                        disablePortal
                        id="combo-box-demo"
                        options={suppliers}
                        renderInput={(params) => <TextField {...params} label="Supplier" size="small" />}
                    />
                    {formik.touched.supplierId && formik.errors.supplierId ? (
                        <p className="validation-error text-danger">{formik.errors.supplierId}</p>
                    ) : null}
                </FormGroup>
            </Grid>
            {/* <Grid md={2} item xs={6}>
                <FormGroup>
                    <Button type="submit" variant="contained" color="success" className="pull-right">
                        Save Changes &nbsp;<DoneAllIcon />
                    </Button>
                </FormGroup>
            </Grid> */}
        </Grid>
    )
}

export default PurchaseInfo;