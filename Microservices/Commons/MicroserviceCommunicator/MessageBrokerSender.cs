using System;
using Amazon.SecurityToken;
using Amazon.SecurityToken.Model;
using Amazon.SimpleNotificationService;
using Amazon.SimpleNotificationService.Model;
using Newtonsoft.Json;

namespace MicroserviceCommunicator
{
    public interface IMessageBrokerSender
    {
        /// <summary>
        /// Provide the credentials
        /// </summary>
        /// <param name="accessKey"></param>
        /// <param name="secretKey"></param>
        /// <param name="endpoint"></param>
        /// <returns></returns>
        MessageBrokerSender UseCredential(string accessKey, string secretKey, Amazon.RegionEndpoint endpoint);


        /// <summary>
        /// Ensure that all parameters are correctly set-up
        /// </summary>
        /// <returns></returns>
        MessageBrokerSender Ensure();

        /// <summary>
        /// Log more error in the console, use this method first right after the instanciation to not loose any log.
        /// </summary>
        /// <returns></returns>
        MessageBrokerSender UseVerbose();

        /// <summary>
        /// Define if dry run
        /// </summary>
        /// <returns></returns>
        MessageBrokerSender DryRun(bool dryRun);

        /// <summary>
        /// Send message to a specific user
        /// </summary>
        void SendMessage(string subject,object obj);

        MessageBrokerSender WithArn(string arn);
    }

    public class MessageBrokerSender : IMessageBrokerSender
    {
        public MessageBrokerSender()  { this._messageBrokerSenderConfiguration=new MessageBrokerSenderConfiguration(); }

        private readonly MessageBrokerSenderConfiguration _messageBrokerSenderConfiguration;

        /// <summary>
        /// Provide the credentials
        /// </summary>
        /// <param name="accessKey"></param>
        /// <param name="secretKey"></param>
        /// <param name="endpoint"></param>
        /// <returns></returns>
        public MessageBrokerSender UseCredential(string accessKey, string secretKey, Amazon.RegionEndpoint endpoint)
        {
            var stsClientConfig = new AmazonSecurityTokenServiceConfig
            {
                RegionEndpoint = endpoint,
                Timeout = TimeSpan.FromSeconds(180),
                ReadWriteTimeout = TimeSpan.FromSeconds(300),
                MaxErrorRetry = 5
            };

            var task = new AmazonSecurityTokenServiceClient(accessKey, secretKey, stsClientConfig).GetSessionTokenAsync(new GetSessionTokenRequest
            {
                DurationSeconds = 1500
            }).Result;

            this._messageBrokerSenderConfiguration.Client = new AmazonSimpleNotificationServiceClient(task.Credentials, endpoint);

            return this;
        }

        /// <summary>
        /// Ensure that all parameters are correctly set-up
        /// </summary>
        /// <returns></returns>
        public MessageBrokerSender Ensure()
        {
            this._messageBrokerSenderConfiguration.Ensure();
            return this;
        }

        /// <summary>
        /// Log more error in the console, use this method first right after the instanciation to not loose any log.
        /// </summary>
        /// <returns></returns>
        public MessageBrokerSender UseVerbose()
        {
            this._messageBrokerSenderConfiguration.Verbose = true;
            return this;
        }
        /// <summary>
        /// Define if dry run
        /// </summary>
        /// <returns></returns>
        public MessageBrokerSender DryRun(bool dryRun)
        {
            this._messageBrokerSenderConfiguration.DryRun = dryRun;
            return this;
        }

        public MessageBrokerSender WithArn(string arn)
        {
            this._messageBrokerSenderConfiguration.Arn = arn;
            return this;
        }

        /// <summary>
        /// Send message to a specific arn
        /// </summary>
        public void SendMessage(string subject ,object obj) 
        {
            if (this._messageBrokerSenderConfiguration.DryRun)
                return;
            

            var request = new PublishRequest
            {
                TopicArn = this._messageBrokerSenderConfiguration.Arn,
                Subject = subject,
                Message = JsonConvert.SerializeObject(obj)
            };

            var response = this._messageBrokerSenderConfiguration.Client.PublishAsync(request).Result;
        }

       
    }
}