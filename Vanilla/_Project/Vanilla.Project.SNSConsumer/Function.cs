using System;
using System.Threading.Tasks;
using Amazon.Lambda.Core;
using Amazon.Lambda.RuntimeSupport;
using Amazon.Lambda.SNSEvents;
using MessageBrokerDtos.User;
using Newtonsoft.Json;
using JsonSerializer = Amazon.Lambda.Serialization.Json.JsonSerializer;

namespace Vanilla.Project.SNSConsumer
{
    public class Function
    {
        /// <summary>
        /// The main entry point for the custom runtime.
        /// </summary>
        /// <param name="args"></param>
        private static async Task Main(string[] args)
        {
            Func<SNSEvent, ILambdaContext, string> func = FunctionHandler;
            using (var handlerWrapper = HandlerWrapper.GetHandlerWrapper(func, new JsonSerializer()))
            using (var bootstrap = new LambdaBootstrap(handlerWrapper))
            {
                await bootstrap.RunAsync();
            }
        }

        public static string FunctionHandler(SNSEvent input, ILambdaContext context)
        {

            foreach (var item in input.Records)
            {
                var requestType = Type.GetType(item.Sns.Subject);
                var result = JsonConvert.DeserializeObject(item.Sns.Message, requestType);

                switch (result)
                {
                    case RemovedUserEvent rue: 
                        //Delete the users from all the projects
                        break;
                }
            }

            return "Task done.";
        }
    }
}
