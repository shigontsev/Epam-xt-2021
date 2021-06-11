let str = "3.5 +4*10-5.3 /5 = ";

const expDigit =/([+\-\*\/]?\d+(\.\d+)?)|([=].*)/ig;

function Calculate(str) {
    str = str.replace(/\s+/g,'').replace(/(?:=).+/,'=');

    if (str[str.length - 1] != '=') {
        new Error ("incorrect mathematical expression: have't '='");
    }
    let matchEx = str.match(/[^\d=\-+*/\.]/g);
    if (matchEx != null) {
        new Error ("incorrect mathematical expression: " + matchEx);
    }

    let ms = str.match(expDigit);

    if (ms == null || ms[0][0] == '=') {
        new Error ("null expression");
    }
    if (ms[0].match(/^[+-]?\d+(\.\d+)?/i) == null ) {
                new Error ("incorrect mathematical expression, wrong symbol at the beginning: " + ms[0][0]);
    }            

    return MathExp(ms);
}

function MathExp([...ms]) {
    let result = parseFloat(ms[0]);
    for (let i = 1; i < ms.length; i++) {
        switch (ms[i][0]) {
            case '+':
                result +=parseFloat(ms[i].substr(1, ms[i].length)); 
                break;
            case '-':
                result -=parseFloat(ms[i].substr(1, ms[i].length)); 
                break;
            case '*':
                result *=parseFloat(ms[i].substr(1, ms[i].length)); 
                break;
            case '/':
                result /=parseFloat(ms[i].substr(1, ms[i].length)); 
                break;
            case '=':
                return result.toFixed(2);
        }
    }
}

console.log(Calculate(str));