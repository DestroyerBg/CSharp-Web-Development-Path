function solve(input) {
    let towns = [];

    for (const line of input) {
        let [cityName, latitude, longLatitude] = line.split(' | ');
        let town = {
            town:cityName,
            latitude: Number(latitude).toFixed(2),
            longitude: Number(longLatitude).toFixed(2),
        }
        towns.push(town);
    }

    towns.forEach(t => console.log(t));
}

solve(['Sofia | 42.696552 | 23.32601',
'Beijing | 39.913818 | 116.363625']
)