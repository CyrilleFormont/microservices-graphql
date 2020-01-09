using System;
using Amazon.SimpleNotificationService;

namespace MicroserviceCommunicator
{
    public class MessageBrokerSenderConfiguration
    {
        public bool DryRun { get; set; } = false;
        public string Arn { get; set; } = string.Empty;
        public AmazonSimpleNotificationServiceClient Client { get; set; } = null;
        public bool Verbose { get; set; } = false;
        public void Ensure()
        {
            if(string.IsNullOrEmpty(this.Arn))
                throw new ArgumentNullException($"Can't have a null ARN");

            if (this.Client is null)
                this.Client = new AmazonSimpleNotificationServiceClient(Amazon.RegionEndpoint.APSoutheast2);
        }
    }
}
