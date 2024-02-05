import React, { SetStateAction, useEffect, useState } from "react"
import { IPurchaseItems, IPurchaseModel } from "../../../interfaces/model/stock/IPurchaseModel"
import { Table, TableBody, TableCell, TableHead, TableRow } from "@mui/material"
import DeleteForeverIcon from '@mui/icons-material/DeleteForever';

const PurchaseItems: React.FC<{
    info: IPurchaseModel,
    setState: React.Dispatch<SetStateAction<IPurchaseModel>>
}> = ({ info, setState }) => {

    const [items, setItems] = useState<IPurchaseItems[]>([] as IPurchaseItems[]);

    const deleteCurrentItem = (row: IPurchaseItems) => {
        setState((prevState) => {
            const updatedItems = prevState.items.filter(item => item.productId !== row.productId && item.brandId !== row.brandId);
            return {
                ...prevState,
                items: updatedItems,
            }
        });
    }
    
    useEffect(() => {
        setItems(info.items);
    }, [info]);

    return (
        <Table size="small" className="hov-table">
            <TableHead>
                <TableRow className="bg-tblue">
                    <TableCell>Item</TableCell>
                    <TableCell align="right">Brand</TableCell>
                    <TableCell align="right">QTY</TableCell>
                    <TableCell align="right">Price</TableCell>
                    <TableCell align="right">Discount</TableCell>
                    <TableCell align="right">Total</TableCell>
                    <TableCell align="right"></TableCell>
                </TableRow>
            </TableHead>
            <TableBody>
                {items?.map((row, index) => {
                    return (
                        <TableRow key={index}>
                            <TableCell component="th" scope="row">
                                {row.itemName}
                            </TableCell>
                            <TableCell align="right">{row.brandName}</TableCell>
                            <TableCell align="right">{row.qty}</TableCell>
                            <TableCell align="right">{row.rate}</TableCell>
                            <TableCell align="right">{row.discount}</TableCell>
                            <TableCell align="right">{row.totalPrice}</TableCell>
                            <TableCell align="right">
                                {/* <span className="cs-btn-edit" onClick={(e) => editCurrentItem(row)}><EditIcon className="f-16" /></span> */}
                                <span className="cs-btn-delete" onClick={() => deleteCurrentItem(row)}><DeleteForeverIcon className="f-16" /></span>
                            </TableCell>
                        </TableRow>
                    )
                })}
            </TableBody>
        </Table>
    )
}

export default PurchaseItems;