export default interface IPurchaseModel {
    id: number,
    regDate: Date,
    billNo: String,
    supplierId: number,
    location: String,
    totalAmount: number,
    discount: number,
    grandTotal: number,
    paidAmount: number,
    dues: number
}