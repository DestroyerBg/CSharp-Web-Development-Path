function solve(input) {
    let cats = [];
    class Cat{
        constructor(catName, age){
            this.catName = catName;
            this.age = age;
        }

        meow(){
            console.log(`${this.catName}, age ${this.age} says Meow`);
        }
    }

    for (let index = 0; index < input.length; index++) {
       let [name,age] = input[index].split(' ');
       let cat = new Cat(name,age);
       cats.push(cat);
    }

    for (const cat of cats) {
        cat.meow();
    }
}

solve(['Mellow 2', 'Tom 5']);