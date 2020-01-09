using System;
using System.Threading.Tasks;
using GraphQL;
using GraphQL.Types;
using Microsoft.AspNetCore.Mvc;
using Vanilla.User.API.SchemaTypes;

namespace Vanilla.User.API
{
    [ApiController]
    [Route("graphql")]
    public class GraphQLController : Controller
    {
        private readonly ISchema _schema;
        private readonly IDocumentExecuter _documentExecuter;

        public GraphQLController(ISchema schema, IDocumentExecuter documentExecuter)
        {
            this._documentExecuter = documentExecuter;
            this._schema = schema;
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] GraphQLQuery query)
        {
            var executionOptions = new ExecutionOptions
            {
                Schema = this._schema,
                Query = query.Query,
                Inputs = query.Variables.ToInputs(),
                EnableMetrics = true,
                ExposeExceptions = true,
            };

            var result = await this._documentExecuter.ExecuteAsync(executionOptions).ConfigureAwait(true);
            Console.WriteLine(result);
            return base.Ok(result);
        }
    }
}
