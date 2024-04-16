List<int> playerOneDeck = Console
    .ReadLine()
    .Split()
    .Select(int.Parse)
    .ToList();
List<int> playerTwoDeck = Console
    .ReadLine()
    .Split()
    .Select(int.Parse)
    .ToList();
bool playerOneWon = false;
bool playerTwoWon = false;

while (playerOneDeck.Count > 0 && playerTwoDeck.Count > 0)
{
    for (int i = 0; i < playerOneDeck.Count; i++)
    {
        for (int k = 0; k < playerTwoDeck.Count; k++)
        {
            int playerOneCard = playerOneDeck[0];
            int playerTwoCard = playerTwoDeck[0];
            if (playerOneCard > playerTwoCard)
            {
                playerOneDeck.Add(playerTwoCard);
                playerOneDeck.Add(playerOneCard);
                playerOneDeck.RemoveAt(0);
                playerTwoDeck.RemoveAt(0);



            }
            else if (playerTwoCard > playerOneCard)
            {
                playerTwoDeck.Add(playerOneCard);
                playerTwoDeck.Add(playerTwoCard);
                playerOneDeck.RemoveAt(0);
                playerTwoDeck.RemoveAt(0);
            }
            else if (playerTwoCard == playerOneCard)
            {
                playerOneDeck.RemoveAt(0);
                playerTwoDeck.RemoveAt(0);
            }

            break;
        }
    }

    if (playerOneDeck.Count == 0)
    {
        playerTwoWon = true;
        break;
    }
    else if (playerTwoDeck.Count == 0)
    {
        playerOneWon = true;
        break;
    }

}

if (playerOneWon == true)
{
    int sum = 0;
    for (int i = 0; i < playerOneDeck.Count; i++)
    {
        sum += playerOneDeck[i];
    }

    Console.WriteLine($"First player wins! Sum: {sum}");

}
else if (playerTwoWon == true)
{
    int sum = 0;
    for (int i = 0; i < playerTwoDeck.Count; i++)
    {
        sum += playerTwoDeck[i];
    }

    Console.WriteLine($"Second player wins! Sum: {sum}");
}


