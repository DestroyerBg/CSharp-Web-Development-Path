string username = Console.ReadLine();
string password = string.Empty;
bool isFailed = false;
int fails = 0;
for (int i = username.Length-1; i >= 0; i--)
{
    password += username[i];
}
while (true)
{
    string input = Console.ReadLine();
    if (password == input)
    {
        Console.WriteLine($"User {username} logged in.");
        break;

    }
    else
    {
        fails++;
        if (fails == 4)
        {
            isFailed = true;
            break;

        }
        Console.WriteLine("Incorrect password. Try again.");
        

    }
    
    continue;

}
if (isFailed == true)
{
    Console.WriteLine($"User {username} blocked!");
}
