using System.Collections.Generic;
using GraphQL.Types;
using MessageBrokerDtos.Project;
using MicroserviceCommunicator;
using Vanilla.Project.Persistence.Enumerators;
using Vanilla.Project.Persistence.Models;

namespace Vanilla.Project.API.SchemaTypes.UserTypes
{
    public class ProjectMutations : BaseMutation
    {
        
        public ProjectMutations(IMessageBrokerSender mbs) : base(mbs)
        {
            this.Field<BooleanGraphType>("abc", resolve: ctx => true);
            this.Field<BooleanGraphType>("createProject", resolve: this.CreateProject);
        }

        public object CreateProject(ResolveFieldContext<object> ctx)
        {
            var createdProject = new Persistence.Models.Project
            {
                Id = 18,
                IconId = "icon",
                Name = "name",
                Identifier = "identifier",
                UsersProjects = new List<UserProject>
                {
                    new UserProject
                    {
                        Rights = EUserRight.Administrate,
                        UserId = 10
                    }
                }
            };

            base.mbs.SendMessage(nameof(ProjectCreatedEvent), new ProjectCreatedEvent(createdProject.Id, 10));

            return true;
        }
    }
}
