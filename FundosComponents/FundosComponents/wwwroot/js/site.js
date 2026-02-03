// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
window.addEventListener("load", () => {
    const ativo = document.querySelector(".c-abas-previdencia__link--ativo");
    if (ativo) {
        // dispara a animação depois de 10ms
        setTimeout(() => ativo.classList.add("animar"), 10);
    }
});