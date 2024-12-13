using DevExpress.ExpressApp.DC;

namespace MyProyectoXaf.Module.BusinessObjects;

[DomainComponent]
public interface IAddressModule
{
    string Street { get; set; }
    string City { get; set; }
    string State { get; set; }
    string PostalCode { get; set; }
    string Country { get; set; }
}
