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

let obj = {
    name: 'Axel',
    skill: 100,
    sayName: function() {console.log(this.name) },
    saName2(name) {
        console.log(this.name);
    }
};

obj.sayName();


function Person(name, age) {
    this.name = name;
    this.age = age;
    this.sayName = function() {
        console.log(this.name);
    }
}

function Graduate (name,age, gradYear) {
    this.__proto__ = new Person(name, age);
    this.gradYear = gradYear;
    // could have new methods too
    
}

let axel = new Graduate("axel", 23, 2018);
console.log(axel);

// when js does property access (or assignment)
// on an object, it first scans the object
// if nothing is found, it then looks at that
// object's __proto__, and on and go
// in ES6, we have proper classes with inheritance.. 
class Person2 {
    constructor(name, age) {
        this.name = name;
        this.age = age;
        this.sayName = function () {
            console.log(this.name);
        };
    }
}


class Graduate2 extends Person { // "extends" instead of " : "
    constructor(name, age, gradYear) {
       super(name, age); // "super" instead of "base"
        this.gradYear = gradYear;
        // could have new methods too
    }
}


// JS (ES5) IS object-oriented, but without classes
// ES6 is object-oriented with classes
// "OOP" is one paradigm of programming
// "procedural" is anotheer - like C
// "functional" is another, where functions (behavior) are
// just another kind of data

// new features in ES6: 
/*
- let, const
- arrow functions
- class, interface
- method syntax for functions as properties
- string interpolation
- symbol tyupe for GUID's
- new useful built in functions (e.g. string searching)
- Promises for async stuff without call-backs
- native modules (like namespace)
- built-in Set and Map
- "for of" look like "foreach"
- getters and setters for properties like C#

*/

