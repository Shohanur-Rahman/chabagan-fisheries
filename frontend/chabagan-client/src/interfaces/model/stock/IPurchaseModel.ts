export interface IPurchaseModel {
    id: number,
    billNo: string,
    purchaseDate: Date,
    supplierId: number,
    totalAmount: number,
    discount: number,
    grandTotal: number,
    paidAmount: number,
    dues: number,
    items: IPurchaseItems[]
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
    totalPrice: number,
    prodSlNo?: string  | undefined | null
}
