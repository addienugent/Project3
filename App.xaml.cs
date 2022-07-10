namespace EcommerceAppMobile
{
    public partial class App : Application
    {
        public HomePage home = new HomePage();
        public Checkout checkout;
        public InventoryMainPage inventorymanagement = new InventoryMainPage();
        public App ()
        {
            InitializeComponent();

            MainPage = new MainPage();

            MainPage = new InventoryMainPage();
            checkout = new Checkout(home);

            MainPage = new TabbedPage
            {
                Children =
                {
                    home,
                    new MyCart(home),
                    checkout,
                    inventorymanagement
                }
            };
        }

        protected override void OnStart ()
        {
        }

        protected override void OnSleep ()
        {
        }

        protected override void OnResume ()
        {
        }
    }
}

