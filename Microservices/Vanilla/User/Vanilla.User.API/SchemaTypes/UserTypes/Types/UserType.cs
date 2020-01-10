using GraphQL.Types;

namespace Vanilla.User.API.SchemaTypes.UserTypes.Types
{
    public class UserType : ObjectGraphType<Persistence.Models.User>
    {
        public UserType()
        {
            this.Field(x => x.Id);
            this.Field(x => x.Email);
            this.Field(x => x.Firstname);

            //TODO:Aggregate
        }
    }
}
