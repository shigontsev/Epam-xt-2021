let textInput = "У попа! была, собака?";

const separator = [...' \t\n?!:;,.'];

function SubString(text) {
    let words = [];
    let lengthSub = 0;
    for (let index = 0; index < text.length; index++) {
        if (lengthSub > 0 && separator.includes(text[index])) {
            words[words.length] = text.substr(index - lengthSub, lengthSub);
            lengthSub = 0;
        }
        if (!separator.includes(text[index])) {
            lengthSub++;
        }
    }
    if (lengthSub > 0) {
        words[words.length] = text.substr(text.length  - lengthSub, lengthSub)
    }

    return words;
}

function GetCharDub(words) {
    let dubChars = [];
    for (const word of words) {
        for (let i = 0; i < word.length - 1; i++) {
            if (!dubChars.includes(word[i]) && word.includes(word[i], i + 1)) {
                dubChars[dubChars.length] = word[i];
            }     
        }
    }

    return dubChars;
}

function ReplaceDubChars(text) {
    let words = SubString(text);
    let dubChars = GetCharDub(words);

    let new_text = [...text];
            
    for (let i = 0; i < new_text.length; i++) {
        if (dubChars.includes(new_text[i])) {
            new_text[i] = '';
        }
    }            
            
    return new_text.join('');
}

console.log(ReplaceDubChars(textInput));
