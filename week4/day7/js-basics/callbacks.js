'use strict';


function addNumber(a,b, callback) {
    let result = a+b;
    
    return callback(result);
}
addNumber(3,4,console.log); // prints 7

// callbacks are important because we do a lot of listening to/waiting
// for events in JS, and also asynchronous stuff