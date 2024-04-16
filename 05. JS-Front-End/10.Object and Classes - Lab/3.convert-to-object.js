function solve(json) {
    const object = JSON.parse(json);
    for (const key in object) {
        console.log(`${key}: ${object[key]}`);
    }
}
solve('{"name": "George", "age": 40, "town": "Sofia"}');