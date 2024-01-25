import { FormGroup, Grid, TextField } from "@mui/material";

export default function PurchaseCalculation() {
    return (
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
                        className="mt-0 disabled-control"
                        disabled={true}
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
                        className="mt-0 disabled-control"
                        disabled={true}
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
                        className="mt-0 disabled-control"
                        disabled={true}
                    />
                </FormGroup>
            </Grid>
        </Grid>
    )
}