import { useFormik } from "formik";
import * as Yup from "yup";
import { Autocomplete, FormGroup, Grid, TextField } from "@mui/material";
import { AdapterDayjs } from '@mui/x-date-pickers/AdapterDayjs';
import { LocalizationProvider } from '@mui/x-date-pickers/LocalizationProvider';
import { DatePicker } from '@mui/x-date-pickers/DatePicker';
import dayjs from "dayjs";
import React, { SetStateAction, useEffect, useState } from "react";
import { IAutocompleteModel } from "../../interfaces/model/IDropdownModel";
import { useGetSupplierAutocompleteQuery } from "../../redux/features/setup/supplierApi";
import { IPurchaseModel } from "../../interfaces/model/stock/IPurchaseModel";
//import DoneAllIcon from '@mui/icons-material/DoneAll';

const PurchaseInfo: React.FC<{
    info: IPurchaseModel,
    setState: React.Dispatch<SetStateAction<IPurchaseModel>>
}> = ({ info, setState }) => {

    const { data: supplierData, isSuccess: isSupplierSuccess } = useGetSupplierAutocompleteQuery(null);
    const [suppliers, setSuppliers] = useState<IAutocompleteModel[]>([] as IAutocompleteModel[]);

    const validationSchema = Yup.object({
        billNo: Yup.string().required('Bill is required')
    });
    const formik = useFormik({
        initialValues: info,
        enableReinitialize: true,
        validationSchema: validationSchema,
        onSubmit: (values) => {
            console.log(values)
        }
    });

    useEffect(() => {
        if (isSupplierSuccess && supplierData) {
            setSuppliers(supplierData?.result as IAutocompleteModel[]);
        }

        console.log(setState)

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
                        <DatePicker value={dayjs('2024-01-25T15:30')}
                            className="mt-0 datepicker-sm" />
                    </LocalizationProvider>
                </FormGroup>
            </Grid>
            <Grid md={3} item xs={6}>
                <FormGroup>
                    <Autocomplete
                        disablePortal
                        id="combo-box-demo"
                        options={suppliers}
                        renderInput={(params) => <TextField {...params} label="Supplier" size="small" />}
                    />
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