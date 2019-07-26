function isPrime() {
    for (let i = 2; i < 1001; i++) {
        if (!(1001 % i)) {
            return false;
        }
    }
    return true;
}

console.log("say if 1001 is prime");
var isPrime1001 = isPrime(1001);
if (isPrime1001) {
    console.log("is prime");
} else {
    console.log("is not prime");
}

