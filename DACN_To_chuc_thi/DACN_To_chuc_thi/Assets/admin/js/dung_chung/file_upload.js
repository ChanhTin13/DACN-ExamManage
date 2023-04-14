/**
 * Show Drag & Drop multiple image preview
 * 
 * @author Anuj Kumar
 * @link https://instagram.com/webtricks.ak
 * @link https://github.com/wtricks
 * */

/** Variables */
let files = [],
    dragArea = document.querySelector('.drag-area'),
    input = document.querySelector('.drag-area input'),
    button = document.querySelector('.card button'),
    select = document.querySelector('.drag-area .select'),
    container = document.querySelector('.container');

/** CLICK LISTENER */
select.addEventListener('click', () => input.click());
/* INPUT CHANGE EVENT */
input.addEventListener('change', () => {
    let file = input.files;

    // if user select no image
    if (file.length == 0) return;

    for (let i = 0; i < file.length; i++) {
        if (file[i].type.split("/")[0] != 'application') {
            //console.log(file[i]);
            //alert("Định dạng file " + file[i].name + " không được hỗ trợ");
            continue;
        }
        else if (!files.some(e => e.name == file[i].name)) {
            console.log(file[i]);
            files.push(file[i]);
        }
    }

    showImages();
});

/** SHOW IMAGES */
function showImages() {
    container.innerHTML = files.reduce((prev, curr, index) => {
        let fileName = files[index].name;

        if (fileName.length >= 9)
        { //if file name length is greater than 12 then split it and add ...
            let splitName = fileName.split('.');
            fileName = (splitName[0].substring(0, 10) + "... ." + splitName[1]);
        }
        let img_set="";
        let img_doc = "https://cdn.iconscout.com/icon/free/png-256/docx-file-14-504256.png";
        let img_pdf = "https://upload.wikimedia.org/wikipedia/commons/thumb/8/87/PDF_file_icon.svg/1200px-PDF_file_icon.svg.png";
        let img_excel = "https://play-lh.googleusercontent.com/37EzETO6gZyKmCg2kBIFX1e9gkubxZrVa5fHJ6yOaa7VvEShHjKv2RdtwnZt9Sk258s";
        if (files[index].type.includes("pdf")) {
            img_set = img_pdf;
        }
        else if (files[index].type.includes("sheet")) {
            img_set = img_excel;
        }
        else {
            img_set = img_doc;
        }
        console.log(fileName); 
        return `${prev} 
        <div class="image">
                                            <div class="file-and-file-attr">
                                                <span onclick="delImage(${index})">&times;</span>
                                                <img src="${img_set}" />
                                                <div class="file-attr">
                                                    <div class="file-name" style="word-wrap: normal;">${fileName}</div>
                                                    <div style="word-wrap: normal;">${((files[index].size) / (1024 * 1024)).toFixed(2)} MB</div>
                                                </div> 
                                            </div>
                                        </div>
             
            `
    }, '');
}

/* DELETE IMAGE */
function delImage(index) {
    files.splice(index, 1);
    console.log(files);
    showImages();
}

/* DRAG & DROP */
dragArea.addEventListener('dragover', e => {
    e.preventDefault()
    dragArea.classList.add('dragover')
})

/* DRAG LEAVE */
dragArea.addEventListener('dragleave', e => {
    e.preventDefault()
    dragArea.classList.remove('dragover')
});

/* DROP EVENT */
dragArea.addEventListener('drop', e => {
    e.preventDefault()
    dragArea.classList.remove('dragover');

    let file = e.dataTransfer.files;
    for (let i = 0; i < file.length; i++) {
        /** Check selected file is image */
        if (file[i].type.split("/")[0] != 'application') continue;

        if (!files.some(e => e.name == file[i].name)) {
            files.push(file[i])
        }
    }
    showImages();
});
