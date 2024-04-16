class Laptop{
    constructor(info, quality) {
        this.info = info;
        this.quality = quality;
        this.isOn = false;        
    }

    turnOn(){
        this.isOn = true;
        this.quality--;
    }

    turnOff(){
        this.isOn = false;
        this.quality--;
    }

    showInfo(){
        return JSON.stringify(this.info);
    }

    get price(){
        return Number(800 - (this.info.age * 2) + (this.quality * 0.5));
    }

}

let info = {producer: "Dell", age: 2, brand: "XPS"}
let laptop = new Laptop(info, 10)
laptop.turnOn()
console.log(laptop.showInfo())
laptop.turnOff()
console.log(laptop.quality)
laptop.turnOn()
console.log(laptop.isOn)
console.log(laptop.price)


let info1 = {producer: "Lenovo", age: 1, brand: "Legion"}
let laptop1 = new Laptop(info1, 10)
laptop1.turnOn()
console.log(laptop1.showInfo())
laptop1.turnOff()
laptop1.turnOn()
laptop1.turnOff()
console.log(laptop1.isOn)

