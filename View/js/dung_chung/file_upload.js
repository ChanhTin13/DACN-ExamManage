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
            //files.push(file[i]);
            continue;
        }
        if (!files.some(e => e.name == file[i].name)) {
            //console.log(file[i]);
            files.push(file[i]);
        }
    }

    showImages();
});

/** SHOW IMAGES */
function showImages() {
    container.innerHTML = files.reduce((prev, curr, index) => {
        let fileName = files[index].name;

        var path =   event.target.files[index] ;
        console.log( path );

        if (fileName.length >= 9) { //if file name length is greater than 12 then split it and add ...
            let splitName = fileName.split('.');
            fileName = (splitName[0].substring(0, 10) + "... ." + splitName[1]);
            //console.log(fileName);
        }
        return `${prev} 
        <div class="image">
                                            <div class="file-and-file-attr">
                                                <span onclick="delImage(${index})">&times;</span> 
                                                <img src="https://cdn.iconscout.com/icon/free/png-256/docx-file-14-504256.png" />
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
    //console.log(files);
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
