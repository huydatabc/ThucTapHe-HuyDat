// <auto-generated />

using System.CodeDom.Compiler;
using System.Data.Entity.Migrations.Infrastructure;
using System.Resources;

namespace triluatsoft.tls.Migrations
{
    [GeneratedCode("EntityFramework.Migrations", "6.1.2-31219")]
    public sealed partial class Tenant_Changed_To_FullAuditedEntity_From_AuditedEntity : IMigrationMetadata
    {
        private readonly ResourceManager Resources = new ResourceManager(typeof(Tenant_Changed_To_FullAuditedEntity_From_AuditedEntity));
        
        string IMigrationMetadata.Id
        {
            get { return "201503122019249_Tenant_Changed_To_FullAuditedEntity_From_AuditedEntity"; }
        }
        
        string IMigrationMetadata.Source
        {
            get { return null; }
        }
        
        string IMigrationMetadata.Target
        {
            get { return Resources.GetString("Target"); }
        }
    }
}
