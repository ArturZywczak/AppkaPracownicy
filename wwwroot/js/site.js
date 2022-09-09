// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function showBox(checkbox) {

    parentDiv = checkbox.parentNode;
    var test = parentDiv.classList.toggle('emp-box-show');
    if (test) checkbox.checked = true;
    else checkbox.checked = false;
}

function dragover(thisdiv) {
    thisdiv.classList.toggle('day-dragover');
}

function hideEmpBox(ev) {
    ev.dataTransfer.setData("text", "Gitara Siema");


    var test = document.getElementById('empBoxButton');
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