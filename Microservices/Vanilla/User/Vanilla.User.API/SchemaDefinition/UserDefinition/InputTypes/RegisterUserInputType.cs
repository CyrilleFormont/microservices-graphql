using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQL.Types;

namespace Vanilla.User.API.SchemaDefinition.UserDefinition.InputTypes
{
    public class RegisterUserInputType  : InputObjectGraphType<Persistence.Models.User>
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public RegisterUserInputType()
        {
            this.Field(c => c.Firstname);
            this.Field(c => c.Lastname);
        }
    }
}
