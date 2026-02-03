document.addEventListener("DOMContentLoaded", () => {
    document.querySelectorAll(".search-input").forEach(component => {
        const input = component.querySelector(".search-input__field");
        const dropdown = component.querySelector(".search-input__dropdown");

        const url = input.dataset.searchUrl;
        const minChars = parseInt(input.dataset.minChars);

        let debounce;

        input.addEventListener("input", () => {
            clearTimeout(debounce);

            if (input.value.length < minChars) {
                dropdown.classList.remove("show");
                return;
            }

            debounce = setTimeout(async () => {
                const response = await fetch(`${url}?q=${encodeURIComponent(input.value)}`);
                const data = await response.json();

                dropdown.innerHTML =
                    data.length === 0
                        ? "<li>Nenhum resultado</li>"
                        : data.map(x => `<li>${x}</li>`).join("");

                dropdown.classList.add("show");
            }, 200);
        });

        dropdown.addEventListener("click", e => {
            if (e.target.tagName === "LI") {
                input.value = e.target.textContent;
                dropdown.classList.remove("show");
            }
        });

        // Fecha ao clicar fora
        document.addEventListener("click", (e) => {
            if (!component.contains(e.target)) {
                dropdown.classList.remove("show");
            }
        });
    });
});
