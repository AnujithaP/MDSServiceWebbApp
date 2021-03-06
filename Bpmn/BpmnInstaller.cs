using System;
using Camunda.Worker;
using Camunda.Worker.Extensions;
using MDSServiceWebbApp.Bpmn;
using Microsoft.Extensions.DependencyInjection;

namespace MDSServiceWebbApp
{
    public static class BpmnInstaller
    {
        public static IServiceCollection AddCamunda(this IServiceCollection services, string camundaRestApiUri)
        {
            services.AddSingleton(_ => new BpmnService(camundaRestApiUri));
            services.AddHostedService<BpmnProcessDeployService>();
            
            services.AddCamundaWorker(options =>
            {
                options.BaseUri = new Uri(camundaRestApiUri);
                options.WorkerCount = 1;
            })
            .AddHandler<CreatePersonTaskHandler>()
            .AddHandler<CreateEpostTaskHandler>()
            .AddHandler<StoreDataTaskHandler>()
            .AddHandler<LoadDataTaskHandler>();
            
            return services;
        }
    }
}