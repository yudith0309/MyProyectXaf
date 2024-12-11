using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using MyProyectoXaf.Module.BusinessObjects;

namespace MyProyectoXaf.Module.Controllers
{
    // For more typical usage scenarios, be sure to check out https://documentation.devexpress.com/eXpressAppFramework/clsDevExpressExpressAppViewControllertopic.aspx.
    public partial class SimpleActionController : ViewController
    {
        SimpleAction MensajesSimples;
        // Use CodeRush to create Controllers and Actions with a few keystrokes.
        // https://docs.devexpress.com/CodeRushForRoslyn/403133/
        public SimpleActionController()
        {
            InitializeComponent();
            // Target required Views (via the TargetXXX properties) and create their Actions.

            //Crar Simple Action 
            //xas
            MensajesSimples = new SimpleAction(this, "MensajesSimples", "View");
            MensajesSimples.Execute += MensajesSimples_Execute;
            MensajesSimples.Caption = "Mostrar mensaje";
            MensajesSimples.TargetObjectType = typeof(ClienteModule);
            MensajesSimples.ImageName = "Mostrar mensaje";

        }
        private void MensajesSimples_Execute(object sender, SimpleActionExecuteEventArgs e)
        {
           
            // Execute your business logic (https://docs.devexpress.com/eXpressAppFramework/112737/).
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
