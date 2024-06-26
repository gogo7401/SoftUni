function Solve(arrInput) {
  class Cat {
    constructor(catName, catAge) {
      this.name = catName;
      this.age = catAge;
    }

    meow() {
      console.log(`${this.name}, age ${this.age} says Meow`);
    }
  }

  for (const item of arrInput) {
    let [name, age] = item.split(" ");
    let cat = new Cat(name, age);
    cat.meow();
  }
}

Solve(["Mellow 2", "Tom 5"]);
