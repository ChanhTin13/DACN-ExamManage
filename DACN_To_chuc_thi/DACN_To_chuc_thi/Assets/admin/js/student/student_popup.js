//File Uploader
const btn_file_upload = document.getElementById('btn-file-uploader');

const popup_file_uploader = document.getElementById('popup-file-uploader-container'); 
const quit_file_upload = document.getElementById('quit-form-file-upload');

function openPopUpFileUploader() {
    popup_file_uploader.classList.toggle("show-popup");
}
btn_file_upload.addEventListener('click', () => {
    openPopUpFileUploader();
}); 

quit_file_upload.addEventListener('click', () => {
    popup_file_uploader.classList.remove('show-popup');
});
// Pop Up Update

const quitPopUpUpdate = document.getElementById("quit");
const popupUpdate = document.getElementById("popup-add-container");

function openPopUp() {
    popupUpdate.classList.toggle("show-popup");
}
quitPopUpUpdate.addEventListener('click', () => {
    popupUpdate.classList.remove('show-popup');
}); 