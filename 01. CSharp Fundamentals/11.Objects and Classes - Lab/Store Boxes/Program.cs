namespace Store_Boxes
{
    public class Item
    {
        public Item(string itemName, double itemPrice)
        {
            ItemName = itemName;
            ItemPrice = itemPrice;
         
        }

        public string ItemName { get; set; }
        public double ItemPrice { get; set; }
        public double PriceForTheBox { get; set; }
    }

    class Boxes
    {
        public Boxes(string serialNumber, Item item, int itemQuantity,double priceForTheBox)
        {
            SerialNumber = serialNumber;
            Item = item;
            ItemQuantity = itemQuantity;
            PriceForTheBox= priceForTheBox;
           
            

        }

        public string SerialNumber { get; set; }
        public string ItemName { get; set; }
        public int ItemQuantity { get; set; }
        public double PriceForTheBox { get; set; }
       
        public Item Item { get; set; }
        
        public override string ToString()
        {
            string result = $"-- {Item.ItemName} - ${Item.ItemPrice:f2}: {ItemQuantity}";
            return result;
        }

    }



    internal class Program
    {
        static void Main(string[] args)
        {
            string input = string.Empty;
            List<Boxes> BoxList = new List<Boxes>();
            while ((input = Console.ReadLine()) != "end")
            {
                List<string> data = input
                    .Split()
                    .ToList();
                string serialNumber = data[0];
                string itemName = data[1];
                int itemQuantity = int.Parse(data[2]);
                double itemPrice = double.Parse(data[3]);
                double boxPrice = itemQuantity * itemPrice;
                Item item = new Item(itemName, itemPrice);
                Boxes boxes = new Boxes(serialNumber, item, itemQuantity, boxPrice);
                BoxList.Add(boxes);
                





            }

            List<Boxes> sortedBoxesList = BoxList.OrderByDescending(box=> box.PriceForTheBox).ToList();
            foreach (Boxes box in sortedBoxesList)
            {
                Console.WriteLine($"{box.SerialNumber}");
                Console.WriteLine($"{box.ToString()}");
                Console.WriteLine($"-- ${box.PriceForTheBox:f2}");
            }
        }
    }

}