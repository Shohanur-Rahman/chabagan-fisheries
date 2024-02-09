import Swal from 'sweetalert2'
import { IApiResponse } from '../interfaces/IApiResponse';

export const ProjectTitle = "Chabagan Fisheries";
//export const FileURL = "http://gewilen510-001-site1.ctempurl.com/";
export const FileURL = "https://localhost:7195/";
export const ApiBaseURL = `${FileURL}api/`;
export const AddSuccessMessage = "Data successfully saved.";
export const UpdateSuccessMessage = "Data successfully updated.";
export const DeleteSuccessMessage = "Data successfully deleted.";


export const showAddNotification = () => {
    Swal.fire({
        title: 'Success',
        text: AddSuccessMessage,
        icon: 'success',
    })
}

export const showUpdateNotification = () => {
    Swal.fire({
        title: 'Success',
        text: UpdateSuccessMessage,
        icon: 'success',
    })
}

export const showDeleteNotification = () => {
    Swal.fire({
        title: "Deleted!",
        text: DeleteSuccessMessage,
        icon: "success"
    });
}

export const showErrorNotification = (error: any = "Something went wrong!", isServer = true) => {
    let msg = "Something went wrong!"
    let errorMessage = ``;
    let errorObject = {} as IApiResponse;
    if (isServer) {
        errorObject = error as IApiResponse;
    }
    if (errorObject && errorObject.data && errorObject.data.errors) {
        errorMessage = errorObject.data.errors[0];
    } else {
        errorMessage = msg;
    }
    Swal.fire({
        icon: "error",
        title: "Oops...",
        text: errorMessage,
    });
}