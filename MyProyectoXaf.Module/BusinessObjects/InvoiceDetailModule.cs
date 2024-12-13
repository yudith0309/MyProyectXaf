using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;
using DevExpress.Xpo;

namespace MyProyectoXaf.Module.BusinessObjects;

[DefaultClassOptions]
public class InvoiceDetailModule : BaseObject
{ // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
    // Use CodeRush to create XPO classes and properties with a few keystrokes.
    // https://docs.devexpress.com/CodeRushForRoslyn/118557
    public InvoiceDetailModule(Session session)
        : base(session)
    {
    }
    public override void AfterConstruction()
    {
        base.AfterConstruction();
        // Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
    }
    //xpa
    decimal subTotal;
    decimal total;
    decimal unitPrice;
    int amount;
    ProductoModule product;
    InvoiceModule invoice;

    [Association("Factura-FacturaDetalles")]
    public InvoiceModule Invoice
    {
        get => invoice;
        set => SetPropertyValue(nameof(Invoice), ref invoice, value);
    }

    //xpo      
    public ProductoModule Product
    {
        get => product;
        set => SetPropertyValue(nameof(Product), ref product, value);
    }
    //xpi
    
    [RuleRange("RuleRange_Cantidad", DefaultContexts.Save, 0.01, double.MaxValue, "La cantidad debe ser mayor a 0.")]
    public int Amount
    {
        get => amount;
        set => SetPropertyValue(nameof(Amount), ref amount, value);
    }

    //xpde         
    public decimal UnitPrice
    {
        get => unitPrice;
        set => SetPropertyValue(nameof(UnitPrice), ref unitPrice, value);
    }
    
    public decimal SubTotal
    {
        get => subTotal;
        set => SetPropertyValue(nameof(SubTotal), ref subTotal, value);
    }
    protected override void OnChanged(string propertyName, object oldValue, object newValue)
    {
        if (propertyName == nameof(Invoice))
        {
            if (this.product == null)
            {
                this.unitPrice = 0;
            }
            else
            {
                this.unitPrice = Product.PrecioUnitario;
            }
        }
        if (propertyName == nameof(Amount) || propertyName == nameof(UnitPrice))
        {
            this.Total = Amount * UnitPrice;
            this.SubTotal = Amount * UnitPrice;
        }
        base.OnChanged(propertyName, oldValue, newValue);
    }
    public decimal Total
    {
        get => total;
        set => SetPropertyValue(nameof(Total), ref total, value);
    }
    
}