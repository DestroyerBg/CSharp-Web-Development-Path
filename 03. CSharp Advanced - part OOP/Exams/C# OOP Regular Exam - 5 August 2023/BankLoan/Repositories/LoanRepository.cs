using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankLoan.Models.Contracts;
using BankLoan.Repositories.Contracts;

namespace BankLoan.Repositories
{
    public class LoanRepository : IRepository<ILoan>
    {
        private List<ILoan> loans;

        public LoanRepository()
        {
            loans = new List<ILoan>();
        }

        public IReadOnlyCollection<ILoan> Models
        {
            get => loans;
        }
        public void AddModel(ILoan model)
        {
            loans.Add(model);
        }

        public bool RemoveModel(ILoan model)
        {
            if (loans.Remove(model))
            {
                return true;
            }
            return false;
        }

        public ILoan FirstModel(string name)
        {
            if (loans.Any(l=>l.GetType().Name == name))
            {
                return loans.First(l => l.GetType().Name == name);
            }
            return null;
        }
    }
}
