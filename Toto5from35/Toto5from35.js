function sortArray2(arr, obj){
    return arr.map(num => obj[num] == undefined ? obj[num] = 1 : obj[num]++) && obj;    
}

function sortMap(arr, map){    
    return arr.map(num => map.has(num) ? map.set(num, map.get(num) + 1) : map.set(num, 1)) && new Map([...map.entries()].sort((a, b) => b[1] - a[1]));    
}
    
console.log(sortMap([2, 18, 20, 26, 28,
    8, 19, 23, 25, 34,
    1, 17, 23, 29, 35,
    10, 21, 23, 24, 25,
    2, 3, 19, 29, 34,
    12, 20 ,21, 28, 29,
    7, 24, 26, 27, 28,
    1, 3, 11, 21, 26,
    9, 12, 13, 23, 27,
    8, 11, 24, 31, 32,
    2, 18, 27, 30, 35], new Map()));
