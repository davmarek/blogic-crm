// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
function protectDeleteForm(querySelector) {
    const form = document.querySelectorAll(querySelector);
    if (form.length > 0) {
        form.forEach((f) => {
            f.addEventListener('submit', function (e) {
                const confirmation = confirm("Are you sure you want to delete this item?");
                if (!confirmation) {
                    e.preventDefault();
                }
            });
        });
    }
}

document.addEventListener('DOMContentLoaded', () => {
    protectDeleteForm("form[data-confirm-form]");
});
