export interface IUserModel {
    id: number,
    name: string,
    email: string,
    mobile: string,
    roleId: number,
    password: string,
    confirmPassword: string,
    attachment: File | null,
    address: String
}