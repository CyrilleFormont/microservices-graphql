using GraphQL.Types;
using Vanilla.Project.API.SchemaTypes.UserTypes.Types;

namespace Vanilla.Project.API.SchemaTypes.UserTypes
{
    public class UserQueries : ObjectGraphType
    {
        public UserQueries()
        {
            this.Field<ProjectType>("getUser",
                arguments:
                new QueryArguments(new QueryArgument<IntGraphType> {Name = "id"}),
                resolve:
                ctx => new Persistence.Models.Project
                {
                    Id = 1
                });
        }
    }
}
