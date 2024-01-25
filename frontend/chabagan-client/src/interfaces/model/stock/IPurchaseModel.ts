export interface IPurchaseModel {
    id: number,
    billNo: String,
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
    productId: number,
    purchaseId: number,
    brandId: number,
    qty: number,
    rate: number,
    discount: number,
    totalPrice: number,
    prodSlNo?: string | null
}
