using DevExpress.ExpressApp.DC;

namespace MyProyectoXaf.Module.BusinessObjects;

[DomainComponent]

public interface ISupplier
{
    string CompanyName { get; set; }
    string Name { get; set; }
    string Email { get; set; }
    //IAddressModule Address { get; set; }
}
