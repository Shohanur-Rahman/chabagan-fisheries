import { FormikValues } from "formik";
import { Autocomplete, FormGroup, Grid, TextField } from "@mui/material";
import { DatePicker } from '@mui/x-date-pickers/DatePicker';
import { LocalizationProvider } from '@mui/x-date-pickers/LocalizationProvider';
import { AdapterDayjs } from '@mui/x-date-pickers/AdapterDayjs';
import React, { ChangeEvent, SetStateAction, useEffect, useState } from "react";
import { IAutocompleteModel } from "../../../interfaces/model/IDropdownModel";
import { useGetSupplierAutocompleteQuery } from "../../../redux/features/setup/supplierApi";
import { IPurchaseModel } from "../../../interfaces/model/stock/IPurchaseModel";
import { useGetProjectAutoCompleteQuery } from "../../../redux/features/setup/projectApi";
import dayjs, { Dayjs } from "dayjs";

const PurchaseInfo: React.FC<{
    info: IPurchaseModel,
    formik: FormikValues,
    setState: React.Dispatch<SetStateAction<IPurchaseModel>>
}> = ({ info, formik, setState }) => {

    const { data: supplierData, isSuccess: isSupplierSuccess } = useGetSupplierAutocompleteQuery(null);
    const { data: projectData, isSuccess: isProjectSuccess } = useGetProjectAutoCompleteQuery(null);
    const [suppliers, setSuppliers] = useState<IAutocompleteModel[]>([] as IAutocompleteModel[]);
    const [projects, setProjects] = useState<IAutocompleteModel[]>([] as IAutocompleteModel[]);

    const handleSupplierChange = (event: React.SyntheticEvent, newValue: IAutocompleteModel | null) => {
        console.log(event.type);
        setState((prevState) => ({
            ...prevState,
            supplier: newValue,
            supplierId: newValue?.value ? parseInt(newValue?.value) : 0,
        }));
    }
    const onChangeProjectCombo = (event: React.SyntheticEvent, newValue: IAutocompleteModel | null) => {
        console.log(event.type);
        setState((prevState) => ({
            ...prevState,
            project: newValue,
            projectId: newValue?.value ? parseInt(newValue?.value) : 0,
        }));
    }

    const handlePurchageDateChange = (date: Dayjs | null) => {
        setState((prevState) => ({
            ...prevState,
            billDate: date?.toDate()
        }));
    }

    const onChangeBillNumber = (e: ChangeEvent<HTMLInputElement>) => {
        setState((prevState) => ({
            ...prevState,
            billNo: e.target.value
        }));
    }

    const onChangeNote = (e: ChangeEvent<HTMLInputElement>) => {
        setState((prevState) => ({
            ...prevState,
            note: e.target.value
        }));
    }

    useEffect(() => {
        if (isSupplierSuccess && supplierData) {
            setSuppliers(supplierData?.result as IAutocompleteModel[]);
        }
    }, [supplierData, isSupplierSuccess]);

    useEffect(() => {
        if (isProjectSuccess && projectData) {
            setProjects(projectData?.result as IAutocompleteModel[]);
        }
    }, [projectData, isProjectSuccess]);


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
                        onChange={onChangeBillNumber}
                        value={info.billNo}
                        disabled={(info.id > 0)}
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
                            label="Date"
                            value={dayjs(info.billDate)}
                            onChange={handlePurchageDateChange}
                            className="mt-0 datepicker-sm" />
                    </LocalizationProvider>
                    {formik.touched.billDate && formik.errors.billDate ? (
                        <p className="validation-error text-danger">{formik.errors.billDate}</p>
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
                        value={info.supplier}
                        renderInput={(params) => <TextField {...params} label="Supplier" size="small" />}
                    />
                    {formik.touched.supplierId && formik.errors.supplierId ? (
                        <p className="validation-error text-danger">{formik.errors.supplierId}</p>
                    ) : null}
                </FormGroup>
            </Grid>

            <Grid md={3} item xs={6}>
                <FormGroup>
                    <Autocomplete
                        onChange={onChangeProjectCombo}
                        disablePortal
                        id="combo-box-demo"
                        options={projects}
                        value={info.project}
                        renderInput={(params) => <TextField {...params} label="Projects" size="small" />}
                    />
                    {formik.touched.projectId && formik.errors.projectId ? (
                        <p className="validation-error text-danger">{formik.errors.projectId}</p>
                    ) : null}
                </FormGroup>
            </Grid>

            <Grid md={2} item xs={6}>
                <FormGroup>
                    <TextField
                        margin="normal"
                        fullWidth
                        label="Note"
                        className="mt-0"
                        size="small"
                        onChange={onChangeNote}
                        value={info.note}
                    />
                </FormGroup>
            </Grid>
        </Grid>
    )
}

export default PurchaseInfo;