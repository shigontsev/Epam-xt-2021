var storage = new Service();

storage.add({id:"0",value: 123});
storage.add({id: "1", value: 12443});
storage.getAll();
storage.getById("1");
storage.deleteById("1");
storage.add({id: "5", value: 12443});
storage.updateById("5", {id: "1", value:10000000});
storage.replaceById("1", {name:"Bob", city:"Saratov", age: 25});