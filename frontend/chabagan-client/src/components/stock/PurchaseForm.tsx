import { Autocomplete, Button, FormGroup, Grid, TextField } from "@mui/material";
import AddIcon from '@mui/icons-material/Add';
import { SetStateAction, useEffect, useState } from "react";
import { IAutocompleteModel } from "../../interfaces/model/IDropdownModel";
import { useGetProductAutocompleteQuery } from "../../redux/features/setup/productApi";
import { useGetBrandAutocompleteQuery } from "../../redux/features/setup/brandApi";
import { IPurchaseItems, IPurchaseModel } from "../../interfaces/model/stock/IPurchaseModel";
import Swal from "sweetalert2";


const PurchaseForm: React.FC<{
    info: IPurchaseModel,
    setState: React.Dispatch<SetStateAction<IPurchaseModel>>
}> = ({ info, setState }) => {

    const { data: productData, isSuccess: isProductSuccess } = useGetProductAutocompleteQuery(null);
    const [products, setProducts] = useState<IAutocompleteModel[]>([] as IAutocompleteModel[]);
    const { data: brandData, isSuccess: isBrandSuccess } = useGetBrandAutocompleteQuery(null);
    const [brands, setBrands] = useState<IAutocompleteModel[]>([] as IAutocompleteModel[]);
    const [selectedProduct, setSelectedProduct] = useState<IAutocompleteModel | null>({} as IAutocompleteModel);
    const [selectedBrand, setSelectedBrand] = useState<IAutocompleteModel | null>({} as IAutocompleteModel);
    const [itemQty, setItemQty] = useState<number>(0);
    const [itemRate, setItemRate] = useState<number>(0);
    const [itemDiscount, setItemDiscount] = useState<number>(0);
    const [itemTotal, setItemTotal] = useState<number>(0);
    const [isClicked, setIsClicked] = useState<boolean>(false);

    const addNewItemToList = (event: React.MouseEvent<HTMLButtonElement>) => {
        setIsClicked(true);

        console.log(event.type);
        if (!selectedProduct?.value || !selectedBrand?.value || itemRate == 0 || itemQty == 0)
            return false;

        let newItem: IPurchaseItems = {
            id: 0,
            itemName: selectedProduct?.label,
            productId: selectedProduct?.value ? parseInt(selectedProduct?.value) : 0,
            purchaseId: 0,
            brandName: selectedBrand?.label,
            brandId: selectedBrand?.value ? parseInt(selectedBrand?.value) : 0,
            qty: itemQty,
            rate: itemRate,
            discount: itemDiscount,
            totalPrice: itemTotal,
            prodSlNo: ''
        }

        const isItemExist = info?.items.some((item) =>
            item.productId === newItem.productId && item.brandId === newItem.brandId);

        if (isItemExist) {
            Swal.fire({
                title: `You want to replace ${newItem.itemName}?`,
                text: `Your item ${newItem.itemName} - ${newItem.brandName} already exist in your list`,
                icon: "warning",
                showCancelButton: true,
                confirmButtonColor: "#d33",
                cancelButtonColor: "#3085d6",
                confirmButtonText: "Yes, replace it!"
            }).then((result) => {
                if (result.isConfirmed) {
                    setState((prevState) => {
                        const updatedItems = prevState.items.map((item) =>
                            item.productId === newItem.productId && item.brandId === newItem.brandId
                                ? { ...item, qty: newItem.qty, rate: newItem.rate, discount: newItem.discount, totalPrice: newItem.totalPrice }
                                : item
                        );

                        return {
                            ...prevState,
                            items: updatedItems,
                        };
                    });
                }
            });
        } else {
            setState((prevState) => ({
                ...prevState,
                items: [...prevState.items, newItem],
            }));
        }
        resetItemState();
        setIsClicked(false);
    }

    const resetItemState = () => {
        setItemQty(0);
        setItemRate(0);
        setItemDiscount(0);
        setItemTotal(0);
    }

    const handleProductChange = (event: React.SyntheticEvent, newValue: IAutocompleteModel | null) => {
        console.log(event.type);
        setSelectedProduct(newValue);
    }
    const handleBrandChange = (event: React.SyntheticEvent, newValue: IAutocompleteModel | null) => {
        console.log(event.type);
        setSelectedBrand(newValue);
    }
    const handleQtyChange = (e: React.ChangeEvent<HTMLInputElement>) => {
        setItemQty(getFloatValue(e.target.value));
    };
    const handleRateChange = (e: React.ChangeEvent<HTMLInputElement>) => {
        setItemRate(getFloatValue(e.target.value));
    };
    const handleDiscountChange = (e: React.ChangeEvent<HTMLInputElement>) => {
        setItemDiscount(getFloatValue(e.target.value));
    };

    const getFloatValue = (value: string) => {
        const isValidNumber = /^-?\d*\.?\d*$/.test(value);
        if (isValidNumber) {
            return parseFloat(value);
        } else {
            return 0;
        }
    }


    useEffect(() => {
        let qty = itemQty ? itemQty : 0;
        let rate = itemRate ? itemRate : 0;
        let discount = itemDiscount ? itemDiscount : 0;
        let total = ((qty * rate) - (qty * discount));

        setItemTotal(total);

    }, [itemQty, itemRate, itemDiscount]);

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
                        onChange={handleProductChange}
                        disablePortal
                        id="product-combo"
                        options={products}
                        renderInput={(params) => <TextField {...params} label="Product" size="small" />}
                    />
                    {isClicked && !selectedProduct?.value ? (
                        <p className="validation-error text-danger">Product is required</p>
                    ) : null}
                </FormGroup>
            </Grid>

            <Grid md={2} item xs={6}>
                <FormGroup className="mt-15">
                    <Autocomplete
                        onChange={handleBrandChange}
                        disablePortal
                        id="brand-combo"
                        options={brands}
                        renderInput={(params) => <TextField {...params} label="Brand" size="small" />}
                    />
                    {isClicked && !selectedBrand?.value ? (
                        <p className="validation-error text-danger">Brand is required</p>
                    ) : null}
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
                        onChange={handleQtyChange}
                        value={itemQty}
                    />
                    {isClicked && itemQty == 0 ? (
                        <p className="validation-error text-danger">Quantity is required</p>
                    ) : null}
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
                        onChange={handleRateChange}
                        value={itemRate}
                    />
                    {isClicked && itemRate == 0 ? (
                        <p className="validation-error text-danger">Rate is required</p>
                    ) : null}
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
                        onChange={handleDiscountChange}
                        value={itemDiscount}
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
                        placeholder="Total"
                        className=" disabled-control"
                        disabled={true}
                        size="small"
                        value={itemTotal}
                    />
                </FormGroup>
            </Grid>
            <Grid md={12} item xs={12} className="pt-0">
                <FormGroup className="pull-right">
                    <Button type="submit" variant="contained"
                        color="success"
                        className="mx-250"
                        onClick={addNewItemToList}
                    >
                        <AddIcon /> &nbsp; Add Item
                    </Button>
                </FormGroup>
            </Grid>
        </Grid>
    )
}

export default PurchaseForm;