using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;
using DevExpress.Xpo;

namespace MyProyectoXaf.Module.BusinessObjects;

[DefaultClassOptions]

[RuleCombinationOfPropertiesIsUnique("Nombre Apellidos", DefaultContexts.Save, "Nombre, Apellidos", CustomMessageTemplate = "El nombre y los apellidos deben ser unicos")]

public class SupplierModule : BaseObject,ISupplier
{ // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
    // Use CodeRush to create XPO classes and properties with a few keystrokes.
    // https://docs.devexpress.com/CodeRushForRoslyn/118557
    public SupplierModule(Session session)
        : base(session)
    {
    }
    public override void AfterConstruction()
    {
        base.AfterConstruction();
        // Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
    }

    string companyName;
    string name;
    string email;

    [RuleRequiredField("NombreRequired", DefaultContexts.Save, CustomMessageTemplate = "El nombre es obligatorio.")]

    [Size(SizeAttribute.DefaultStringMappingFieldSize)]
    public string Name
    {
        get => name;
        set => SetPropertyValue(nameof(Name), ref name, value);
    }


    [RuleRequiredField("ApellidoRequired", DefaultContexts.Save, CustomMessageTemplate = "El apellido es obligatorio.")]


    [Size(SizeAttribute.DefaultStringMappingFieldSize)]
    public string Email
    {
        get => email;
        set => SetPropertyValue(nameof(Email), ref email, value);
    }

    
    [Size(SizeAttribute.DefaultStringMappingFieldSize)]
    public string CompanyName
    {
        get => companyName;
        set => SetPropertyValue(nameof(CompanyName), ref companyName, value);
    }

    [Association("SupplierModule-AddressModules")]
    public XPCollection<AddressModule> AddressModules
    {
        get
        {
            return GetCollection<AddressModule>(nameof(AddressModules));
        }
    }

}