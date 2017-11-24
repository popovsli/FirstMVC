//let test = "" + 1 + 0;
//let devide = " -9\n" - 5;
//let name = prompt('Full name:', '');
//alert(name);
//let isBoss = confirm("Are you the boss?");
//alert(isBoss); // true if OK is pressed

//let userName = prompt('Username: ', '');
//if (userName == 'Admin') {
//    let password = prompt('Password:', '');
//    if (password == 'TheMaster') {
//        alert('Welcome');
//    }
//    else if (password == null) {
//        alert('Canceled');
//    }
//    else {
//        alert('Wrong password');
//    }
//}
//else if (userName == null) {
//    alert('Canceled');
//}
//else {
//    alert('I don’t know you');
//}


//while (true) {

//    let number = +prompt("Enter number greater than 100 please :", '');

//    if (number > 100 || number == 0) break;
//}

let number;
do {
    number = +prompt("Enter number greater than 100 please :", '');
}
while (number <= 100 && number)