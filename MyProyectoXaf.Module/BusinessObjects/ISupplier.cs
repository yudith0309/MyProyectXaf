using DevExpress.ExpressApp.DC;

namespace MyProyectoXaf.Module.BusinessObjects;

[DomainComponent]

public interface ISupplier
{
    string CompanyName { get; set; }
    IAddress Address { get; set; }
}
