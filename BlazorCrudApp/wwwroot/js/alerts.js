window.Alerts = {
    showInfoAlert: (title, message) => {
        Swal.fire({
            title: title,
            text: message,
            icon: "info",
            confirmButtonText: "OK"
        });
    },
    showConfirmationAlert: async (title, message) => {
        const result = await Swal.fire({
            title: title,
            text: message,
            icon: "warning",
            showCancelButton: true,
            confirmButtonText: "Yes",
            cancelButtonText: "No"
        });
        return result.isConfirmed;
    }
};
