using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;
using DevExpress.Xpo;

namespace MyProyectoXaf.Module.BusinessObjects
{
    [DefaultClassOptions]
    public class OrderModule : BaseObject
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
        // Use CodeRush to create XPO classes and properties with a few keystrokes.
        // https://docs.devexpress.com/CodeRushForRoslyn/118557
        public OrderModule(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
        }

        DateTime orderDate;
        int cantidadSolicitada;

        [RuleValueComparison(DefaultContexts.Save, ValueComparisonType.GreaterThan, 0,
        CustomMessageTemplate = "La cantidad solicitada debe ser mayor a 0.")]
        public int CantidadSolicitada
        {
            get => cantidadSolicitada;
            set => SetPropertyValue(nameof(CantidadSolicitada), ref cantidadSolicitada, value);
        }
        public DateTime OrderDate
        {
            get => orderDate;
            set => SetPropertyValue(nameof(OrderDate), ref orderDate, value);
        }
    }
}