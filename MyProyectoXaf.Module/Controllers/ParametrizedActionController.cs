using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;

namespace MyProyectoXaf.Module.Controllers
{
    // For more typical usage scenarios, be sure to check out https://documentation.devexpress.com/eXpressAppFramework/clsDevExpressExpressAppViewControllertopic.aspx.
    public partial class ParametrizedActionController : ViewController
    {
        ParametrizedAction Parametros;
        // Use CodeRush to create Controllers and Actions with a few keystrokes.
        // https://docs.devexpress.com/CodeRushForRoslyn/403133/
        public ParametrizedActionController()
        {
            InitializeComponent();
            // Target required Views (via the TargetXXX properties) and create their Actions.

            Parametros = new ParametrizedAction(this, "Letras", "View", typeof(string));
            Parametros.Execute += Parametros_Execute;
            
        }
        private void Parametros_Execute(object sender, ParametrizedActionExecuteEventArgs e)
        {
            var parameterValue = (string)e.ParameterCurrentValue;
            // Execute your business logic (https://docs.devexpress.com/eXpressAppFramework/112724/).
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
