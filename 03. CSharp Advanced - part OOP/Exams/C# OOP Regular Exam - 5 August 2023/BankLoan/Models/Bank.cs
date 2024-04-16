using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankLoan.Models.Contracts;
using BankLoan.Utilities.Messages;

namespace BankLoan.Models
{
    public abstract class Bank : IBank
    {
        private string name;
        private List<ILoan> loans;
        private List<IClient> clients;

        protected Bank(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            loans = new List<ILoan>();
            clients = new List<IClient>();
        }
        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.BankNameNullOrWhiteSpace);
                }
                name = value;
            }
        }
        public int Capacity { get; private set; }

        public IReadOnlyCollection<ILoan> Loans => loans.AsReadOnly();
        

        public IReadOnlyCollection<IClient> Clients => clients.AsReadOnly();
        
        public double SumRates()
        {
            return Loans.Sum(l =>l.InterestRate);
        }

        public void AddClient(IClient Client)
        {
            if (Clients.Count < Capacity)
            {
                clients.Add(Client);
                return;
            }

            throw new ArgumentException(ExceptionMessages.NotEnoughCapacity);
        }

        public void RemoveClient(IClient Client)
        {
            clients.Remove(Client);
        }

        public void AddLoan(ILoan loan)
        {
            loans.Add(loan);
        }

        public string GetStatistics()
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine($"Name: {Name}, Type: {GetType().Name}");
            if (Clients.Count > 0)
            {
                string clientsList = string.Join(", ", Clients.Select(s=>s.Name));
                result.AppendLine($"Clients: {clientsList}");
            }
            else
            {
                result.AppendLine($"Clients: none");
            }

            result.AppendLine($"Loans: {loans.Count}, Sum of Rates: {SumRates()}");
            return result.ToString().TrimEnd();
        }
    }
}
