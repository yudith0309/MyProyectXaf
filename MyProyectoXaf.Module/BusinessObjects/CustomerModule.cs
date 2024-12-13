using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;
using DevExpress.Xpo;

namespace MyProyectoXaf.Module.BusinessObjects;

[DefaultClassOptions]
public class CustomerModule : BaseObject, ICustomerModule
{ // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
    // Use CodeRush to create XPO classes and properties with a few keystrokes.
    // https://docs.devexpress.com/CodeRushForRoslyn/118557
    public CustomerModule(Session session)
        : base(session)
    {
    }
    public override void AfterConstruction()
    {
        base.AfterConstruction();
        // Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
    }

    string phone;
    string contact;
    string name;
    AddressModule address;

    [RuleRequiredField(DefaultContexts.Save, CustomMessageTemplate = "El nombre es obligatorio.")]
    [Size(SizeAttribute.DefaultStringMappingFieldSize)]
    public string Name
    {
        get => name;
        set => SetPropertyValue(nameof(Name), ref name, value);
    }


    [Size(SizeAttribute.DefaultStringMappingFieldSize)]
    public string Contact
    {
        get => contact;
        set => SetPropertyValue(nameof(Contact), ref contact, value);
    }

    [RuleRequiredField(DefaultContexts.Save, CustomMessageTemplate = "El teléfono es obligatorio.")]
    [Size(20)]
    public string Phone
    {
        get => phone;
        set => SetPropertyValue(nameof(Phone), ref phone, value);
    }   
    
    [Association("Customer-Address")]
    public XPCollection<AddressModule> Address
    {
        get
        {
            return GetCollection<AddressModule>(nameof(Address));
        }
    }
}