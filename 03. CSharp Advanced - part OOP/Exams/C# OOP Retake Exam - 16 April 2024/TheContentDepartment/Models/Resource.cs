using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using TheContentDepartment.Models.Contracts;
using TheContentDepartment.Utilities.Messages;

namespace TheContentDepartment.Models
{
    public abstract class Resource : IResource
    {
        private string name;
        private bool isTested = false;
        private bool isApproved = false;

        public Resource(string name, string creator, int priority)
        {
            Name = name;
            Creator = creator;
            Priority = priority;
        }
        public string Name {
            get
            {
                return name;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.NameNullOrWhiteSpace);
                }
                name = value;
            }
        }

        public string Creator { get; private set; }

        public int Priority { get; private set; }

        public bool IsTested
        {
            get
            {
                return isTested;
            }
        }

        public bool IsApproved
        {
            get
            {
                return isApproved;
            }
        }

        public void Test()
        {
            if (isTested == false)
            {
                isTested = true;
            }
            else
            {
                isTested = false;
            }
        }

        public void Approve()
        {
            isApproved = true;
        }

        public override string ToString()
        {
            return $"{Name} ({this.GetType().Name}), Created By: {Creator}";
        }
    }
}
