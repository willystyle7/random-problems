var fs = require('fs');
var dictionary = [];
fs.readFile('./Bulgarian.dic', 'utf-8', function(error, data) {
    // console.log(data);
    // console.log(typeof data);
    dictionary = data.split(/\s+/g);
    // console.log(dictionary);

    let words = ['компромат', 'ескалатор', 'гастроном', 'сарабанда', 'скулптура', 'красавица', 'полицайка', 'прибиране', 'лястовица'];
    let targerWords = [];
    for (let i1 = 0; i1 <= 8; i1++) {
        for (let i2 = 0; i2 <= 8; i2++) {
            for (let i3 = 0; i3 <= 8; i3++) {
                for (let i4 = 0; i4 <= 8; i4++) {
                    for (let i5 = 0; i5 <= 8; i5++) {
                        for (let i6 = 0; i6 <= 8; i6++) {
                            for (let i7 = 0; i7 <= 8; i7++) {
                                for (let i8 = 0; i8 <= 8; i8++) {
                                    for (let i9 = 0; i9 <= 8; i9++) {
                                        let arr = [i1, i2, i3, i4, i5, i6, i7, i8, i9];
                                        let uniqueArr = [...new Set(arr)];
                                        if (arr.length === uniqueArr.length) {
                                            let word = '';
                                            for (let i = 0; i < arr.length; i++) {
                                                word += words[i][arr[i]];
                                            }
                                            if (dictionary.includes(word)) {
                                                targerWords.push(word);
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    }
    console.log(targerWords.length);
    console.log(targerWords);
});


// require("fs").writeFile(
//     './words.txt',
//     targerWords.join(', '),
//     function (err) { console.log(err ? 'Error :' + err : 'ok') }
// );