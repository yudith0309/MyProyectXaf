using DevExpress.ExpressApp.DC;

namespace MyProyectoXaf.Module.BusinessObjects;

[DomainComponent]
public interface IAddress
{
    string Street { get; set; }
    string City { get; set; }
    string PostalCode { get; set; }
}
