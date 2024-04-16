string[] input = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);
var cards = new List<Card>();
for (int i = 0; i < input.Length; i++)
{
    string[] currCardData = input[i].Split(" ", StringSplitOptions.RemoveEmptyEntries);
    string cardFace = currCardData[0];
    string cardSuit = currCardData[1];
    try
    {
        var card = new Card(cardFace, cardSuit);
        cards.Add(card);
    }
    catch (ArgumentException e)
    {
        Console.WriteLine(e.Message);
    }
}

Console.WriteLine(string.Join(" ",cards));




class Card
{
    private string face;
    private string suit;

    private List<string> validFaces = new List<string>()
    {
        "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A"
    };

    private List<string> validSuits = new List<string>()
    {
        "S", "H", "D", "C"
    };
    public Card(string face, string suit)
    {
        Face = face;
        Suit = suit;
    }

    public string Face
    {
        get => face;
        private set
        {
            if (!validFaces.Any(v=>v==value))
            {
                throw new ArgumentException($"Invalid card!");
            }
            face = value;
        }
    }

    public string Suit
    {
        get => suit;
        private set
        {
            if (!validSuits.Any(v => v == value))
            {
                throw new ArgumentException($"Invalid card!");
            }

            if (value == "S")
            {
                suit = "\u2660";
            }
            else if (value == "H")
            {
                suit = "\u2665";
            }
            else if (value == "D")
            {
                suit = "\u2666";
            }
            else if (value == "C")
            {
                suit = "\u2663";
            }
        }
    }
    public override string ToString()
    {
        return $"[{Face}{Suit}]";
    }
}