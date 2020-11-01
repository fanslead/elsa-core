﻿using System.Threading;
using System.Threading.Tasks;
using Elsa.Events;
using Elsa.Services;
using MediatR;

// ReSharper disable once CheckNamespace
namespace Elsa.Activities.Workflows
{
    public class ResumeWorkflow : INotificationHandler<WorkflowCompleted>
    {
        private readonly IWorkflowScheduler _workflowScheduler;

        public ResumeWorkflow(IWorkflowScheduler workflowScheduler)
        {
            _workflowScheduler = workflowScheduler;
        }
        
        public async Task Handle(WorkflowCompleted notification, CancellationToken cancellationToken)
        {
            var workflowExecutionContext = notification.WorkflowExecutionContext;
            var workflowInstanceId = workflowExecutionContext.WorkflowInstance.WorkflowInstanceId;
            var output = workflowExecutionContext.WorkflowInstance.Output;
            
            var input = new FinishedWorkflowModel
            {
                WorkflowInstanceId = workflowInstanceId,
                Output = output
            };
            
            await _workflowScheduler.TriggerWorkflowsAsync<RunWorkflowTrigger>(x => x.ChildWorkflowInstanceIds.Contains(workflowInstanceId), input, cancellationToken: cancellationToken);
        }
    }
}