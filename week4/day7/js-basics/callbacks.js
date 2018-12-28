'use strict';


function addNumber(a,b, callback) {
    let result = a+b;
    
    return callback(result);
}
addNumber(3,4,console.log); // prints 7

// callbacks are important because we do a lot of listening to/waiting
// for events in JS, and also asynchronous stuff

function newCounter() {
    let c = 0;
    return () => {
        c++;
        return c;
    };
}


let counter = newCounter();
// normally at this point "c" would disappear from the stack
// because it has passed out of scope

console.log(counter());

console.log(counter());

// in JS, variables that are referenced by functions
// that are still in scope, themselves remain in scop

// in JS, functions "close over" any variables they reference
// sometimes we call the functions themselves "closures"

// before ES6, we wanted "namespaces", we wanted to encapsulate private details and expose only
// needed functionalitty
// closure allows us to do this. 

// IIFE (immediately-invoked function expression)
let library = (function() {
    let privateData = 0;
    return {
        libraryMethod() {
        return privateData;
        },
    };
})();

// this library object doesn't containt privateData or 
// privateFunction, so they can't be modified/accessed, and don't
// pollute the global namespace, but, the methods inside can still
// use them.

// some encapsulation and abstraction for JS.
