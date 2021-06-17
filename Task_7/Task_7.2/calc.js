let str = "3.5 +4*10-5.3 /5 = ";

const expDigit =/([+\-\*\/]?\d+(\.\d+)?)|([=].*)/ig;

function calculate(str) {
    str = str.replace(/\s+/g,'').replace(/(?:=).+/,'=');

    if (str[str.length - 1] != '=') {
        throw new Error ("incorrect mathematical expression: have't '='");
    }
    let matchEx = str.match(/[^\d=\-+*/\.]/g);
    if (matchEx != null) {
        throw new Error ("incorrect mathematical expression: " + matchEx);
    }
    
    let me = str.match(expDigit);/*mathematical expression*/

    if (me == null || me[0][0] == '=') {
        throw new Error ("null expression");
    }
    if (me[0].match(/^[+-]?\d+(\.\d+)?/i) == null ) {
        throw new Error ("incorrect mathematical expression, wrong symbol at the beginning: " + me[0][0]);
    }            

    return mathExp(me);
}

/*'me' is mathematical expression*/
function mathExp([...me]) {
    let result = parseFloat(me[0]);
    for (let i = 1; i < me.length; i++) {
        switch (me[i][0]) {
            case '+':
                result +=parseFloat(me[i].substr(1, me[i].length)); 
                break;
            case '-':
                result -=parseFloat(me[i].substr(1, me[i].length)); 
                break;
            case '*':
                result *=parseFloat(me[i].substr(1, me[i].length)); 
                break;
            case '/':
                result /=parseFloat(me[i].substr(1, me[i].length)); 
                break;
            case '=':
                return result.toFixed(2);
        }
    }
}

console.log(calculate(str));