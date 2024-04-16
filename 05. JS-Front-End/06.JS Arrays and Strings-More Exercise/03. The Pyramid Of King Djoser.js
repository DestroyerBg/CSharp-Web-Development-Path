function solve(base,increment) {
    let [height,stoneRequired, goldRequired, marbleRequired, lapisRequired ] = [0,0,0,0,0,0]; 
    while (base > 0) {
        height++;
        if (base - 2 > 0) {
            stoneRequired += ((base-2) * (base-2)) 
            let otherMaterial = ((4*base) - 4)
            if (height % 5 == 0) {
                lapisRequired+=otherMaterial;
            }
            else{ 
                marbleRequired+=otherMaterial;
            }
        } 
        else{
            goldRequired += base*base;
        }
        base-=2;
    }
    
    console.log(`Stone required: ${Math.ceil(stoneRequired*increment)}`);
    console.log(`Marble required: ${Math.ceil(marbleRequired*increment)}`);
    console.log(`Lapis Lazuli required: ${Math.ceil(lapisRequired*increment)}`);
    console.log(`Gold required: ${Math.ceil(goldRequired*increment)}`);
    console.log((`Final pyramid height: ${Math.floor(height*increment)}`));
}

// solve(11,1);
// solve(11,0.75);
// solve(12,1);
solve(23,0.5);