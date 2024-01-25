import { Autocomplete, Button, FormGroup, Grid, TextField } from "@mui/material";
import { AdapterDayjs } from '@mui/x-date-pickers/AdapterDayjs';
import { LocalizationProvider } from '@mui/x-date-pickers/LocalizationProvider';
import { DatePicker } from '@mui/x-date-pickers/DatePicker';
import dayjs from "dayjs";
import { useEffect, useState } from "react";
import { IAutocompleteModel } from "../../interfaces/model/IDropdownModel";
import { useGetSupplierAutocompleteQuery } from "../../redux/features/setup/supplierApi";
import DoneAllIcon from '@mui/icons-material/DoneAll';

export default function PurchaseInfo() {

    const { data: supplierData, isSuccess: isSupplierSuccess } = useGetSupplierAutocompleteQuery(null);
    const [suppliers, setSuppliers] = useState<IAutocompleteModel[]>([] as IAutocompleteModel[]);

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
                    />
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
            <Grid md={2} item xs={6}>
                <FormGroup>
                    <Button type="submit" variant="contained" color="success" className="pull-right">
                        Save Changes &nbsp;<DoneAllIcon />
                    </Button>
                </FormGroup>
            </Grid>
        </Grid>
    )
}