using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankLoan.Models;
using BankLoan.Models.Contracts;
using BankLoan.Repositories.Contracts;

namespace BankLoan.Repositories
{
    public class BankRepository : IRepository<IBank>
    {
        private List<IBank> banks;

        public BankRepository()
        {
            banks = new List<IBank>();
        }

        public IReadOnlyCollection<IBank> Models
        {
            get => banks;
        }
        public void AddModel(IBank model)
        {
            banks.Add(model);
        }

        public bool RemoveModel(IBank model)
        {
            if (banks.Remove(model))
            {
                return true;
            }
            return false;
        }

        public IBank FirstModel(string name)
        {
            if (banks.Any(b => b.Name == name))
            {
                return banks.First(b => b.Name == name);
            }
            return null;
        }
    }
}
