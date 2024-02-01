using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProcApi.Domain.Entities;
using ProcApi.Domain.Enums;

namespace ProcApi.Infrastructure.ModelConfigurations;

public class DocumentValidationConfigurationConfiguration : IEntityTypeConfiguration<DocumentValidationConfiguration>
{
    public void Configure(EntityTypeBuilder<DocumentValidationConfiguration> builder)
    {
        var data = SeedData();
        builder.HasData(data);
    }

    private IEnumerable<DocumentValidationConfiguration> SeedData()
    {
        List<DocumentValidationConfiguration> list = new List<DocumentValidationConfiguration>();

        #region PurchaseRequest

        list.Add(new DocumentValidationConfiguration()
        {
            Id = 1,
            DocumentTypeId = DocumentType.PurchaseRequest,
            DocumentStatusId = DocumentStatus.PurchaseRequestDraft,
            ValidationName = "CheckEmptyItemsAsync",
            ValidationDescription = "",
            IsEnabled = true
        });

        #endregion

        #region Invoice

        list.Add(new DocumentValidationConfiguration()
        {
            Id = 2,
            DocumentTypeId = DocumentType.Invoice,
            DocumentStatusId = DocumentStatus.InvoiceDraft,
            ValidationName = "CheckEmptyItemsAsync",
            ValidationDescription = "",
            IsEnabled = true
        });

        #endregion

        return list;
    }
}