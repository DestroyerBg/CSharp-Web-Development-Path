using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankLoan.Core.Contracts;
using BankLoan.Models;
using BankLoan.Models.Contracts;
using BankLoan.Repositories;
using BankLoan.Utilities.Messages;

namespace BankLoan.Core
{
    public class Controller : IController
    {
        private LoanRepository loans;
        private BankRepository banks;
        public Controller()
        {
            loans = new LoanRepository();
            banks = new BankRepository();
        }
        public string AddBank(string bankTypeName, string name)
        {
            string[] allowedBankTypes = new string[] { "BranchBank", "CentralBank" };
            if (!allowedBankTypes.Contains(bankTypeName))
            {
                throw new ArgumentException(ExceptionMessages.BankTypeInvalid);
            }

            IBank bank = null;
            if (bankTypeName == "BranchBank")
            {
                bank = new BranchBank(name);
            }
            else if (bankTypeName == "CentralBank")
            {
                bank = new CentralBank(name);
            }
            banks.AddModel(bank);
            return string.Format(OutputMessages.BankSuccessfullyAdded, bankTypeName);
        }

        public string AddLoan(string loanTypeName)
        {
            string[] allowedLoanTypes = new string[] { "StudentLoan", "MortgageLoan" };
            if (!allowedLoanTypes.Contains(loanTypeName))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.LoanTypeInvalid));
            }
            ILoan loan = null;
            if (loanTypeName == "StudentLoan")
            {
                loan = new StudentLoan();
            }
            else if (loanTypeName == "MortgageLoan")
            {
                loan = new MortgageLoan();
            }
            loans.AddModel(loan);
            return string.Format(OutputMessages.LoanSuccessfullyAdded, loanTypeName);
        }

        public string ReturnLoan(string bankName, string loanTypeName)
        {
            ILoan loan = loans.FirstModel(loanTypeName);
            if (loan == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.MissingLoanFromType,loanTypeName));
            }
            loans.RemoveModel(loan);
            banks.FirstModel(bankName).AddLoan(loan);
            return string.Format(OutputMessages.LoanReturnedSuccessfully,loanTypeName,bankName);
        }

        public string AddClient(string bankName, string clientTypeName, string clientName, string id, double income)
        {
            string[] allowedClientTypes = new string[] { "Student", "Adult" };
            if (!allowedClientTypes.Contains(clientTypeName))
            {
                throw new ArgumentException(ExceptionMessages.ClientTypeInvalid);
            }
            
            IBank bank = banks.Models.First(b=>b.Name == bankName);
            IClient client = null;
            if (clientTypeName == "Student")
            {
                client = new Student(clientName, id, income);
            }
            else if (clientTypeName == "Adult")
            {
                client = new Adult(clientName, id, income);
            }

            if (bank is BranchBank && client is Student)     
            {
                banks.FirstModel(bankName).AddClient(client);
                return string.Format(OutputMessages.ClientAddedSuccessfully, clientTypeName, bankName);
            }
            else if (bank is CentralBank && client is Adult)
            {
                banks.FirstModel(bankName).AddClient(client);
                return string.Format(OutputMessages.ClientAddedSuccessfully, clientTypeName, bankName);
            }

            return string.Format(OutputMessages.UnsuitableBank);

        }

        public string FinalCalculation(string bankName)
        {
            IBank bank = banks.FirstModel(bankName);
            double funds = bank.Clients.Sum(c => c.Income) + bank.Loans.Sum(l =>l.Amount);
            return string.Format(OutputMessages.BankFundsCalculated, bankName, $"{funds:f2}");
        }

        public string Statistics()
        {
            StringBuilder result = new StringBuilder();
            foreach (var bank in banks.Models)
            {
                result.AppendLine(bank.GetStatistics());
            }
            return result.ToString().TrimEnd();
        }
    }
}
