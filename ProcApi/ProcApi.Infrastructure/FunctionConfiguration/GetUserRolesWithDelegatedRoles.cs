using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProcApi.Domain.ResultSets;

namespace ProcApi.Infrastructure.FunctionConfiguration;

public class GetUserRolesWithDelegatedRoles : IEntityTypeConfiguration<UserRoleResultSet>
{
    public void Configure(EntityTypeBuilder<UserRoleResultSet> builder)
    {
        builder.HasNoKey();
        builder.ToFunction("get_user_roles_with_delegated_roles");
    }
}