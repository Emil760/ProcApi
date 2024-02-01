using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProcApi.Domain.Entities;
using ProcApi.Domain.Enums;
using ProcApi.Domain.Models;

namespace ProcApi.Infrastructure.ModelConfigurations;

public class ReleaseStrategyConfiguration : IEntityTypeConfiguration<ReleaseStrategyTemplate>
{
    public void Configure(EntityTypeBuilder<ReleaseStrategyTemplate> builder)
    {
        builder.Property(c => c.ActiveStatusId)
            .HasColumnType("int")
            .IsRequired();

        builder.Property(c => c.AssignStatusId)
            .HasColumnType("int")
            .IsRequired();

        builder.Property(c => c.ActionTypeId)
            .HasColumnType("int")
            .IsRequired();

        builder.Property(d => d.FlowCodes)
            .HasColumnType("varchar")
            .HasMaxLength(300)
            .IsRequired();

        builder.HasOne(cu => cu.ApprovalFlowTemplate)
            .WithMany()
            .HasForeignKey(cu => cu.ApprovalFlowTemplateId)
            .OnDelete(DeleteBehavior.Cascade);

        SeedPrData(builder);
        SeedSrData(builder);
        SeedInvoiceData(builder);
    }

    private void SeedPrData(EntityTypeBuilder<ReleaseStrategyTemplate> builder)
    {
        #region STANDART

        var pr_submit1 = new ReleaseStrategyTemplate()
        {
            Id = 1000,
            ActiveStatusId = DocumentStatus.PurchaseRequestDraft,
            AssignStatusId = DocumentStatus.PurchaseRequestWaitingForHeadOfProcurement,
            ActionTypeId = ActionType.Approve,
            FlowCodes = FlowCodes.STANDART,
            ApprovalFlowTemplateId = 1
        };

        builder.HasData(pr_submit1);

        var pr_submit2 = new ReleaseStrategyTemplate()
        {
            Id = 1001,
            ActiveStatusId = DocumentStatus.PurchaseRequestWaitingForHeadOfProcurement,
            AssignStatusId = DocumentStatus.PurchaseRequestWaitingForProcurementDirector,
            ActionTypeId = ActionType.Approve,
            FlowCodes = FlowCodes.STANDART,
            ApprovalFlowTemplateId = 2
        };

        builder.HasData(pr_submit2);

        var pr_submit3 = new ReleaseStrategyTemplate()
        {
            Id = 1002,
            ActiveStatusId = DocumentStatus.PurchaseRequestWaitingForProcurementDirector,
            AssignStatusId = DocumentStatus.PurchaseRequestWaitingForBuyer,
            ActionTypeId = ActionType.Approve,
            FlowCodes = FlowCodes.STANDART,
            ApprovalFlowTemplateId = 3
        };

        builder.HasData(pr_submit3);

        var pr_return1 = new ReleaseStrategyTemplate()
        {
            Id = 1003,
            ActiveStatusId = DocumentStatus.PurchaseRequestWaitingForHeadOfProcurement,
            AssignStatusId = DocumentStatus.PurchaseRequestDraft,
            ActionTypeId = ActionType.Return,
            FlowCodes = FlowCodes.STANDART,
            ApprovalFlowTemplateId = 2
        };

        builder.HasData(pr_return1);

        var pr_return2 = new ReleaseStrategyTemplate()
        {
            Id = 1004,
            ActiveStatusId = DocumentStatus.PurchaseRequestWaitingForProcurementDirector,
            AssignStatusId = DocumentStatus.PurchaseRequestDraft,
            ActionTypeId = ActionType.Return,
            FlowCodes = FlowCodes.STANDART,
            ApprovalFlowTemplateId = 3
        };

        builder.HasData(pr_return2);

        var pr_reject1 = new ReleaseStrategyTemplate()
        {
            Id = 1005,
            ActiveStatusId = DocumentStatus.PurchaseRequestWaitingForHeadOfProcurement,
            AssignStatusId = DocumentStatus.PurchaseRequestRejected,
            ActionTypeId = ActionType.Reject,
            FlowCodes = FlowCodes.STANDART,
            ApprovalFlowTemplateId = 2
        };

        builder.HasData(pr_reject1);

        var pr_reject2 = new ReleaseStrategyTemplate()
        {
            Id = 1006,
            ActiveStatusId = DocumentStatus.PurchaseRequestWaitingForProcurementDirector,
            AssignStatusId = DocumentStatus.PurchaseRequestRejected,
            ActionTypeId = ActionType.Reject,
            FlowCodes = FlowCodes.STANDART,
            ApprovalFlowTemplateId = 3
        };

        builder.HasData(pr_reject2);

        var pr_cancel1 = new ReleaseStrategyTemplate()
        {
            Id = 1007,
            ActiveStatusId = DocumentStatus.PurchaseRequestDraft,
            AssignStatusId = DocumentStatus.PurchaseRequestCanceled,
            ActionTypeId = ActionType.Cancel,
            FlowCodes = FlowCodes.STANDART,
            ApprovalFlowTemplateId = 1
        };

        builder.HasData(pr_cancel1);

        #endregion

        #region STANDART_BUYER

        var pr_submit4 = new ReleaseStrategyTemplate()
        {
            Id = 1008,
            ActiveStatusId = DocumentStatus.PurchaseRequestDraft,
            AssignStatusId = DocumentStatus.PurchaseRequestWaitingForHeadOfProcurement,
            ActionTypeId = ActionType.Approve,
            FlowCodes = FlowCodes.STANDART_BUYER,
            ApprovalFlowTemplateId = 1
        };

        builder.HasData(pr_submit4);

        var pr_submit5 = new ReleaseStrategyTemplate()
        {
            Id = 1009,
            ActiveStatusId = DocumentStatus.PurchaseRequestWaitingForHeadOfProcurement,
            AssignStatusId = DocumentStatus.PurchaseRequestWaitingForProcurementDirector,
            ActionTypeId = ActionType.Approve,
            FlowCodes = FlowCodes.STANDART_BUYER,
            ApprovalFlowTemplateId = 2
        };

        builder.HasData(pr_submit5);

        var pr_submit6 = new ReleaseStrategyTemplate()
        {
            Id = 1010,
            ActiveStatusId = DocumentStatus.PurchaseRequestWaitingForProcurementDirector,
            AssignStatusId = DocumentStatus.PurchaseRequestWaitingForBuyer,
            ActionTypeId = ActionType.Approve,
            FlowCodes = FlowCodes.STANDART_BUYER,
            ApprovalFlowTemplateId = 3
        };

        builder.HasData(pr_submit6);

        var pr_submit7 = new ReleaseStrategyTemplate()
        {
            Id = 1011,
            ActiveStatusId = DocumentStatus.PurchaseRequestWaitingForBuyer,
            AssignStatusId = DocumentStatus.PurchaseRequestApproved,
            ActionTypeId = ActionType.Submit,
            FlowCodes = FlowCodes.STANDART_BUYER,
            ApprovalFlowTemplateId = 4
        };

        builder.HasData(pr_submit7);

        var pr_return3 = new ReleaseStrategyTemplate()
        {
            Id = 1012,
            ActiveStatusId = DocumentStatus.PurchaseRequestWaitingForHeadOfProcurement,
            AssignStatusId = DocumentStatus.PurchaseRequestDraft,
            ActionTypeId = ActionType.Return,
            FlowCodes = FlowCodes.STANDART_BUYER,
            ApprovalFlowTemplateId = 2
        };

        builder.HasData(pr_return3);

        var pr_return4 = new ReleaseStrategyTemplate()
        {
            Id = 1013,
            ActiveStatusId = DocumentStatus.PurchaseRequestWaitingForProcurementDirector,
            AssignStatusId = DocumentStatus.PurchaseRequestDraft,
            ActionTypeId = ActionType.Return,
            FlowCodes = FlowCodes.STANDART_BUYER,
            ApprovalFlowTemplateId = 3
        };

        builder.HasData(pr_return4);

        var pr_reject3 = new ReleaseStrategyTemplate()
        {
            Id = 1014,
            ActiveStatusId = DocumentStatus.PurchaseRequestWaitingForHeadOfProcurement,
            AssignStatusId = DocumentStatus.PurchaseRequestRejected,
            ActionTypeId = ActionType.Reject,
            FlowCodes = FlowCodes.STANDART_BUYER,
            ApprovalFlowTemplateId = 2
        };

        builder.HasData(pr_reject3);

        var pr_reject4 = new ReleaseStrategyTemplate()
        {
            Id = 1015,
            ActiveStatusId = DocumentStatus.PurchaseRequestWaitingForProcurementDirector,
            AssignStatusId = DocumentStatus.PurchaseRequestRejected,
            ActionTypeId = ActionType.Reject,
            FlowCodes = FlowCodes.STANDART_BUYER,
            ApprovalFlowTemplateId = 3
        };

        builder.HasData(pr_reject4);

        var pr_cancel2 = new ReleaseStrategyTemplate()
        {
            Id = 1016,
            ActiveStatusId = DocumentStatus.PurchaseRequestDraft,
            AssignStatusId = DocumentStatus.PurchaseRequestCanceled,
            ActionTypeId = ActionType.Cancel,
            FlowCodes = FlowCodes.STANDART,
            ApprovalFlowTemplateId = 1
        };

        builder.HasData(pr_cancel2);

        #endregion
    }

    private void SeedSrData(EntityTypeBuilder<ReleaseStrategyTemplate> builder)
    {
        #region STANDART

        var sr_submit1 = new ReleaseStrategyTemplate()
        {
            Id = 2000,
            ActiveStatusId = DocumentStatus.ServiceRequestDraft,
            AssignStatusId = DocumentStatus.ServiceRequestWaitingForHeadOfProcurement,
            ActionTypeId = ActionType.Approve,
            FlowCodes = FlowCodes.STANDART,
            ApprovalFlowTemplateId = 5
        };

        builder.HasData(sr_submit1);

        var sr_submit2 = new ReleaseStrategyTemplate()
        {
            Id = 2001,
            ActiveStatusId = DocumentStatus.ServiceRequestWaitingForHeadOfProcurement,
            AssignStatusId = DocumentStatus.ServiceRequestWaitingForProcurementDirector,
            ActionTypeId = ActionType.Approve,
            FlowCodes = FlowCodes.STANDART,
            ApprovalFlowTemplateId = 6
        };

        builder.HasData(sr_submit2);

        var sr_submit3 = new ReleaseStrategyTemplate()
        {
            Id = 2002,
            ActiveStatusId = DocumentStatus.ServiceRequestWaitingForProcurementDirector,
            AssignStatusId = DocumentStatus.ServiceRequestWaitingForBuyer,
            ActionTypeId = ActionType.Approve,
            FlowCodes = FlowCodes.STANDART,
            ApprovalFlowTemplateId = 7
        };

        builder.HasData(sr_submit3);

        var sr_return1 = new ReleaseStrategyTemplate()
        {
            Id = 2003,
            ActiveStatusId = DocumentStatus.ServiceRequestWaitingForHeadOfProcurement,
            AssignStatusId = DocumentStatus.ServiceRequestDraft,
            ActionTypeId = ActionType.Return,
            FlowCodes = FlowCodes.STANDART,
            ApprovalFlowTemplateId = 6
        };

        builder.HasData(sr_return1);

        var sr_return2 = new ReleaseStrategyTemplate()
        {
            Id = 2004,
            ActiveStatusId = DocumentStatus.ServiceRequestWaitingForProcurementDirector,
            AssignStatusId = DocumentStatus.PurchaseRequestDraft,
            ActionTypeId = ActionType.Return,
            FlowCodes = FlowCodes.STANDART,
            ApprovalFlowTemplateId = 7
        };

        builder.HasData(sr_return2);

        var sr_reject1 = new ReleaseStrategyTemplate()
        {
            Id = 2005,
            ActiveStatusId = DocumentStatus.ServiceRequestWaitingForHeadOfProcurement,
            AssignStatusId = DocumentStatus.ServiceRequestRejected,
            ActionTypeId = ActionType.Reject,
            FlowCodes = FlowCodes.STANDART,
            ApprovalFlowTemplateId = 6
        };

        builder.HasData(sr_reject1);

        var sr_reject2 = new ReleaseStrategyTemplate()
        {
            Id = 2006,
            ActiveStatusId = DocumentStatus.ServiceRequestWaitingForProcurementDirector,
            AssignStatusId = DocumentStatus.ServiceRequestRejected,
            ActionTypeId = ActionType.Reject,
            FlowCodes = FlowCodes.STANDART,
            ApprovalFlowTemplateId = 7
        };

        builder.HasData(sr_reject2);

        var sr_cancel1 = new ReleaseStrategyTemplate()
        {
            Id = 2007,
            ActiveStatusId = DocumentStatus.InvoiceDraft,
            AssignStatusId = DocumentStatus.ServiceRequestCanceled,
            ActionTypeId = ActionType.Cancel,
            FlowCodes = FlowCodes.STANDART,
            ApprovalFlowTemplateId = 5
        };

        builder.HasData(sr_cancel1);

        #endregion

        #region STANDART_BUYER

        var sr_submit4 = new ReleaseStrategyTemplate()
        {
            Id = 2008,
            ActiveStatusId = DocumentStatus.ServiceRequestDraft,
            AssignStatusId = DocumentStatus.ServiceRequestWaitingForHeadOfProcurement,
            ActionTypeId = ActionType.Approve,
            FlowCodes = FlowCodes.STANDART_BUYER,
            ApprovalFlowTemplateId = 5
        };

        builder.HasData(sr_submit4);

        var sr_submit5 = new ReleaseStrategyTemplate()
        {
            Id = 2009,
            ActiveStatusId = DocumentStatus.ServiceRequestWaitingForHeadOfProcurement,
            AssignStatusId = DocumentStatus.ServiceRequestWaitingForProcurementDirector,
            ActionTypeId = ActionType.Approve,
            FlowCodes = FlowCodes.STANDART_BUYER,
            ApprovalFlowTemplateId = 6
        };

        builder.HasData(sr_submit5);

        var sr_submit6 = new ReleaseStrategyTemplate()
        {
            Id = 2010,
            ActiveStatusId = DocumentStatus.ServiceRequestWaitingForProcurementDirector,
            AssignStatusId = DocumentStatus.ServiceRequestWaitingForBuyer,
            ActionTypeId = ActionType.Approve,
            FlowCodes = FlowCodes.STANDART_BUYER,
            ApprovalFlowTemplateId = 7
        };

        builder.HasData(sr_submit6);

        var sr_submit7 = new ReleaseStrategyTemplate()
        {
            Id = 2011,
            ActiveStatusId = DocumentStatus.ServiceRequestWaitingForProcurementDirector,
            AssignStatusId = DocumentStatus.ServiceRequestWaitingForBuyer,
            ActionTypeId = ActionType.Submit,
            FlowCodes = FlowCodes.STANDART_BUYER,
            ApprovalFlowTemplateId = 8
        };

        builder.HasData(sr_submit7);

        var sr_return3 = new ReleaseStrategyTemplate()
        {
            Id = 2012,
            ActiveStatusId = DocumentStatus.ServiceRequestWaitingForHeadOfProcurement,
            AssignStatusId = DocumentStatus.ServiceRequestDraft,
            ActionTypeId = ActionType.Return,
            FlowCodes = FlowCodes.STANDART_BUYER,
            ApprovalFlowTemplateId = 6
        };

        builder.HasData(sr_return3);

        var sr_return4 = new ReleaseStrategyTemplate()
        {
            Id = 2013,
            ActiveStatusId = DocumentStatus.ServiceRequestWaitingForProcurementDirector,
            AssignStatusId = DocumentStatus.PurchaseRequestDraft,
            ActionTypeId = ActionType.Return,
            FlowCodes = FlowCodes.STANDART_BUYER,
            ApprovalFlowTemplateId = 7
        };

        builder.HasData(sr_return4);

        var sr_reject3 = new ReleaseStrategyTemplate()
        {
            Id = 2014,
            ActiveStatusId = DocumentStatus.ServiceRequestWaitingForHeadOfProcurement,
            AssignStatusId = DocumentStatus.ServiceRequestRejected,
            ActionTypeId = ActionType.Reject,
            FlowCodes = FlowCodes.STANDART_BUYER,
            ApprovalFlowTemplateId = 6
        };

        builder.HasData(sr_reject3);

        var sr_reject4 = new ReleaseStrategyTemplate()
        {
            Id = 2015,
            ActiveStatusId = DocumentStatus.ServiceRequestWaitingForProcurementDirector,
            AssignStatusId = DocumentStatus.ServiceRequestRejected,
            ActionTypeId = ActionType.Reject,
            FlowCodes = FlowCodes.STANDART_BUYER,
            ApprovalFlowTemplateId = 7
        };

        builder.HasData(sr_reject4);

        var sr_cancel2 = new ReleaseStrategyTemplate()
        {
            Id = 2016,
            ActiveStatusId = DocumentStatus.InvoiceDraft,
            AssignStatusId = DocumentStatus.ServiceRequestCanceled,
            ActionTypeId = ActionType.Cancel,
            FlowCodes = FlowCodes.STANDART_BUYER,
            ApprovalFlowTemplateId = 5
        };

        builder.HasData(sr_cancel2);

        #endregion
    }

    private void SeedInvoiceData(EntityTypeBuilder<ReleaseStrategyTemplate> builder)
    {
        #region STANDART

        var invoice_approve1 = new ReleaseStrategyTemplate()
        {
            Id = 3000,
            ActiveStatusId = DocumentStatus.InvoiceDraft,
            AssignStatusId = DocumentStatus.InvoiceWaitingForCoordinator,
            ActionTypeId = ActionType.Approve,
            FlowCodes = FlowCodes.STANDART,
            ApprovalFlowTemplateId = 9
        };

        builder.HasData(invoice_approve1);

        var invoice_approve2 = new ReleaseStrategyTemplate()
        {
            Id = 3001,
            ActiveStatusId = DocumentStatus.InvoiceWaitingForCoordinator,
            AssignStatusId = DocumentStatus.InvoiceWaitingForFinance,
            ActionTypeId = ActionType.Approve,
            FlowCodes = FlowCodes.STANDART,
            ApprovalFlowTemplateId = 10
        };

        builder.HasData(invoice_approve2);

        var invoice_approve3 = new ReleaseStrategyTemplate()
        {
            Id = 3002,
            ActiveStatusId = DocumentStatus.InvoiceWaitingForFinance,
            AssignStatusId = DocumentStatus.InvoiceApproved,
            ActionTypeId = ActionType.Submit,
            FlowCodes = FlowCodes.STANDART,
            ApprovalFlowTemplateId = 11
        };

        builder.HasData(invoice_approve3);

        var invoice_cancel1 = new ReleaseStrategyTemplate()
        {
            Id = 3003,
            ActiveStatusId = DocumentStatus.InvoiceDraft,
            AssignStatusId = DocumentStatus.InvoiceCanceled,
            ActionTypeId = ActionType.Cancel,
            FlowCodes = FlowCodes.STANDART,
            ApprovalFlowTemplateId = 9
        };

        builder.HasData(invoice_cancel1);

        var invoice_return1 = new ReleaseStrategyTemplate()
        {
            Id = 3004,
            ActiveStatusId = DocumentStatus.InvoiceWaitingForCoordinator,
            AssignStatusId = DocumentStatus.InvoiceDraft,
            ActionTypeId = ActionType.Return,
            FlowCodes = FlowCodes.STANDART,
            ApprovalFlowTemplateId = 10
        };

        builder.HasData(invoice_return1);

        var invoice_return2 = new ReleaseStrategyTemplate()
        {
            Id = 3005,
            ActiveStatusId = DocumentStatus.InvoiceWaitingForFinance,
            AssignStatusId = DocumentStatus.InvoiceDraft,
            ActionTypeId = ActionType.Return,
            FlowCodes = FlowCodes.STANDART,
            ApprovalFlowTemplateId = 11
        };

        builder.HasData(invoice_return2);

        var invoice_reject1 = new ReleaseStrategyTemplate()
        {
            Id = 3006,
            ActiveStatusId = DocumentStatus.InvoiceWaitingForCoordinator,
            AssignStatusId = DocumentStatus.InvoiceRejected,
            ActionTypeId = ActionType.Reject,
            FlowCodes = FlowCodes.STANDART,
            ApprovalFlowTemplateId = 10
        };

        builder.HasData(invoice_reject1);

        var invoice_reject2 = new ReleaseStrategyTemplate()
        {
            Id = 3007,
            ActiveStatusId = DocumentStatus.InvoiceWaitingForFinance,
            AssignStatusId = DocumentStatus.InvoiceRejected,
            ActionTypeId = ActionType.Reject,
            FlowCodes = FlowCodes.STANDART,
            ApprovalFlowTemplateId = 11
        };

        builder.HasData(invoice_reject2);

        #endregion

        #region REVIEWER

        var invoice_approve4 = new ReleaseStrategyTemplate()
        {
            Id = 3008,
            ActiveStatusId = DocumentStatus.InvoiceDraft,
            AssignStatusId = DocumentStatus.InvoiceWaitingForCoordinator,
            ActionTypeId = ActionType.Approve,
            FlowCodes = FlowCodes.STANDART_REVIEWER,
            ApprovalFlowTemplateId = 9
        };

        builder.HasData(invoice_approve4);

        var invoice_approve5 = new ReleaseStrategyTemplate()
        {
            Id = 3009,
            ActiveStatusId = DocumentStatus.InvoiceWaitingForCoordinator,
            AssignStatusId = DocumentStatus.InvoiceWaitingForReviewer,
            FlowCodes = FlowCodes.STANDART_REVIEWER,
            ActionTypeId = ActionType.Approve,
            ApprovalFlowTemplateId = 10
        };

        builder.HasData(invoice_approve5);

        var invoice_approve6 = new ReleaseStrategyTemplate()
        {
            Id = 3010,
            ActiveStatusId = DocumentStatus.InvoiceWaitingForFinance,
            AssignStatusId = DocumentStatus.InvoiceApproved,
            ActionTypeId = ActionType.Submit,
            FlowCodes = FlowCodes.STANDART_REVIEWER,
            ApprovalFlowTemplateId = 11
        };

        builder.HasData(invoice_approve6);

        var invoice_cancel2 = new ReleaseStrategyTemplate()
        {
            Id = 3011,
            ActiveStatusId = DocumentStatus.InvoiceDraft,
            AssignStatusId = DocumentStatus.InvoiceCanceled,
            ActionTypeId = ActionType.Cancel,
            FlowCodes = FlowCodes.STANDART_REVIEWER,
            ApprovalFlowTemplateId = 9
        };

        builder.HasData(invoice_cancel2);

        var invoice_return4 = new ReleaseStrategyTemplate()
        {
            Id = 3012,
            ActiveStatusId = DocumentStatus.InvoiceWaitingForCoordinator,
            AssignStatusId = DocumentStatus.InvoiceDraft,
            ActionTypeId = ActionType.Return,
            FlowCodes = FlowCodes.STANDART_REVIEWER,
            ApprovalFlowTemplateId = 10
        };

        builder.HasData(invoice_return4);

        var invoice_return5 = new ReleaseStrategyTemplate()
        {
            Id = 3013,
            ActiveStatusId = DocumentStatus.InvoiceWaitingForFinance,
            AssignStatusId = DocumentStatus.InvoiceDraft,
            ActionTypeId = ActionType.Return,
            FlowCodes = FlowCodes.STANDART_REVIEWER,
            ApprovalFlowTemplateId = 11
        };

        builder.HasData(invoice_return5);

        var invoice_return6 = new ReleaseStrategyTemplate()
        {
            Id = 3014,
            ActiveStatusId = DocumentStatus.InvoiceWaitingForReviewer,
            AssignStatusId = DocumentStatus.InvoiceDraft,
            ActionTypeId = ActionType.Return,
            FlowCodes = FlowCodes.STANDART_REVIEWER,
            ApprovalFlowTemplateId = 12
        };

        builder.HasData(invoice_return6);

        var invoice_reject3 = new ReleaseStrategyTemplate()
        {
            Id = 3015,
            ActiveStatusId = DocumentStatus.InvoiceWaitingForCoordinator,
            AssignStatusId = DocumentStatus.InvoiceRejected,
            ActionTypeId = ActionType.Reject,
            FlowCodes = FlowCodes.STANDART_REVIEWER,
            ApprovalFlowTemplateId = 10
        };

        builder.HasData(invoice_reject3);

        var invoice_reject4 = new ReleaseStrategyTemplate()
        {
            Id = 3016,
            ActiveStatusId = DocumentStatus.InvoiceWaitingForFinance,
            AssignStatusId = DocumentStatus.InvoiceRejected,
            ActionTypeId = ActionType.Reject,
            FlowCodes = FlowCodes.STANDART_REVIEWER,
            ApprovalFlowTemplateId = 11
        };

        builder.HasData(invoice_reject4);

        var invoice_reject5 = new ReleaseStrategyTemplate()
        {
            Id = 3017,
            ActiveStatusId = DocumentStatus.InvoiceWaitingForReviewer,
            AssignStatusId = DocumentStatus.InvoiceRejected,
            ActionTypeId = ActionType.Reject,
            FlowCodes = FlowCodes.STANDART_REVIEWER,
            ApprovalFlowTemplateId = 12
        };

        builder.HasData(invoice_reject5);

        #endregion
    }
}