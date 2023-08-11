using Microsoft.Identity.Client;
using ProcApi.Data.ProcDatabase.Enums;
using ProcApi.DTOs.Documents;
using ProcApi.Services.Abstracts;
using System.Runtime.CompilerServices;

namespace ProcApi.Services.Concreates
{
    public class PurchaseRequestDocumentService : IPurchaseRequestDocumentService
    {
        private readonly IApprovalFlowService approvalFlowService;
        private readonly PurchaseRequestDocumentService aaa;

        // private readonly Dictionary<int, Action> calls = new Dictionary<int, Func<Task>>()
        // {
        //     {1, Approve },
        //
        // };

        public PurchaseRequestDocumentService()
        {

        }

        public string AAA()
        {
            return "";
        }

        public async Task PerformAction(ActionPerformDto dto)
        {
            if (dto.ActionType == ActionType.Approve)
                await Approve();
        }

        public async Task Approve()
        {

        }

        public async Task SaveAsDraft()
        {

        }

        public async Task Return()
        {

        }

        public async Task Reject()
        {

        }

        public async Task Reconcile()
        {

        }

        public async Task ValidateForApprove()
        {

        }

        public async Task ValidateForDraft()
        {

        }
    }
}
