function solve(text) {
    let pattern = /(?=[A-Z])/g;
    let result = text.split(pattern).join(', ');
    console.log(result);
}

solve('SplitMeIfYouCanHaHaYouCantOrYouCan');
solve('HoldTheDoor');
solve('ThisIsSoAnnoyingToDo');