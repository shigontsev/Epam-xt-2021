function Service(){
    // let data = { number: 0};
    let content = [{id:"1",value: 123},{id: "2", value: 12443}];
    // let length = content.length;

    return {
        // sum: function(n){
        //     data.number += n;
        // },
        // subtract: function(n){
        //     data.number -= n;
        // },
        // display: function(){
        //     console.log("Result: ", data.number);
        // }

        //принимает объект и позволяет добавить его в коллекцию
        add: function(item){
            // data.number += n;
            content.push(item);
            // content.push({id:"3",value: item});
        },
        //принимает id и возвращает найденный объект или NULL если не найден
        getById: function(id){
            // data.number += n;
            for (const obj of content) {
                if (obj.id == id) {
                    // return obj.value;
                    return obj;
                }
            }
            return null
        },
        //возвращает весь массив объектов
        getAll: function(){
            // data.number += n;
            return content.slice();
            // return new Object(content);
        },
        //принимает id и возвращает удаленный объект
        deleteById: function(id){
            // data.number += n;
            
            // let index = null;
            let value = null;
            // for (const obj of content) {
            //     if (obj.id == id) {
            //         value = obj.value.;
            //         break;
            //     }
            //     index++;
            // }
            // return value != null?
            //      ()=>{content[index]}
            // return null

            // for (const obj of content) {
            //     if (obj.id == id) {
            //         value = obj.value;
            //         content.splice(id);                  
            //         break;
            //     }
            // }
            for (const key in content) {
                if (Object.hasOwnProperty.call(content, key) && content[key].id == id) {
                    value = content[key];
                    content.splice(key, 1);
                    break;
                }
            }

            return value;
        },
        // принимает id первым параметром и объект-вторым. Обновляет поля объекта
        //новыми значениями
        updateById: function(id, item){
            // data.number += n;
        },
        // принимает id и заменяет старый объект - новым
        replaceById: function(id){
            // data.number += n;
        },
    }
};
var storage = new Service();