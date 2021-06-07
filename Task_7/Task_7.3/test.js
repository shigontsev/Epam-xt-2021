class User{
    // #name;
    // #age;
    #storage =[{id:"1",value: 123},{id: "2", value: 12443}];
    
    constructor(name, age){
        this.name = name;
        this.age = age;
    }

    display(){
        console.log(this.name+" "+this.age);
        this.#Hello();
        this.#showContent();
    }

    #Hello(){
        console.log("Hello "+this.name);
    } 

    #showContent(){
        console.log(this.#storage);
    }
}

let us = new User("Tom", 21);