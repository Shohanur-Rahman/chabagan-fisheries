import { IAutocompleteModel } from "../IDropdownModel";

export interface IPaymentModel {
    id: number,
    billDate?: Date | null,
    supplierId: number,
    paymentCollectionType?: number,
    paidAmount: number,
    note?: string,
    supplier: IAutocompleteModel | null,
}

export const MapPaymentModel = (info: any) => {
    let result = {
        id: info.id,
        billDate: info.billDate,
        supplierId: info.supplierId,
        paymentCollectionType: info.paymentCollectionType,
        paidAmount: info.paidAmount,
        note: info.note,
        supplier: { label: info.supplier.name, value: info.supplierId.toString() },
    }
    return result;
}