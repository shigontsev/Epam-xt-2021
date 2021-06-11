var storage = new Service();
console.log(storage.getAll());
storage.add({value: 123});
storage.add({value: 12443});
console.log(storage.getAll());

let Objs = storage.getAll();
console.log(Objs[Objs.length-1].id);
console.log(storage.getById(Objs[Objs.length-1].id));
console.log(storage.deleteById(Objs[Objs.length-1].id));
storage.add({value: 12443});
Objs = storage.getAll();
console.log(storage.getAll());
console.log(storage.updateById(Objs[Objs.length-1].id, {value:10000000}));
console.log(storage.replaceById(Objs[0].id, {name:"Bob", city:"Saratov", age: 25}));
console.log(storage.getAll());