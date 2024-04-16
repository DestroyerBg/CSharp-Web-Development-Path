string[] data = Console.ReadLine().Split(",",StringSplitOptions.RemoveEmptyEntries);
var bankAccounts = new Dictionary<int,decimal>();
for (int i = 0; i < data.Length; i++)
{
    string[] currBankAccount = data[i].Split("-", StringSplitOptions.RemoveEmptyEntries);
    int bankAccountNumber = int.Parse(currBankAccount[0]);
    decimal balance = decimal.Parse(currBankAccount[1]);
    bankAccounts.Add(bankAccountNumber, balance);
}
string input = string.Empty;
while ((input = Console.ReadLine()) != "End")
{
    string[] tokens = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
    string instruction = tokens[0];
    try
    {
        if (instruction == "Withdraw")
        {
            int accountId = int.Parse(tokens[1]);
            decimal balance = decimal.Parse(tokens[2]);
            Withdraw(accountId, balance);
        }
        else if (instruction == "Deposit")
        {
            int accountId = int.Parse(tokens[1]);
            decimal balance = decimal.Parse(tokens[2]);
            Deposit(accountId, balance);
        }
        else
        {
            throw new ArgumentException();
        }

    }
    catch (KeyNotFoundException)
    {
        Console.WriteLine($"Invalid account!");
    }
    catch (ArgumentException)
    {
        Console.WriteLine($"Invalid command!");
    }
    catch (ArithmeticException)
    {
        Console.WriteLine($"Insufficient balance!");
    }
    finally
    {
        Console.WriteLine($"Enter another command");
    }
}

void Deposit(int accountId, decimal balance)
{
    if (!bankAccounts.ContainsKey(accountId))
    {
        throw new KeyNotFoundException();
    }
    bankAccounts[accountId] += balance;
    Console.WriteLine($"Account {accountId} has new balance: {bankAccounts[accountId]:f2}");
}

void Withdraw(int accountId, decimal balance)
{
    if (!bankAccounts.ContainsKey(accountId))
    {
        throw new KeyNotFoundException();
    }

    if (bankAccounts[accountId] < balance)
    {
        throw new ArithmeticException();
    }
    bankAccounts[accountId] -= balance;
    Console.WriteLine($"Account {accountId} has new balance: {bankAccounts[accountId]:f2}");
}
