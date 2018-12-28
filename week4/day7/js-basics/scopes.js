function my_func(a) {
    console.log(a);
}

// we also have "function expression" 
var my_func = (function(a) {
    console.log(a);
});

// with ES6 we also have "arrow functions" / lambda
var one_param = (a) => console.log(a);
// no parameters would look like this
var no_param = () => console.log(a);
// two parameters
var two_params = (a,b) => console.log(a);

// these all do the same thinge except that arrow functions
// do have subtle difference with how "this" workis

// in ES5, there were only two scopes.
//   (remember in C# you have block scope - we can access that vraible within the nearest
//   {} (and only after its declaration))

// in ES5, we have document scropoe aka global scope and function scope.

var x = 5;
x = 5;

function f() {
    console.log(x) // undefined
    if(true) {
    var x = 7;
    }
    // in a function, "var" uses function scope
    // this "x" is visible throughout my function,
    // even at the top, before it's declared
    // sometimes called "hoisting"
}

// (global scope undeclared)
asdf = "asdf";
// ES5 has "strict mode"
"use strict";
// strict mode turns certain silect errors into thrown errors

// ES6 added block scrope to js
// using two new ways to declare variables - 
// "let" and "const"

// so whne you use let and const, variable only in scope within the nearest
// pair of braces, const prevents changing the value after first assignment.

// use let and const always, never var or undeclared. 