using DevExpress.ExpressApp.DC;

namespace MyProyectoXaf.Module.BusinessObjects;

[DomainComponent]

public interface ICustomerModule
{
    string Name { get; set; }
    string Contact {  get; set; }
    string Phone { get; set; }
    //IAddressModule Address { get; set; }
}
