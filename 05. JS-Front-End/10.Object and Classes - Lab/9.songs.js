function solve(input) {
    let songs = [];
    class Song{
        constructor(typelist, name, time){
            this.typelist = typelist;
            this.name = name;
            this.time = time;
        }
    }

    for (let index = 1; index < input.length - 1; index++) {
        let [typelist, name, time ] = input[index].split('_');
        let song = new Song(typelist,name,time);
        songs.push(song);    
    }

    let typelist = input[input.length-1];
    if (typelist == 'all') {
        songs.forEach(s => console.log(s.name));
    } else{
        for (const song of songs.filter(s => s.typelist == typelist)) {
            console.log(song.name);
        }
    }
}

solve([4,
    'favourite_DownTown_3:14',
    'listenLater_Andalouse_3:24',
    'favourite_In To The Night_3:58',
    'favourite_Live It Up_3:48',
    'listenLater']
    
    );

