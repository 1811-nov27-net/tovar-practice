console.log('main.js');

// JavaScript is dynamically typed
// varibles have no types, only values have types
//  or, seerver-side with things like Node.JS

var x;
// numbers
// for intergers, floating-point, whatever
// 64-bit floating -point number
x = 5;
x = 5.5;

// we have all the stuff that IEEE floating pints
// are supposed to have
console.log("value of x: " + x);
console.log("type of x: " + typeof(x));

// string
// single or double quotes, same thing
x ="asfs";

// boolean
x = true;
x = false;

// null
// typeof lies and says it's an object
// but this has been kept for back compatibility

x = null;

// object
// works like "dynamic" in C#
// get or set any property without "declaring" it
x = {};

// undefined
// you access something that doesn't exist

// there's synatx for aarays bu tthey are just objects as well
x = [1,2,3,4];

x.asdf = true;

// we can acccess the properties of objects with indexing sysntx or dot syntax
console.log(x['asdf']);

// functions are first-class objects

// functions are really just object type
// but typeof does call them "function".

// function have parameter names, but not parameter ytpes
//  or return types
function my_function(a,b,c) {
     if(a == 1){
         return a;
     }
}

x = my_function(1,2,3);
x = my_function();// unpassed parameters will be "undefined"

console.log("value of x: " + x);
console.log("type of x: " + typeof(x));

// we standardized JavaScript under the name "ECMAScript"
// or "ES" for short
// "what version of JavaScript are we using?"

// symbol
// (added in ES5, for GUID's, unique ID's for things)

// ES5
    // this is the baseline for all modern javascript
    // because all browsers support it
    // prototype ingeritance
    
// ES2016
    // classes + interfaces
// ES2017

// theree are lot sof other langues that people have come
// up with that extend JavaScript and compile down to JavaScript

// TypeScript, made by Microsoft
//   adds opt-in strict typing to JS
// CoffeeScript

// sometimes people call this "transpilation"
// often we say we trasnfile to JavaScript

// we also transpile ES6 to ES5
// any higher version we cann transpile to a lower version

