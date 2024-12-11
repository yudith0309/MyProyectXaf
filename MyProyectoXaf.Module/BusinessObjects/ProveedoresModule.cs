using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;
using DevExpress.Xpo;

namespace MyProyectoXaf.Module.BusinessObjects
{
    [DefaultClassOptions]
    public class ProveedoresModule : BaseObject
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
        // Use CodeRush to create XPO classes and properties with a few keystrokes.
        // https://docs.devexpress.com/CodeRushForRoslyn/118557
        public ProveedoresModule(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
        }

        string telefono;
        string contacto;
        string nombre;

        [RuleRequiredField(DefaultContexts.Save, CustomMessageTemplate = "El nombre es obligatorio.")]
        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string Nombre
        {
            get => nombre;
            set => SetPropertyValue(nameof(Nombre), ref nombre, value);
        }


        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string Contacto
        {
            get => contacto;
            set => SetPropertyValue(nameof(Contacto), ref contacto, value);
        }

        [RuleRequiredField(DefaultContexts.Save, CustomMessageTemplate = "El teléfono es obligatorio.")]
        [Size(20)]
        public string Telefono
        {
            get => telefono;
            set => SetPropertyValue(nameof(Telefono), ref telefono, value);
        }

        [Association("Proveedores-Productos")]
        public XPCollection<ProductoModule> Productos
        {
            get
            {
                return GetCollection<ProductoModule>(nameof(Productos));
            }
        }

        [Association("Proveedores-Pedidos")]
        public XPCollection<PedidoModule> Pedidos
        {
            get
            {
                return GetCollection<PedidoModule>(nameof(Pedidos));
            }
        }
    }
}