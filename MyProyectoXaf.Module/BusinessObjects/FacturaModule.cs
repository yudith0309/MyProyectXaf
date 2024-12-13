using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;
using DevExpress.Xpo;

namespace MyProyectoXaf.Module.BusinessObjects;

[DefaultClassOptions]

public class FacturaModule : BaseObject
{ // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
    // Use CodeRush to create XPO classes and properties with a few keystrokes.
    // https://docs.devexpress.com/CodeRushForRoslyn/118557
    public FacturaModule(Session session)
        : base(session)
    {
    }
    public override void AfterConstruction()
    {
        base.AfterConstruction();
        this.fecha = DateTime.Now.Date;
        // Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
    }

    SupplierModule cliente;
    DateTime fecha;

    public DateTime Fecha
    {
        get => fecha;
        set => SetPropertyValue(nameof(Fecha), ref fecha, value);
    }

    [RuleRequiredField("RuleRequiredField_Cliente", DefaultContexts.Save, "No se puede guardar una factura sin cliente.")]
    public SupplierModule Cliente
    {
        get => cliente;
        set => SetPropertyValue(nameof(Cliente), ref cliente, value);
    }
    //xpcl

    [Association("Factura-FacturaDetalles"), DevExpress.Xpo.Aggregated()]
    public XPCollection<FacturaDetalleModule> FacturaDetalles
    {
        get
        {
            return GetCollection<FacturaDetalleModule>(nameof(FacturaDetalles));
        }
    }

}

