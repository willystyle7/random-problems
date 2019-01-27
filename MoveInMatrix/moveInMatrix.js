function initMatrix(matr) {
    for (let i = 0; i < size; i++) {
        matr[i] = [];
        for (let j = 0; j < size; j++) {
            matr[i][j] = 0;    
        }    
    }
    matr[0][0] = 'X';
}

function printMatrix(matr) {
    for (let i = 0; i < size; i++) {
        console.log(matr[i].join(' '));
    }
}

function moveInMatrix(matr, row, col, counter, direction) {
    if ((row === 0 && col === 0) || matr[row][col] !== 0) {
        // console.log('No!');
        // printMatrix(matr);
        return;
    }
    matr[row][col] = counter;
    if (counter === size * size - 1) {
        console.log('Bingo!');
        printMatrix(matr);
        return;
    }
    switch (direction) {
        case 'up':
            for (let i = row - 2; i >= 0; i--) {
                moveInMatrix(JSON.parse(JSON.stringify(matr)), i, col, counter + 1, 'up');
            }
            for (let j = col + 2; j < size; j++) {
                moveInMatrix(JSON.parse(JSON.stringify(matr)), row, j, counter + 1, 'right');
            }
            break;
        case 'down':
            for (let i = row + 2; i < size; i++) {
                moveInMatrix(JSON.parse(JSON.stringify(matr)), i, col, counter + 1, 'down');
            }
            for (let j = col - 2; j >= 0; j--) {
                moveInMatrix(JSON.parse(JSON.stringify(matr)), row, j, counter + 1, 'left');
            }
            break;
        case 'left':
            for (let i = row - 2; i >= 0; i--) {
                moveInMatrix(JSON.parse(JSON.stringify(matr)), i, col, counter + 1, 'up');
            }
            for (let j = col - 2; j >= 0; j--) {
                moveInMatrix(JSON.parse(JSON.stringify(matr)), row, j, counter + 1, 'left');
            }
            break;
        case 'right':
            for (let i = row + 2; i < size; i++) {
                moveInMatrix(JSON.parse(JSON.stringify(matr)), i, col, counter + 1, 'down');
            }
            for (let j = col + 2; j < size; j++) {
                moveInMatrix(JSON.parse(JSON.stringify(matr)), row, j, counter + 1, 'right');
            }
            break;
        default:
            break;
    }
}

let matrix = [];
let size = 5;
initMatrix(matrix);
let initRow = 3;
let initCol = 1;
let initCounter = 1;
moveInMatrix(matrix, initRow, initCol, initCounter, 'up');
moveInMatrix(matrix, initRow, initCol, initCounter, 'down');
moveInMatrix(matrix, initRow, initCol, initCounter, 'left');
moveInMatrix(matrix, initRow, initCol, initCounter, 'right');