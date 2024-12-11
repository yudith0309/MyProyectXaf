using DevExpress.ExpressApp.DC;

namespace MyProyectoXaf.Module.BusinessObjects;

[DomainComponent]

public interface ICustomer
{
    string Name { get; set; }
    IAddress Address { get; set; }
}
