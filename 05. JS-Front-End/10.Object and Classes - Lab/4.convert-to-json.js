function solve(name,lastName,hairColor) {
    const object = {
        name,
        lastName,
        hairColor,
    }
    const json = JSON.stringify(object);
    console.log(json);
}

solve('George', 'Jones', 'Brown')