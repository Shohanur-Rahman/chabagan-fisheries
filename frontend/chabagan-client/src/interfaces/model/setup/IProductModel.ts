export interface IProductModel {
    id: number,
    name: string,
    categoryId: number,
    description: String,
    mrp?: number | null,
    avatar: any,
    attachment: File | null,
}