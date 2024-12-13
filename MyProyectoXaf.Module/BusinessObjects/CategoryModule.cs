using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;
using DevExpress.Xpo;

namespace MyProyectoXaf.Module.BusinessObjects;

[DefaultClassOptions]

public class CategoryModule : BaseObject
{ // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
    // Use CodeRush to create XPO classes and properties with a few keystrokes.
    // https://docs.devexpress.com/CodeRushForRoslyn/118557
    public CategoryModule(Session session)
        : base(session)
    {
    }
    public override void AfterConstruction()
    {
        base.AfterConstruction();
        // Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
    }


    string name;
    [RuleRequiredField("RuleRequiredField_Nombre", DefaultContexts.Save, "El Nombre es obligatorio.")]
    [Size(SizeAttribute.DefaultStringMappingFieldSize)]
    public string Name
    {
        get => name;
        set => SetPropertyValue(nameof(name), ref name, value);
    }   
}