function solve(input) {
    let films = [];
    
    for (let index = 0; index < input.length; index++) {
        let currentLine = input[index];
        let addMovieCommand = 'addMovie'
        let directedByCommand = ' directedBy ';
        let dateCommand = ' onDate ';
        if (currentLine.includes(addMovieCommand)){
            let movieName = currentLine.substring(addMovieCommand.length + 1);
            let movie = {
                name: movieName,
                director:undefined,
                date:undefined,
            }
            films.push(movie);
        }else if(currentLine.includes(directedByCommand)){
            let [movieName,directedBy] = currentLine.split(directedByCommand);
            let movie = films.find(s => s.name == movieName);
            if (movie) {
                movie.director = directedBy;
            }
        }else if(currentLine.includes(dateCommand)){
            let [movieName,date] = currentLine.split(dateCommand);
            let movie = films.find(s => s.name == movieName);
            if (movie) {
                movie.date = date;
            }
        }

    }

    let result = films.filter(f => {
        if (f.director != undefined && f.date != undefined) {
            return f;
        }
    }).forEach(f => console.log(JSON.stringify(f)));
    
    // for (const film of result) {
    //     const json = JSON.stringify(film);
    //     console.log(json);
    // }
}

solve([
    'addMovie Fast and Furious',
    'addMovie Godfather',
    'Inception directedBy Christopher Nolan',
    'Godfather directedBy Francis Ford Coppola',
    'Godfather onDate 29.07.2018',
    'Fast and Furious onDate 30.07.2018',
    'Batman onDate 01.08.2018',
    'Fast and Furious directedBy Rob Cohen'
]
)