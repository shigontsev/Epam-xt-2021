class Service{
    // #storage = [{id:"0",value: 123},{id: "1", value: 12443}];
    #storage = [];

    //принимает объект и позволяет добавить его в коллекцию
    add(obj){
        this.#checkObject(obj);
        this.#storage.push(Object.assign({id: this.#generateId()}, obj));
    }
    #generateId(){
        while (true) {
            let result = parseInt(Math.random()*100000).toString();
            if(this.#storage.length == 0 ||
                 this.#storage.find(item => item.id === result) === undefined){
                return result;
            }
        }
    }

    //принимает id и возвращает найденный объект или NULL если не найден
    getById(id){
        this.#checkId(id);
        for (const obj of this.#storage) {
            if (obj.id === id) {
                return obj;
            }
        }
        return null
    }
    
    //возвращает весь массив объектов
    getAll(){
        return this.#storage.slice();
    }

    //принимает id и возвращает удаленный объект
    deleteById(id){
        this.#checkId(id);
        
        let value = null;
        for (const key in this.#storage) {
            if (Object.hasOwnProperty.call(this.#storage, key) && this.#storage[key].id == id) {
                value = this.#storage[key];
                this.#storage.splice(key, 1);
                break;
            }
        }

        return value;
    }

    // принимает id первым параметром и объект-вторым. Обновляет поля объекта
    //новыми значениями
    updateById(id, obj){
        this.#checkId(id);
        this.#checkObject(obj);

        for (const key in this.#storage) {
            if (Object.hasOwnProperty.call(this.#storage, key) &&
            this.#storage[key].id === id) {
                return this.#updateCurrentObject(this.#storage[key], obj);
            }
        }
        return false;
    }
    #updateCurrentObject(curObj, newObj){
        if (newObj["id"] && typeof newObj["id"] !== "string") {
            return false;
        }

        for (const key in newObj) {
            if (Object.hasOwnProperty.call(newObj, key)) {
                if(curObj[key] === undefined){
                    return false;
                }
            }
        }
        for (const key in newObj) {
            if (Object.hasOwnProperty.call(newObj, key)) {                
                curObj[key] = newObj[key];
            }
        }

        return true
    }

    // принимает id и заменяет старый объект - новым
    replaceById(id, obj){
        this.#checkId(id);
        this.#checkObject(obj);

        if (obj["id"] && typeof obj["id"] !== "string") {
            return false;
        }

        for (const key in this.#storage) {
            if (Object.hasOwnProperty.call(this.#storage, key) &&
            this.#storage[key].id === id) {
                this.#storage[key] = Object.assign({id: id}, obj);
                return true;
            }
        }
        return false;
    }
    
    #checkId(id) {
        if (typeof id !== "string") {
            throw new Error ("ID должно быть только типа string ");
        }
    }
    #checkObject(obj) {
        if (typeof obj !== "object" || Array.isArray(obj)) {
            throw new Error ("В качестве объекта принимается только колекция");
        }
        // else if (obj["id"]) {
        //     throw new Error ("Объект не может содержать свойство Id");
        // }
    }

    
};
