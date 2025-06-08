// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
function protectDeleteForm(querySelector){
    const form = document.querySelector(querySelector);
    if (form) {
        form.addEventListener('submit', function(event) {
            const confirmation = confirm("Are you sure you want to delete this item?");
            if (!confirmation) {
                event.preventDefault();
            }
        });
    } else {
        console.warn(`Form with selector "${querySelector}" not found.`);
    }
}