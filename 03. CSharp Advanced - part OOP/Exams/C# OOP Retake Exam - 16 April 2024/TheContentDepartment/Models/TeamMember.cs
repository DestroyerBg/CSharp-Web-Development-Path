using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheContentDepartment.Models.Contracts;
using TheContentDepartment.Utilities.Messages;

namespace TheContentDepartment.Models
{
    public abstract class TeamMember : ITeamMember
    {
        private string name;
        private List<string> inProgress;

        public TeamMember(string name, string path)
        {
            inProgress = new List<string>();
            Name = name;
            Path = path;
        }
        public string Name {
            get
            {
                return name;
            }
            private set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.NameNullOrWhiteSpace);
                }
                name = value;
            }
        }

        public string Path { get; protected set; }

        public IReadOnlyCollection<string> InProgress
        {
            get
            {
                return inProgress.AsReadOnly();
            }
        }

        public void WorkOnTask(string resouceName)
        {
            inProgress.Add(resouceName);
        }

        public void FinishTask(string resouceName)
        {
            var resource = inProgress.Find(r => r == resouceName);
            if (resource != null)
            {
                inProgress.Remove(resouceName);
            }
        }
    }
}
