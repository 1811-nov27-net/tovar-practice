'use strict';

// so AJAX stands for Asynchronous JavaScript And XML
// "let's make request and receive responses from XML
// based servcies dynamically in the page."

// practicall modern meaning: 
// using the DOM API to send requests over the internet

// XMLHttpRequest is the traditional

document.addEventListener("DOMContentLoaded", () => {
    let jokeheader = document.getElementById("jokeHeader");
    let jokeBtn = document.getElementById("jokeBtn");

    jokeBtn.addEventListener("click", () => {
        let xhr = new XMLHttpRequest();

        xhr.addEventListener("readystatechange", () => {
        console.log(`ready-state is now: ${xhr.readyState}`);
        if(xhr.readyState === 4) {
            // we're received the response
            // get the response body text
            let responseJSON = xhr.responseJSON;
            if(xhr.status >= 200 && xhr.status < 300) {
                // success
                let responseObj = JSON.parse(responseJSON);
                jokeheader.innerText = joke;
            }

        }
        })
    });
});
