using System.ServiceModel;
using Microsoft.Extensions.DependencyInjection.Extensions;
using SoapCore;
using Test.SoapCore.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSoapCore();
builder.Services.TryAddSingleton<TestWebServiceProvider>();
builder.Services.AddMvc();

var app = builder.Build();

app.UseRouting();

app.UseEndpoints(endpoints => {
    endpoints.UseSoapEndpoint<ITestWebServiceProvider>("/TestWebServiceProvider.svc", new SoapEncoderOptions(), SoapSerializer.DataContractSerializer);
});

app.Run();
