using System.Runtime.Serialization;
using System.ServiceModel;
using Test.SoapCore.Services.Dto;

namespace Test.SoapCore.Services
{
    namespace Dto {
        [DataContract(Namespace = "http://Test.SoapCore.Services.Dto")]
        public class InDto
        {
            public int Id {get; set;}
        }

        [DataContract(Namespace = "http://Test.SoapCore.Services.Dto")]
        public class OutDto
        {
            public string Name {get; set;}
        }
    }

    [ServiceContract(Namespace="http://Test.SoapCore.Services/Test")]
    public interface ITestWebServiceProvider
    {
        [OperationContract]
        List<OutDto> Execute(List<InDto> inDtos);
    }

    public class TestWebServiceProvider : ITestWebServiceProvider
    {
        public List<OutDto> Execute(List<InDto> inDtos)
        {
            return inDtos.Select(inDto => new OutDto () {Name = "name-" + inDto.Id}).ToList();
        }
    }
}