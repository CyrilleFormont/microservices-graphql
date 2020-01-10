using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GraphQL;
using GraphQL.Types;
using GraphQL.Validation.Complexity;
using Microsoft.AspNetCore.Mvc;
using Vanilla.User.API.SchemaTypes;
namespace Vanilla.User.API
{
    [Route("/graphql")]
    public class GraphQLController : Controller
    {
        private readonly IDocumentExecuter _documentExecuter;
        private readonly ISchema _schema;
        public GraphQLController(ISchema schema, IDocumentExecuter documentExecuter)
        {
            _schema = schema;
            _documentExecuter = documentExecuter;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] GraphQLQuery query)
        {

            var executionOptions = new ExecutionOptions
            {
                Schema = _schema,
                Query = query.Query,
                Inputs = query.Variables.ToInputs(),
                UserContext = null,
                EnableMetrics = true,
                ExposeExceptions = true,
                //ComplexityConfiguration = new ComplexityConfiguration { MaxDepth = 15 }
            };

            var result = await _documentExecuter.ExecuteAsync(executionOptions).ConfigureAwait(true);

            return Ok(result);
        }
    }
    public class GraphQLError
    {
        public string Message { get; set; }
        public int Code { get; set; }
    }
}
