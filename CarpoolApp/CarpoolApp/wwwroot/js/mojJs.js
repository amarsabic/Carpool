/*TYPING EFFECT START*/

var i = 0,
    text;
text = 'Ponudi. Pronađi. Vozi se.';


function typingEffect() {
    if (i < text.length) {
        document.getElementById('naslovPretrazi').innerHTML += text.charAt(i);
        i++;
        setTimeout(typingEffect, 70);
    }
}

typingEffect();

/*TYPING EFFECT END*/

