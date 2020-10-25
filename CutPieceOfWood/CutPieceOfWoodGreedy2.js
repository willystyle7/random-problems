// https://enigmaticcode.wordpress.com/2019/11/09/puzzle-29-how-many-strips/
// Greedy algorithm

// let matrix = [
//     ['0', 'X', 'X', 'X', 'X', 'X', '0', 'X'],
//     ['X', 'X', 'X', 'X', 'X', 'X', 'X', 'X'],
//     ['X', 'X', '0', 'X', 'X', 'X', 'X', 'X'],
//     ['X', 'X', 'X', 'X', 'X', 'X', 'X', 'X'],
//     ['X', '0', 'X', 'X', 'X', 'X', 'X', '0'],
//     ['X', 'X', 'X', 'X', 'X', '0', 'X', 'X'],
//     ['X', 'X', 'X', 'X', 'X', 'X', 'X', 'X'],
//     ['X', 'X', 'X', 'X', '0', 'X', 'X', 'X']
// ];

let matrix = [
    ['0', 'X', 'X', 'X', 'X'],
    ['X', 'X', 'X', 'X', '0'],
    ['X', 'X', '0', 'X', 'X'],
    ['X', 'X', 'X', 'X', 'X'],
    ['X', 'X', 'X', 'X', 'X']
];

// let matrix = [
//     ['0', 'X', 'X', 'X'],
//     ['X', 'X', 'X', 'X'],
//     ['X', 'X', '0', 'X'],
//     ['X', 'X', 'X', 'X']
// ];

// let matrix = [
//     ['0', 'X', 'X'],
//     ['X', 'X', 'X'],
//     ['X', 'X', '0']
// ];

solve(matrix);

function solve(matrix) {
    let matrixLen = matrix.length;
    let queue = [];
    queue.push({matrix: matrix, currentRow: 0, currentCol: 0, cuts: 0});
    let maxCuts = 0;
    let maxMatrix = [];
    let maxMatrices = [];
    while (queue.length > 0) {
        let obj = queue.shift();
        let tempMatrix = obj.matrix;
        let currentRow = obj.currentRow;
        let currentCol = obj.currentCol;
        let cuts = obj.cuts;
        if (checkFullMatrix(tempMatrix)) {
            if (cuts > maxCuts) {
                maxCuts = cuts;
                maxMatrix = tempMatrix;
                maxMatrices = [tempMatrix];
            } else if (cuts === maxCuts) {
                maxMatrices.push(tempMatrix);
            }
        } else {
            if (currentRow < matrixLen) {
                if (checkRightCut(currentRow, currentCol, tempMatrix)) {
                    let nextRow = currentRow;
                    let nextCol = currentCol + 1;
                    if (nextCol >= matrixLen) {
                        nextCol = 0;
                        nextRow++;
                    }
                    let newTempMatrix = JSON.parse(JSON.stringify(tempMatrix));
                    newTempMatrix[currentRow][currentCol] = (cuts + 1).toString();
                    newTempMatrix[currentRow][currentCol + 1] = (cuts + 1).toString();
                    newTempMatrix[currentRow][currentCol + 2] = (cuts + 1).toString();
                    queue.push({matrix: newTempMatrix, currentRow: nextRow, currentCol: nextCol, cuts: cuts + 1});
                }
                if (checkDownCut(currentRow, currentCol, tempMatrix)) {
                    let nextRow = currentRow;
                    let nextCol = currentCol + 3;
                    if (nextCol >= matrixLen) {
                        nextCol = 0;
                        nextRow++;
                    }
                    let newTempMatrix = JSON.parse(JSON.stringify(tempMatrix));
                    newTempMatrix[currentRow][currentCol] = (cuts + 1).toString();
                    newTempMatrix[currentRow + 1][currentCol] = (cuts + 1).toString();
                    newTempMatrix[currentRow + 2][currentCol] = (cuts + 1).toString();
                    queue.push({matrix: newTempMatrix, currentRow: nextRow, currentCol: nextCol, cuts: cuts + 1});
                }
                let nextRow = currentRow;
                let nextCol = currentCol + 1;
                if (nextCol >= matrixLen) {
                    nextCol = 0;
                    nextRow++;
                }
                let newTempMatrix = JSON.parse(JSON.stringify(tempMatrix));
                queue.push({matrix: newTempMatrix, currentRow: nextRow, currentCol: nextCol, cuts: cuts});
            }
        }
    }
    console.log('maxCuts: ', maxCuts);
    console.log('maxMatrix: ', maxMatrix);
    console.log('maxMatrices: ', maxMatrices);
}

function checkRightCut(row, col, matrix) {
    return col + 2 < matrix.length && matrix[row][col] === 'X' && matrix[row][col + 1] === 'X' && matrix[row][col + 2] === 'X';
}
function checkDownCut(row, col, matrix) {
    return row + 2 < matrix.length && matrix[row][col] === 'X' && matrix[row + 1][col] === 'X' && matrix[row + 2][col] === 'X';
}
function checkFullMatrix(matrix) {
    for (let i = 0; i < matrix.length; i++) {
        for (let j = 0; j < matrix.length; j++) {
            if (matrix[i][j] === 'X' && (checkRightCut(i, j, matrix) || checkDownCut(i, j, matrix))) {
                return false;
            }
        }
    }
    return true;
}

