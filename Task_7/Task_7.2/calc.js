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
    
    let mathExpr = str.match(expDigit);/*mathematical expression*/

    if (mathExpr == null || mathExpr[0][0] == '=') {
        throw new Error ("null expression");
    }
    if (mathExpr[0].match(/^[+-]?\d+(\.\d+)?/i) == null ) {
        throw new Error ("incorrect mathematical expression, wrong symbol at the beginning: " + mathExpr[0][0]);
    }            

    return solveMathExp(mathExpr);
}

/*'mathExpr' is mathematical expression*/
function solveMathExp([...mathExpr]) {
    let result = parseFloat(mathExpr[0]);
    for (let i = 1; i < mathExpr.length; i++) {
        switch (mathExpr[i][0]) {
            case '+':
                result +=parseFloat(mathExpr[i].substr(1, mathExpr[i].length)); 
                break;
            case '-':
                result -=parseFloat(mathExpr[i].substr(1, mathExpr[i].length)); 
                break;
            case '*':
                result *=parseFloat(mathExpr[i].substr(1, mathExpr[i].length)); 
                break;
            case '/':
                result /=parseFloat(mathExpr[i].substr(1, mathExpr[i].length)); 
                break;
            case '=':
                return result.toFixed(2);
        }
    }
}

console.log(calculate(str));