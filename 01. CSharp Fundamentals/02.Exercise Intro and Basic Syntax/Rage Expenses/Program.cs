int lostGames=int.Parse(Console.ReadLine());
double headSetPrice = double.Parse(Console.ReadLine());
double mousePrice=double.Parse(Console.ReadLine());
double keyboardPrice=double.Parse(Console.ReadLine());
double displayPrice=double.Parse(Console.ReadLine());
int keyboardSmash = 0;
int headsetSmash = 0;
int mouseSmash = 0;
int displaySmash = 0;

for (int i = 1; i <= lostGames; i++)
{
	if (i%2==0)
	{
		headsetSmash++;
	}
	 if (i%3==0) 
	{
		mouseSmash++;
	}
	 if (i % 2 == 0 && i % 3 == 0)
	{
		keyboardSmash++;
		if (keyboardSmash%2==0)
		{
			displaySmash++;
		}
		
	}
	

}
headSetPrice = headsetSmash * headSetPrice;
mousePrice = mousePrice * mouseSmash;
keyboardPrice = keyboardPrice * keyboardSmash;
displayPrice = displayPrice * displaySmash;
double total= headSetPrice+mousePrice+keyboardPrice+displayPrice;
Console.WriteLine($"Rage expenses: {total:f2} lv.");
