import { FormGroup, Grid, TextField } from "@mui/material";
import { IPurchaseModel } from "../../interfaces/model/stock/IPurchaseModel";
import { ChangeEvent, SetStateAction, useEffect, useState } from "react";


const PurchaseCalculation: React.FC<{
    info: IPurchaseModel,
    setState: React.Dispatch<SetStateAction<IPurchaseModel>>
}> = ({ info, setState }) => {

    const [totalPrice, setTotalPrice] = useState<number>(0);
    const [totalDiscount, setTotalDiscount] = useState<number>(0);
    const [netAmount, setNetAmount] = useState<number>(0);
    const [totalPaid, setTotalPaid] = useState<number>(0);
    const [totalDues, setTotalDues] = useState<number>(0);


    const getFloatValue = (value: string) => {
        const isValidNumber = /^-?\d*\.?\d*$/.test(value);
        if (isValidNumber) {
            return parseFloat(value);
        } else {
            return 0;
        }
    }

    const calculateTotalDiscount = (e: ChangeEvent<HTMLInputElement>) => {
        setTotalDiscount(getFloatValue(e.target.value));
    }
    const handlePaidChange = (e: ChangeEvent<HTMLInputElement>) => {
        setTotalPaid(getFloatValue(e.target.value));
    }

    useEffect(() => {
        let price = totalPrice ? totalPrice : 0;
        let discount = totalDiscount ? totalDiscount : 0;
        let paid = totalPaid ? totalPaid : 0;
        let netPrice = (price - discount);
        let dues = (netPrice - paid);
        setNetAmount(netPrice);
        setTotalDues(dues);

    }, [totalPrice, totalDiscount, totalPaid]);

    useEffect(() => {
        const totalAmount = info.items.reduce((total, item) => total + item.totalPrice, 0);
        setTotalPrice(totalAmount);
        console.log(setState)
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
                        value={totalPrice}
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
                        onChange={calculateTotalDiscount}
                        value={totalDiscount}
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
                        value={netAmount}
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
                        value={totalPaid}
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
                        value={totalDues}
                    />
                </FormGroup>
            </Grid>
        </Grid>
    )
}

export default PurchaseCalculation;