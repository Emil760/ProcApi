﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProcApi.Domain.Entities;
using ProcApi.Domain.Enums;
using ProcApi.Domain.Models;
using ProcApi.Infrastructure.Enums;

namespace ProcApi.Infrastructure.ModelConfigurations;

public class ApprovalFlowTemplateConfiguration : IEntityTypeConfiguration<ApprovalFlowTemplate>
{
    public void Configure(EntityTypeBuilder<ApprovalFlowTemplate> builder)
    {
        builder.Property(aft => aft.IsCreator)
            .HasColumnType("boolean")
            .IsRequired()
            .HasDefaultValue(false);

        builder.Property(aft => aft.IsInitial)
            .HasColumnType("boolean")
            .IsRequired()
            .HasDefaultValue(false);

        builder.Property(d => d.FlowCode)
            .HasColumnType("varchar")
            .HasMaxLength(300)
            .IsRequired();

        SeedPrData(builder);
        SeedSrData(builder);
        SeedInvoiceData(builder);
    }

    private void SeedPrData(EntityTypeBuilder<ApprovalFlowTemplate> builder)
    {
        var pr_requester = new ApprovalFlowTemplate()
        {
            Id = (int)ApprovalFlowTemplateSeedIds.PrRequester,
            DocumentTypeId = DocumentType.PurchaseRequest,
            Order = 1,
            RoleId = (int)Roles.Requester,
            UserId = null,
            FlowCode = FlowCodes.STANDART,
            IsCreator = true,
            IsInitial = true,
            IsMultiple = false
        };

        builder.HasData(pr_requester);

        var pr_head_department = new ApprovalFlowTemplate()
        {
            Id = (int)ApprovalFlowTemplateSeedIds.PrHeadDepartment,
            DocumentTypeId = DocumentType.PurchaseRequest,
            Order = 2,
            RoleId = (int)Roles.HeadDepartment,
            UserId = 14,
            FlowCode = FlowCodes.STANDART,
            IsCreator = false,
            IsInitial = true,
            IsMultiple = false
        };

        builder.HasData(pr_head_department);

        var pr_procurement_director = new ApprovalFlowTemplate()
        {
            Id = (int)ApprovalFlowTemplateSeedIds.PrProcurementDirector,
            DocumentTypeId = DocumentType.PurchaseRequest,
            Order = 3,
            RoleId = (int)Roles.ProcurementDirector,
            UserId = 12,
            FlowCode = FlowCodes.STANDART,
            IsCreator = false,
            IsInitial = true,
            IsMultiple = false
        };

        builder.HasData(pr_procurement_director);

        var pr_buyer = new ApprovalFlowTemplate()
        {
            Id = (int)ApprovalFlowTemplateSeedIds.PrBuyer,
            DocumentTypeId = DocumentType.PurchaseRequest,
            Order = 4,
            RoleId = (int)Roles.Buyer,
            UserId = null,
            FlowCode = FlowCodes.BUYER,
            IsCreator = false,
            IsInitial = false,
            IsMultiple = true
        };

        builder.HasData(pr_buyer);
    }

    private void SeedSrData(EntityTypeBuilder<ApprovalFlowTemplate> builder)
    {
        var sr_requester = new ApprovalFlowTemplate()
        {
            Id = (int)ApprovalFlowTemplateSeedIds.SrRequester,
            DocumentTypeId = DocumentType.ServiceRequest,
            Order = 1,
            RoleId = (int)Roles.Requester,
            UserId = null,
            FlowCode = FlowCodes.STANDART,
            IsCreator = true,
            IsInitial = true,
            IsMultiple = false
        };

        builder.HasData(sr_requester);

        var sr_head_department = new ApprovalFlowTemplate()
        {
            Id = (int)ApprovalFlowTemplateSeedIds.SrHeadDepartment,
            DocumentTypeId = DocumentType.ServiceRequest,
            Order = 2,
            RoleId = (int)Roles.HeadDepartment,
            UserId = null,
            FlowCode = FlowCodes.STANDART,
            IsCreator = false,
            IsInitial = true,
            IsMultiple = false
        };

        builder.HasData(sr_head_department);

        var sr_procurement_director = new ApprovalFlowTemplate()
        {
            Id = (int)ApprovalFlowTemplateSeedIds.SrProcurementDirector,
            DocumentTypeId = DocumentType.ServiceRequest,
            Order = 3,
            RoleId = (int)Roles.ProcurementDirector,
            UserId = 12,
            FlowCode = FlowCodes.STANDART,
            IsCreator = false,
            IsInitial = true,
            IsMultiple = false
        };

        builder.HasData(sr_procurement_director);

        var sr_buyer = new ApprovalFlowTemplate()
        {
            Id = (int)ApprovalFlowTemplateSeedIds.SrBuyer,
            DocumentTypeId = DocumentType.ServiceRequest,
            Order = 4,
            RoleId = (int)Roles.Buyer,
            UserId = null,
            FlowCode = FlowCodes.BUYER,
            IsCreator = false,
            IsInitial = false,
            IsMultiple = true
        };

        builder.HasData(sr_buyer);
    }

    private void SeedInvoiceData(EntityTypeBuilder<ApprovalFlowTemplate> builder)
    {
        var invoice_buyer = new ApprovalFlowTemplate()
        {
            Id = (int)ApprovalFlowTemplateSeedIds.InvoiceBuyer,
            DocumentTypeId = DocumentType.Invoice,
            Order = 1,
            RoleId = (int)Roles.Buyer,
            UserId = null,
            FlowCode = FlowCodes.STANDART,
            IsCreator = true,
            IsInitial = true,
            IsMultiple = false
        };

        builder.HasData(invoice_buyer);

        var invoice_coordinator = new ApprovalFlowTemplate()
        {
            Id = (int)ApprovalFlowTemplateSeedIds.InvoiceCoordinator,
            DocumentTypeId = DocumentType.Invoice,
            Order = 2,
            RoleId = (int)Roles.Coordinator,
            UserId = 9,
            FlowCode = FlowCodes.STANDART,
            IsCreator = false,
            IsInitial = true,
            IsMultiple = false
        };

        builder.HasData(invoice_coordinator);

        var invoice_finance = new ApprovalFlowTemplate()
        {
            Id = (int)ApprovalFlowTemplateSeedIds.InvoiceFinance,
            DocumentTypeId = DocumentType.Invoice,
            Order = 3,
            RoleId = (int)Roles.Finance,
            UserId = 4,
            FlowCode = FlowCodes.STANDART,
            IsCreator = false,
            IsInitial = true,
            IsMultiple = false
        };

        builder.HasData(invoice_finance);

        var invoice_reviwer = new ApprovalFlowTemplate()
        {
            Id = (int)ApprovalFlowTemplateSeedIds.InvoiceReviewer,
            DocumentTypeId = DocumentType.Invoice,
            Order = 2.5f,
            RoleId = (int)Roles.Reviewer,
            UserId = null,
            FlowCode = FlowCodes.REVIEWER,
            IsCreator = false,
            IsInitial = false,
            IsMultiple = false
        };

        builder.HasData(invoice_reviwer);
    }
}