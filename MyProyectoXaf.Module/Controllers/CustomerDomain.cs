using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using MyProyectoXaf.Module.BusinessObjects;

namespace MyProyectoXaf.Module.Controllers
{
    // For more typical usage scenarios, be sure to check out https://documentation.devexpress.com/eXpressAppFramework/clsDevExpressExpressAppViewControllertopic.aspx.
    public partial class CustomerDomain : ViewController
    {
        SimpleAction createCustomerAction;
        // Use CodeRush to create Controllers and Actions with a few keystrokes.
        // https://docs.devexpress.com/CodeRushForRoslyn/403133/
        public CustomerDomain()
        {
            InitializeComponent();
            // Target required Views (via the TargetXXX properties) and create their Actions.

            createCustomerAction = new SimpleAction(this, "createCustomerAction ", "View")
            {
                Caption = "Create Customer", 
                ConfirmationMessage = "Do you want to create a new customer?", 
                ImageName = "Action_Add" 
            }; 
            createCustomerAction.Execute += createCustomerAction_Execute;
            
        }
        private void createCustomerAction_Execute(object sender, SimpleActionExecuteEventArgs e)
        {

            // Crear un nuevo espacio de objetos para la transacción
            IObjectSpace objectSpace = Application.CreateObjectSpace(typeof(CustomerModule));

            // Crear una instancia del Domain Component
            var customer = objectSpace.CreateObject<CustomerModule>();
            customer.Name = "Natalia";
            objectSpace.CommitChanges();

            // Mostrar un mensaje de confirmación al usuario
            Application.ShowViewStrategy.ShowMessage("Customer created successfully!", InformationType.Success, 4000, InformationPosition.Top);

            // Refrescar la vista actual si es necesario
            View.ObjectSpace.Refresh();
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
