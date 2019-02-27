document.addEventListener("DOMContentLoaded", () => {

    for (var i = 1; i <= 5; i++) {
        var elem = document.getElementById("result");
        elem.innerHTML = `results were printed ${i} times`;
   }
    console.log(`i is: ${i}`);
});