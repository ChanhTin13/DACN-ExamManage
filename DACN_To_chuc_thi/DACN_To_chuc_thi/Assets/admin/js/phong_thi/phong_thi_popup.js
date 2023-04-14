
const btn_add = document.getElementById('btn-add-popup');

const popup_add_container = document.getElementById('popup-add-container');

const quit = document.getElementById('quit');
function openPopUp() {
    popup_add_container.classList.toggle("show-popup");
}
btn_add.addEventListener('click', () => {
    openPopUp();
});

quit.addEventListener('click', () => {
    popup_add_container.classList.remove('show-popup');
});
