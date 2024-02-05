import { IAutocompleteModel } from "../IDropdownModel"

export interface IPurchaseModel {
    id: number,
    billNo: string,
    billDate?: Date| null,
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
