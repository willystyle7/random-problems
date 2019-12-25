function colorCoding(firstRow, secondRow) {
    firstRow += ' ';
    secondRow += ' ';
    let pattern = '^' + firstRow.replace(/\) /g, ' )?') + '$';
    let regex = new RegExp(pattern);
    if (regex.test(secondRow)) {
        return true;
    } else {
        return false;
    }
}

function colorCodingSolution(args) {
    let n = args.shift();
    for (let i = 0; i < n; i++) {
        let firstRow = args.shift().trim().replace(/\s+/g, ' ');
        let secondRow = args.shift().trim().replace(/\s+/g, ' ');
        console.log(colorCoding(firstRow, secondRow));
    }

    function colorCoding(firstRow, secondRow) {
        firstRow += ' ';
        secondRow += ' ';
        let pattern = '^' + firstRow.replace(/\) /g, ' )?') + '$';
        let regex = new RegExp(pattern);
        if (regex.test(secondRow)) {
            return true;
        } else {
            return false;
        }
    }
}

colorCodingSolution([
    1,
    '(purple) (green) (purple) red blue',
    'green red blue'
]);

colorCodingSolution([
    2,
    '(blue) green (red) (blue)',
    'blue red blue',
    '(purple) red (blue) (yellow) blue (purple) (green) black',
    'red blue green black'
]);
