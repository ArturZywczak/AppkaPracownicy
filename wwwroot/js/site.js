// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function showBox(checkbox) {
    parentDiv = checkbox.parentNode;
    parentDiv.classList.toggle('emp-box-show');
}

function dragover(thisdiv) {
    thisdiv.classList.toggle('day-dragover');
}

function testhide(ev) {
    ev.dataTransfer.setData("text", "Gitara Siema");


    var test = document.getElementById('thing');
    test.checked = false;
    showBox(test);
}

function allowDrop(ev) {
    ev.preventDefault();
}

function drop(ev) {
    ev.preventDefault();
    var data = ev.dataTransfer.getData("text");
    const textnode = document.createTextNode(data);
    ev.target.appendChild(textnode);

    dragover(ev.target);
}