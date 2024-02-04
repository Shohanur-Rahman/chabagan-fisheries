import { FormGroup, Grid, TextField } from "@mui/material";
import { IPurchaseModel } from "../../interfaces/model/stock/IPurchaseModel";
import { ChangeEvent, SetStateAction, useEffect } from "react";
import { FormikValues } from "formik";


const PurchaseCalculation: React.FC<{
    info: IPurchaseModel,
    formik: FormikValues,
    setState: React.Dispatch<SetStateAction<IPurchaseModel>>
}> = ({ info, formik, setState }) => {
    
    const getFloatValue = (value: string) => {
        const isValidNumber = /^-?\d*\.?\d*$/.test(value);
        if (isValidNumber) {
            return parseFloat(value);
        } else {
            return 0;
        }
    }

    const calculateTotalDiscount = (e: ChangeEvent<HTMLInputElement>) => {
        setState((prevState) => ({
            ...prevState,
            discount: getFloatValue(e.target.value),
        }));
    }
    const handlePaidChange = (e: ChangeEvent<HTMLInputElement>) => {
        setState((prevState) => ({
            ...prevState,
            paidAmount: getFloatValue(e.target.value),
        }));
    }

    useEffect(() => {
        let price = info.totalAmount ? info.totalAmount : 0;
        let discount = info.discount ? info.discount : 0;
        let paid = info.paidAmount ? info.paidAmount : 0;
        let netPrice = (price - discount);
        let dues = (netPrice - paid);
       
        setState((prevState) => ({
            ...prevState,
            grandTotal: netPrice,
            dues: dues,
        }));
    }, [info.totalAmount, info.discount, info.paidAmount]);

    useEffect(() => {
        const totalAmount = info.items.reduce((total, item) => total + item.totalPrice, 0);
        setState((prevState) => ({
            ...prevState,
            totalAmount: totalAmount,
        }));
    }, [info]);

    return (
        <Grid md={4} item xs={6}>
            <Grid md={12} item xs={12}>
                <FormGroup className="mt-0">
                    <TextField
                        type="number"
                        margin="normal"
                        required
                        fullWidth
                        placeholder="Total"
                        size="small"
                        className="mt-0 disabled-control"
                        disabled={true}
                        value={info.totalAmount}
                    />
                    {formik.touched.totalAmount && formik.errors.totalAmount ? (
                        <p className="validation-error text-danger">{formik.errors.totalAmount}</p>
                    ) : null}
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
                        onChange={calculateTotalDiscount}
                        value={info.discount}
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
                        placeholder="Net Amount"
                        size="small"
                        className="mt-0 disabled-control"
                        disabled={true}
                        value={info.grandTotal}
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
                        placeholder="Paid"
                        size="small"
                        className="mt-0"
                        value={info.paidAmount}
                        onChange={handlePaidChange}
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
                        placeholder="Dues"
                        size="small"
                        className="mt-0 disabled-control"
                        disabled={true}
                        value={info.dues}
                    />
                </FormGroup>
            </Grid>
        </Grid>
    )
}

export default PurchaseCalculation;