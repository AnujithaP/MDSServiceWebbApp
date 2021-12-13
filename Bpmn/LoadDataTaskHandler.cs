using Camunda.Worker;
using MDSServiceWebbApp.Models;
using MDSServiceWebbApp.Services;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MDSServiceWebbApp.Bpmn
{
    [HandlerTopics("Topic_LoadData", LockDuration = 10_000)]
    public class LoadDataTaskHandler : ExternalTaskHandler
    {
        private readonly IMediator _bus;
        private readonly IMDSServices _mDSServices;
        private readonly IStagingService _stagingService;
        private readonly ILogger<LoadDataTaskHandler> _logger;

        public LoadDataTaskHandler(IMediator bus, IMDSServices mDSServices, IStagingService stagingService, ILogger<LoadDataTaskHandler> logger)
        {
            _bus = bus;
            _mDSServices = mDSServices;
            _stagingService = stagingService;
            _logger = logger;
        }

        public override async Task<IExecutionResult> Process(ExternalTask externalTask)
        {
            _logger.LogInformation(externalTask.TopicName + " called.");

            var variabler = externalTask.Variables;

            var stagePersoner = _stagingService.GetPerson_Leaves();

            foreach (var leaf in stagePersoner)
            {
                var exists = await _mDSServices.CheckPerson(leaf.Name);
                if (!exists)
                {
                    var person = new Person() { Namn = leaf.Name, Efternamn = leaf.Last_Name, Förnamn = leaf.First_Name, Personnummer = leaf.Social_Security_Number };
                    await _mDSServices.AddPerson(person);
                }
            }

            return new CompleteResult
            {
                Variables = new Dictionary<string, Variable>
                {
                    ["result"] = new Variable("", VariableType.String)
                }
            };
        }
    }
}
