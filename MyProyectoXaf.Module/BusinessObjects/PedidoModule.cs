using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;
using DevExpress.Xpo;

namespace MyProyectoXaf.Module.BusinessObjects
{
    [DefaultClassOptions]
    public class PedidoModule : BaseObject
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
        // Use CodeRush to create XPO classes and properties with a few keystrokes.
        // https://docs.devexpress.com/CodeRushForRoslyn/118557
        public PedidoModule(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
        }

        ProveedoresModule propertyName;
        DateTime fechaPedido;
        int cantidadSolicitada;

        [RuleValueComparison(DefaultContexts.Save, ValueComparisonType.GreaterThan, 0,
        CustomMessageTemplate = "La cantidad solicitada debe ser mayor a 0.")]
        public int CantidadSolicitada
        {
            get => cantidadSolicitada;
            set => SetPropertyValue(nameof(CantidadSolicitada), ref cantidadSolicitada, value);
        }
        public DateTime FechaPedido
        {
            get => fechaPedido;
            set => SetPropertyValue(nameof(FechaPedido), ref fechaPedido, value);
        }


        [Association("Proveedores-Pedidos")]
        public ProveedoresModule PropertyName
        {
            get => propertyName;
            set => SetPropertyValue(nameof(PropertyName), ref propertyName, value);
        }
    }
}