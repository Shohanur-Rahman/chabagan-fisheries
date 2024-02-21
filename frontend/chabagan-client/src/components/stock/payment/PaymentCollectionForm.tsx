import { useFormik } from "formik";
import * as Yup from "yup";
import { DatePicker } from '@mui/x-date-pickers/DatePicker';
import { LocalizationProvider } from '@mui/x-date-pickers/LocalizationProvider';
import { AdapterDayjs } from '@mui/x-date-pickers/AdapterDayjs';
import { Autocomplete, Box, Button, Card, CardContent, CardHeader, FormGroup, TextField } from "@mui/material";
import { ChangeEvent, SetStateAction, useEffect, useState } from "react";
import { IPaymentModel } from "../../../interfaces/model/stock/IPaymentModel";
import { showAddNotification, showErrorNotification, showUpdateNotification } from "../../../data/Config";
import { useAddPaymentCollectionMutation, useUpdatePaymentCollectionMutation } from "../../../redux/features/stock/paymentCollectionApi";
import dayjs, { Dayjs } from "dayjs";
import { useGetSupplierAutocompleteQuery } from "../../../redux/features/setup/supplierApi";
import { IAutocompleteModel } from "../../../interfaces/model/IDropdownModel";

const PaymentCollectionForm: React.FC<
    {
        info: IPaymentModel,
        typeId: number,
        setState: React.Dispatch<SetStateAction<IPaymentModel>>
    }> = ({ info, typeId, setState }) => {
        const [title, setTitle] = useState("Add Payment");
        const [addPaymentCollection, { isLoading, isError, isSuccess, data, error }] = useAddPaymentCollectionMutation();
        const [updatePaymentCollection, { isLoading: isUpdateLoading, isError: isUpdateError, isSuccess: isUpdateSuccess, data: updateData, error: updateError }] = useUpdatePaymentCollectionMutation();
        const { data: supplierData, isSuccess: isSupplierSuccess } = useGetSupplierAutocompleteQuery(null);
        const [suppliers, setSuppliers] = useState<IAutocompleteModel[]>([] as IAutocompleteModel[]);

        const emptyModel: IPaymentModel = {
            id: 0,
            supplierId: 0,
            paymentCollectionType: typeId,
            paidAmount: 0,
            billDate: new Date(),
            supplier: { label: "", value: "" }
        }
        const validationSchema = Yup.object({
            supplierId: Yup.number().min(1, 'Supplier is required'),
            billDate: Yup.date().required('Date is required'),
            paidAmount: Yup.number().min(1, 'Amount is required')
        });
        const formik = useFormik({
            initialValues: info,
            enableReinitialize: true,
            validationSchema: validationSchema,
            validateOnBlur: false,
            onSubmit: (values) => {
                if (values.id > 0) {
                    updatePaymentCollection(values);
                } else {
                    addPaymentCollection(values);
                }
            }
        });

        const resetFields = () => {
            formik.resetForm();
            setTitle(`Add ${typeId == 7 ? "Payment" : "Collection"}`);
            setState(emptyModel);
        }
        const getShrink = (value: any) => {
            return value ? true : false;
        }

        const handleDateChange = (date: Dayjs | null) => {
            setState((prevState) => ({
                ...prevState,
                billDate: date?.toDate()
            }));
        }

        const onNoteChange = (e: ChangeEvent<HTMLInputElement>) => {
            setState((prevState) => ({
                ...prevState,
                note: e.target.value
            }));
        }

        const onAmountChange = (e: ChangeEvent<HTMLInputElement>) => {
            setState((prevState) => ({
                ...prevState,
                paidAmount: parseFloat(e.target.value)
            }));
        }

        const handleSupplierChange = (event: React.SyntheticEvent, newValue: IAutocompleteModel | null) => {
            console.log(event.type);
            setState((prevState) => ({
                ...prevState,
                supplier: newValue,
                supplierId: newValue?.value ? parseInt(newValue?.value) : 0,
            }));
        }
        useEffect(() => {
            if (isSupplierSuccess && supplierData) {
                setSuppliers(supplierData?.result as IAutocompleteModel[]);
            }
        }, [supplierData, isSupplierSuccess]);

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

        useEffect(() => {
            if (info && info.id > 0) {
                setTitle(`Edit ${typeId == 7 ? "Payment" : "Collection"}`);
            } else {
                setTitle(`Add ${typeId == 7 ? "Payment" : "Collection"}`);
            }
        }, [info]);
        return (
            <Card className="card w-100">
                <CardHeader title={title} className="card-header" />
                <CardContent>
                    <Box component="form" className="w-100 card-form" noValidate onSubmit={formik.handleSubmit}>
                        <FormGroup className="mb-1">
                            <Autocomplete
                                onChange={handleSupplierChange}
                                disablePortal
                                id="customer-combo"
                                options={suppliers}
                                value={info.supplier}
                                renderInput={(params) => <TextField {...params} label={(typeId == 7 ? `Supplier*` : "Customer*")} size="small" />}
                            />
                            {formik.touched.supplierId && formik.errors.supplierId ? (
                                <p className="validation-error text-danger">{formik.errors.supplierId}</p>
                            ) : null}
                        </FormGroup>
                        <FormGroup className="mb-1">
                            <LocalizationProvider dateAdapter={AdapterDayjs}>
                                <DatePicker
                                    label="Date*"
                                    value={dayjs(info.billDate)}
                                    onChange={handleDateChange}
                                    className="mt-0 datepicker-sm" />
                            </LocalizationProvider>
                            {formik.touched.billDate && formik.errors.billDate ? (
                                <p className="validation-error text-danger">{formik.errors.billDate}</p>
                            ) : null}
                        </FormGroup>
                        <FormGroup className="mb-10px">
                            <TextField
                                type="number"
                                margin="normal"
                                required
                                fullWidth
                                label="Amount"
                                size="small"
                                className="mt-0"
                                value={info.paidAmount}
                                onChange={onAmountChange}
                            />
                            {formik.touched.paidAmount && formik.errors.paidAmount ? (
                                <p className="validation-error text-danger">{formik.errors.paidAmount}</p>
                            ) : null}
                        </FormGroup>
                        <FormGroup>
                            <TextField
                                margin="normal"
                                fullWidth
                                label="Note"
                                className="mt-0"
                                size="small"
                                value={info.note}
                                onChange={onNoteChange}
                                InputLabelProps={{ shrink: getShrink(formik.values.note) }}
                            />
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

export default PaymentCollectionForm;