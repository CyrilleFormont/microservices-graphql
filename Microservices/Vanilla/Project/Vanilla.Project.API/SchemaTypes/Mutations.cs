using GraphQL.Types;
using Vanilla.Project.API.SchemaTypes.ProjectTypes;

namespace Vanilla.Project.API.SchemaTypes
{
    public class Mutations : ObjectGraphType
    {
        public Mutations(ProjectMutations userMutations)
        {
            this.Field<ProjectMutations>("userMutations", resolve: ctx => userMutations);
        }
    }
}
