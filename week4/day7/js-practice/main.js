'use strict';

function ajaxGet(
    url,
    success,
    failure = res => console.log(res)) {

    let xhr = new XMLHttpRequest();

    xhr.addEventListener("readystatechange", () => {
        console.log(`ready-state is now: ${xhr.readyState}`);
        if (xhr.readyState === 4) {
            // we've recieved the response
            console.log(xhr.response);
            // if status code is success
            if (xhr.status >= 200 && xhr.status < 300) {
                // success
                success(xhr.response);
            } else {
                failure(xhr.response);
            }
        }
    });
    xhr.open("GET", url);
    xhr.send();
}

