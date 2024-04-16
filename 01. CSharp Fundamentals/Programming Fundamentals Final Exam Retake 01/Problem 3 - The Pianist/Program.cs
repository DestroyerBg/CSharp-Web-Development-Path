using System.Security.Cryptography.X509Certificates;

namespace Problem_3___The_Pianist
{
    class Piece
    {
        public Piece(string pieceName, string composer, string key)
        {
            Composer = composer;
            Key = key;
            Name = pieceName;
        }

        public string Name { get; set; }
        public string Composer { get; set; }
        public string Key { get; set; }
        public override string ToString()
        {
            return $"{Name} -> Composer: {Composer}, Key: {Key}";
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfPieces= int.Parse(Console.ReadLine());
            List<Piece> piecesCollection = new List<Piece>();
            for (int i = 0; i < numberOfPieces; i++)
            {
                string[] input = Console
                    .ReadLine()
                    .Split("|")
                    .ToArray();
                string pieceName= input[0]; 
                string composer= input[1];
                string key = input[2];
                Piece newPiece= new Piece(pieceName, composer, key);
                piecesCollection.Add(newPiece);
            }

            string inputTwo = string.Empty;
            while ((inputTwo = Console.ReadLine()) != "Stop")
            {
                string[] input = inputTwo
                    .Split("|")
                    .ToArray();
                string argument= input[0];
                if (argument== "Add")
                {
                    string pieceName= input[1];
                    string composer= input[2];
                    string key = input[3];
                    Piece newPiece = new Piece(pieceName, composer, key);
                    bool checkIfPieceIsHere = PieceCheck(piecesCollection, newPiece);
                    if (checkIfPieceIsHere == true)
                    {
                        Console.WriteLine($"{pieceName} is already in the collection!");
                        continue;
                    }
                    else
                    {
                        piecesCollection.Add(newPiece);
                        Console.WriteLine($"{pieceName} by {composer} in {key} added to the collection!");
                        continue;
                    }

                }
                else if (argument== "Remove")
                {
                    string pieceName= input[1];
                    var check = piecesCollection.Find(x => x.Name == pieceName);
                    if (check!=null)
                    {
                        int findIndex= piecesCollection.FindIndex(x => x.Name==pieceName);
                        piecesCollection.RemoveAt(findIndex);
                        Console.WriteLine($"Successfully removed {pieceName}!");
                        continue;
                    }
                    else
                    {
                        Console.WriteLine($"Invalid operation! {pieceName} does not exist in the collection.");
                        continue;
                    }

                }
                else if (argument== "ChangeKey")
                {
                    string oldPieceName= input[1];
                    string newPieceName= input[2];
                    var check = piecesCollection.Find(x => x.Name == oldPieceName);
                    if (check != null)
                    {
                        piecesCollection.First(x=>x.Name==oldPieceName).Key=newPieceName;
                        Console.WriteLine($"Changed the key of {oldPieceName} to {newPieceName}!");
                        continue;
                    }
                    else
                    {
                        Console.WriteLine($"Invalid operation! {oldPieceName} does not exist in the collection.");
                        continue;
                    }
                }
            }

            foreach (var piece in piecesCollection)
            {
                Console.WriteLine($"{piece.ToString()}");
            }
        }

        public static bool PieceCheck(List<Piece> piecesCollection, Piece newPiece)
        {
            var check = piecesCollection.Find(x => x.Name == newPiece.Name);
            if (check!=null)
            {
                return true;
            }
            return false;   
        }
    }
}