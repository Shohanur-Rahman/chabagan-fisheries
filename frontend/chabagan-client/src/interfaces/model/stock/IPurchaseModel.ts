import { IAutocompleteModel } from "../IDropdownModel"

export interface IPurchaseModel {
    id: number,
    billNo: string,
    billDate?: Date | null,
    supplierId: number,
    projectId: number,
    totalAmount: number,
    discount: number,
    netAmount: number,
    paidAmount: number,
    duesAmount: number,
    items: IPurchaseItems[],
    supplier?: IAutocompleteModel | null,
    project?: IAutocompleteModel | null,
    note?: string
}

export interface IPurchaseItems {
    id: number,
    itemName: string | undefined | null,
    productId: number | undefined | null,
    purchaseId: number,
    brandName: string | undefined | null,
    brandId: number | undefined | null,
    qty: number,
    rate: number,
    discount: number,
    totalPrice: number
}

export const MapPurchaseInfo = (info: any) => {
    let result = {
        id: info.id,
        billNo: info.billNo,
        billDate: info.billDate,
        supplierId: info.supplierId,
        totalAmount: info.totalAmount,
        discount: info.discount,
        netAmount: info.netAmount,
        paidAmount: info.paidAmount,
        duesAmount: info.duesAmount,
        items: info.items.map((sub: any) => {
            let item: IPurchaseItems = {
                id: 0,
                itemName: sub.product.name,
                productId: sub.productId,
                purchaseId: 0,
                brandName: sub.brand.name,
                brandId: sub.brandId,
                qty: sub.qty,
                rate: sub.rate,
                discount: sub.discount,
                totalPrice: sub.totalPrice
            }
            return item;
        }),
        supplier: { label: info.supplier.name, value: info.supplier.id },
        project: { label: info.project.name, value: info.project.id },
        projectId: info.projectId,
        note: info.note
    }

    return result;
}