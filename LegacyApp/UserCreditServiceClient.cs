using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.ServiceModel;
using System.ServiceModel.Channels;

namespace LegacyApp
{
    //TODO I believe this is not part of the exercise, but as a suggestion I will rather use a ASP.NET Core Web API approach rather than the WCF approach.

    [GeneratedCode("System.ServiceModel", "4.0.0.0")]
    [ServiceContract(ConfigurationName =  "LegacyApp.IUserCreditService")]
    public interface IUserCreditServiceClient
    {
        [OperationContract(Action = "http://totally-real-service.com/IUserCreditService/GetCreditLimit")]
        int GetCreditLimit(string firstname, string surname, DateTime dateOfBirth);
    }

    [GeneratedCode("System.ServiceModel", "4.0.0.0")]
    public interface IUserCreditServiceChannel : IUserCreditServiceClient, IClientChannel
    {
    }
    
    [DebuggerStepThrough]
    [GeneratedCode("System.ServiceModel", "4.0.0.0")]
    public partial class UserCreditServiceClient : ClientBase<IUserCreditServiceClient>, IUserCreditServiceClient
    {
        private IUserCreditServiceChannel _userCreditServiceChannelImplementation;
        public UserCreditServiceClient() {}
        
        public UserCreditServiceClient(string endpointConfigurationName) : 
            base(endpointConfigurationName)
        {}
        
        public UserCreditServiceClient(string endpointConfigurationName, EndpointAddress remoteAddress) : 
            base(endpointConfigurationName, remoteAddress)
        {}
        
        public UserCreditServiceClient(Binding binding, EndpointAddress remoteAddress) : 
            base(binding, remoteAddress)
        {}

        public int GetCreditLimit(string firstname, string surname, DateTime dateOfBirth)
        {
            return base.Channel.GetCreditLimit(firstname, surname, dateOfBirth);
        }
    }
}