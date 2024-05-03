using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheContentDepartment.Core.Contracts;
using TheContentDepartment.Models;
using TheContentDepartment.Models.Contracts;
using TheContentDepartment.Repositories;
using TheContentDepartment.Repositories.Contracts;
using TheContentDepartment.Utilities.Messages;

namespace TheContentDepartment.Core
{
    public class Controller : IController
    {
        private IRepository<IResource> resources;
        private IRepository<ITeamMember> members;
        public Controller()
        {
            resources = new ResourceRepository();
            members = new MemberRepository();
        }
        public string JoinTeam(string memberType, string memberName, string path)
        {
            string[] allowedMemberTypes = new string[] { "TeamLead", "ContentMember" };
            if (!allowedMemberTypes.Contains(memberType))
            {
                return string.Format(OutputMessages.MemberTypeInvalid,memberType);
            }

          
            if (members.Models.Any(x => x.Path == path))
            {
                return string.Format(OutputMessages.PositionOccupied);
            }

            var searchMemberByName = members.Models.FirstOrDefault(x => x.Name == memberName);
            if (searchMemberByName != null)
            {
                return string.Format(OutputMessages.MemberExists, memberName);
            }

            ITeamMember newMember;
            if (memberType == "TeamLead")
            {
                newMember = new TeamLead(memberName, path);
                members.Add(newMember);
            }
            else if (memberType == "ContentMember")
            {
                newMember = new ContentMember(memberName, path);
                members.Add(newMember);
            }

            return string.Format(OutputMessages.MemberJoinedSuccessfully, memberName);
        }

        public string CreateResource(string resourceType, string resourceName, string path)
        {
            string[] allowedResourceTypes = new string[] { "Exam", "Workshop", "Presentation" };

            if (!allowedResourceTypes.Contains(resourceType))
            {
                return string.Format(OutputMessages.ResourceTypeInvalid, resourceType);
            }

            var responsibleContentMember = members.Models.FirstOrDefault(x => x.Path == path);

            if (responsibleContentMember == null)
            {
                return string.Format(OutputMessages.NoContentMemberAvailable, resourceName);
            }

            if (responsibleContentMember.InProgress.Contains(resourceName))
            {
                return string.Format(OutputMessages.ResourceExists, resourceName);
            }

            IResource newResource;
            if (resourceType == "Exam")
            {
                newResource = new Exam(resourceName, responsibleContentMember.Name);
                responsibleContentMember.WorkOnTask(resourceName);
                resources.Add(newResource);
            }
            else if (resourceType == "Workshop")
            {
                newResource = new Workshop(resourceName, responsibleContentMember.Name);
                responsibleContentMember.WorkOnTask(resourceName);
                resources.Add(newResource);
            }
            else if (resourceType == "Presentation")
            {
                newResource = new Presentation(resourceName, responsibleContentMember.Name);
                responsibleContentMember.WorkOnTask(resourceName);
                resources.Add(newResource);
            }
           

            return string.Format(OutputMessages.ResourceCreatedSuccessfully,responsibleContentMember.Name, resourceType, resourceName);

        }

        public string LogTesting(string memberName)
        {
            if (members.Models.Any(m => m.Name == memberName) == false)
            {
                return string.Format(OutputMessages.WrongMemberName);
            }

            var searchMember = members.Models.FirstOrDefault(m => m.Name == memberName);
            IResource? resource = resources.Models
                .Where(r => r.IsTested == false && r.Creator == memberName)
                .MinBy(r => r.Priority);
            if (resource == null)
            {
                return string.Format(OutputMessages.NoResourcesForMember, memberName);
            }

            var teamLead = members.Models.First(t => t.GetType().Name == "TeamLead");
            resource.Test();
            searchMember.FinishTask(resource.Name);
            teamLead.WorkOnTask(resource.Name);
            return string.Format(OutputMessages.ResourceTested,resource.Name);
        }
        

        public string ApproveResource(string resourceName, bool isApprovedByTeamLead)
        {
            var resource = resources.Models.First(r => r.Name == resourceName);
            if (resource.IsTested == false)
            {
                return string.Format(OutputMessages.ResourceNotTested, resource.Name);
            }

            var teamLead = members.Models.First(s => s.GetType().Name == "TeamLead");
            if (isApprovedByTeamLead == true)
            {
                resource.Approve();
                teamLead.FinishTask(resource.Name);
                return string.Format(OutputMessages.ResourceApproved, teamLead.Name, resource.Name);
            }
            else
            {
                resource.Test();
                return string.Format(OutputMessages.ResourceReturned,teamLead.Name, resource.Name);
            }
        }

        public string DepartmentReport()
        {
            var approvedResources = resources.Models.Where(r => r.IsApproved == true);
            var teamLead = members.Models.First(r => r.GetType().Name == "TeamLead");
            var contentMembers = members.Models.Where(r => r.GetType().Name != "TeamLead");
            StringBuilder result = new StringBuilder();
            result.AppendLine($"Finished Tasks:");
            foreach (var resource in approvedResources)
            {
                result.AppendLine($"--{resource.ToString()}");
            }

            result.AppendLine($"Team Report:");
            result.AppendLine(
                $"--{teamLead.Name} (TeamLead) - Currently working on {teamLead.InProgress.Count} tasks.");
            foreach (var contentMember in contentMembers)
            {
                result.AppendLine(contentMember.ToString());
            }
            
            return result.ToString().TrimEnd();
        }
    }
}
