using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;
using DevExpress.Xpo;

namespace MyProyectoXaf.Module.BusinessObjects;

[DefaultClassOptions]

public class InvoiceModule : BaseObject
{ // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
    // Use CodeRush to create XPO classes and properties with a few keystrokes.
    // https://docs.devexpress.com/CodeRushForRoslyn/118557
    public InvoiceModule(Session session)
        : base(session)
    {
    }
    public override void AfterConstruction()
    {
        base.AfterConstruction();
        this.date = DateTime.Now.Date;
        // Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
    }

    SupplierModule suppliter;
    DateTime date;

    public DateTime Date
    {
        get => date;
        set => SetPropertyValue(nameof(Date), ref date, value);
    }

    [RuleRequiredField("RuleRequiredField_Cliente", DefaultContexts.Save, "No se puede guardar una factura sin cliente.")]
    public SupplierModule Suppliter
    {
        get => suppliter;
        set => SetPropertyValue(nameof(Suppliter), ref suppliter, value);
    }
    //xpcl

    [Association("Factura-FacturaDetalles"), DevExpress.Xpo.Aggregated()]
    public XPCollection<InvoiceDetailModule> InvoiceDetail
    {
        get
        {
            return GetCollection<InvoiceDetailModule>(nameof(InvoiceDetail));
        }
    }

}

