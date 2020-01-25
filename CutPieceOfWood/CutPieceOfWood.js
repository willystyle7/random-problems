// https://enigmaticcode.wordpress.com/2019/11/09/puzzle-29-how-many-strips/
// TODO need to use greed algorithm

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
    queue.push(matrix);
    let maxCuts = 0;
    let maxMatrix = [];
    let turn = 0;
    while (queue.length > 0) {
        turn++;
        console.log('turn: ', turn);
        // console.log('queue: ', queue);
        let len = queue.length;
        for (let n = 0; n < len; n++) {
            let tempMatrix = queue.shift();
            if (checkFullMatrix(tempMatrix)) {
                if (turn > maxCuts) {
                    maxCuts = turn - 1;
                    maxMatrix = tempMatrix;
                }
            } else {
                for (let i = 0; i < matrixLen; i++) {
                    for (let j = 0; j < matrixLen; j++) {
                        if (tempMatrix[i][j] === 'X') {
                            // if (checkLeftCut(i, j, tempMatrix)) {
                            //     let newTempMatrix = JSON.parse(JSON.stringify(tempMatrix));
                            //     newTempMatrix[i][j] = turn.toString();
                            //     newTempMatrix[i][j - 1] = turn.toString();
                            //     newTempMatrix[i][j - 2] = turn.toString();
                            //     queue.push(newTempMatrix);
                            // }
                            if (checkRightCut(i, j, tempMatrix)) {
                                let newTempMatrix = JSON.parse(JSON.stringify(tempMatrix));
                                newTempMatrix[i][j] = turn.toString();
                                newTempMatrix[i][j + 1] = turn.toString();
                                newTempMatrix[i][j + 2] = turn.toString();
                                queue.push(newTempMatrix);
                            }
                            // if (checkUpCut(i, j, tempMatrix)) {
                            //     let newTempMatrix = JSON.parse(JSON.stringify(tempMatrix));
                            //     newTempMatrix[i][j] = turn.toString();
                            //     newTempMatrix[i - 1][j] = turn.toString();
                            //     newTempMatrix[i - 2][j] = turn.toString();
                            //     queue.push(newTempMatrix);
                            // }
                            if (checkDownCut(i, j, tempMatrix)) {
                                let newTempMatrix = JSON.parse(JSON.stringify(tempMatrix));
                                newTempMatrix[i][j] = turn.toString();
                                newTempMatrix[i + 1][j] = turn.toString();
                                newTempMatrix[i + 2][j] = turn.toString();
                                queue.push(newTempMatrix);
                            }
                        }
                    }
                }
            }
        }
    }
    console.log('maxCuts: ', maxCuts);
    console.log('maxMatrix: ', maxMatrix);
}

// function checkLeftCut(row, col, matrix) {
//     return col - 2 >= 0 && matrix[row][col - 1] === 'X' && matrix[row][col - 2] === 'X';
// }
function checkRightCut(row, col, matrix) {
    return col + 2 < matrix.length && matrix[row][col + 1] === 'X' && matrix[row][col + 2] === 'X';
}
// function checkUpCut(row, col, matrix) {
//     return row - 2 >= 0 && matrix[row - 1][col] === 'X' && matrix[row - 2][col] === 'X';
// }
function checkDownCut(row, col, matrix) {
    return row + 2 < matrix.length && matrix[row + 1][col] === 'X' && matrix[row + 2][col] === 'X';
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
