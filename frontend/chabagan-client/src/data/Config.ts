import Swal from 'sweetalert2'

export const ProjectTitle = "Chabagan Fisheries";
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

export const showErrorNotification = () => {
    Swal.fire({
        icon: "error",
        title: "Oops...",
        text: "Something went wrong!",
    });
}