using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using MyProyectoXaf.Module.BusinessObjects;

namespace MyProyectoXaf.Module.Controllers
{
    // For more typical usage scenarios, be sure to check out https://documentation.devexpress.com/eXpressAppFramework/clsDevExpressExpressAppViewControllertopic.aspx.
    public partial class PopupWindowShowActionController : ViewController
    {
        PopupWindowShowAction MostrarListado;
        // Use CodeRush to create Controllers and Actions with a few keystrokes.
        // https://docs.devexpress.com/CodeRushForRoslyn/403133/
        public PopupWindowShowActionController()
        {
            InitializeComponent();
            // Target required Views (via the TargetXXX properties) and create their Actions.
            //xapw
            //Acción que se utiliza para mostrar una ventana emergente (popup) dentro de la interfaz de usuario
            MostrarListado = new PopupWindowShowAction(this, "MostrarListado", "View");
            MostrarListado.Execute += MostrarListado_Execute;
            MostrarListado.CustomizePopupWindowParams += MostrarListado_CustomizePopupWindowParams;
            MostrarListado.Caption = "Mostrar vista de clientes";


        }
        private void MostrarListado_Execute(object sender, PopupWindowShowActionExecuteEventArgs e)
        {
            var selectedPopupWindowObjects = e.PopupWindowViewSelectedObjects;
            var selectedSourceViewObjects = e.SelectedObjects;
            // Execute your business logic (https://docs.devexpress.com/eXpressAppFramework/112723/).
        }
        private void MostrarListado_CustomizePopupWindowParams(object sender, CustomizePopupWindowParamsEventArgs e)
        {
            var os = this.Application.CreateObjectSpace(typeof(SupplierModule));

            // Set the e.View parameter to a newly created view (https://docs.devexpress.com/eXpressAppFramework/112723/).
        }
        protected override void OnActivated()
        {
            base.OnActivated();
            // Perform various tasks depending on the target View.
        }
        protected override void OnViewControlsCreated()
        {
            base.OnViewControlsCreated();
            // Access and customize the target View control.
        }
        protected override void OnDeactivated()
        {
            // Unsubscribe from previously subscribed events and release other references and resources.
            base.OnDeactivated();
        }
    }
}
