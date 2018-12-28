'use strict';

function alertMe() {
    alert("You clicked the element");
}

// we access most of the DOM API using the document object.

// let col1 = document.getElementById("col1");
// //col1.onclick = alertMe(); // <-- wrong
// col1.onclick = alertMe;

// scripts are run as soon as they're encountered in the HTML
// and elements are created in the browser's memory
// as soon as they are encountered on the page

window.onload = function() {
    // this is a basic way of waiting until the document
    // is all loaded before trying to interact with it

    // let col1 = document.getElementById("col1");
    // col1.onclick = alertMe;    
};

// better ay that allows multiple functions to all
// listen on the same event.

// window.addEventListener("load", function () {
// let col1 = document.getElementById("col1");
// col1.onclick = alertMe;
// });

document.addEventListener("DOMContentLoaded", () => {

    let col1 = document.getElementById("col1");
    col1.addEventListener("click", alertMe);

    let header = document.getElementById("header");
    header.innerText += ", changed by JS";
    header.innerHTML += ", changed by JS";
    header.innerHTML = `<u>${innerHTML}</u>`;

    // JQuery, comes JS library, makes a lof of these
    // 


});




//

