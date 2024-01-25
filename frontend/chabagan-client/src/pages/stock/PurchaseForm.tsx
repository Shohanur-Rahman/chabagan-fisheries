import { Autocomplete, Button, FormGroup, Grid, TextField } from "@mui/material";
import AddIcon from '@mui/icons-material/Add';
import { useEffect, useState } from "react";
import { IAutocompleteModel } from "../../interfaces/model/IDropdownModel";
import { useGetProductAutocompleteQuery } from "../../redux/features/setup/productApi";
import { useGetBrandAutocompleteQuery } from "../../redux/features/setup/brandApi";

export default function PurchaseForm() {

    const { data: productData, isSuccess: isProductSuccess } = useGetProductAutocompleteQuery(null);
    const [products, setProducts] = useState<IAutocompleteModel[]>([] as IAutocompleteModel[]);
    const { data: brandData, isSuccess: isBrandSuccess } = useGetBrandAutocompleteQuery(null);
    const [brands, setBrands] = useState<IAutocompleteModel[]>([] as IAutocompleteModel[]);


    useEffect(() => {
        if (isProductSuccess && productData) {
            setProducts(productData?.result as IAutocompleteModel[]);
        }
    }, [productData, isProductSuccess]);

    useEffect(() => {
        if (isBrandSuccess && brandData) {
            setBrands(brandData?.result as IAutocompleteModel[]);
        }
    }, [brandData, isBrandSuccess]);

    return (
        <Grid container spacing={2}>
            <Grid md={2} item xs={6}>
                <FormGroup className="mt-15">
                    <Autocomplete
                        disablePortal
                        id="product-combo"
                        options={products}
                        renderInput={(params) => <TextField {...params} label="Product" size="small" />}
                    />
                </FormGroup>
            </Grid>

            <Grid md={2} item xs={6}>
                <FormGroup className="mt-15">
                    <Autocomplete
                        disablePortal
                        id="brand-combo"
                        options={brands}
                        renderInput={(params) => <TextField {...params} label="Brand" size="small" />}
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
                        size="small"
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
                        size="small"
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
                        size="small"
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
                        className=" disabled-control"
                        disabled={true}
                        size="small"
                    />
                </FormGroup>
            </Grid>
            <Grid md={12} item xs={12} className="pt-0">
                <FormGroup className="pull-right">
                    <Button type="submit" variant="contained" color="success" className="mx-250">
                        <AddIcon /> &nbsp; Add Item
                    </Button>
                </FormGroup>
            </Grid>
        </Grid>
    )
}