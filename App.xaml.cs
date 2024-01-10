using _2dBurgerMobileApp.Domain.Sevices.DbServices;
using _2dBurgerMobileApp.ViewModels;

namespace _2dBurgerMobileApp
{
    public partial class App : Application
    {
        public App(ICategoryDbService categoryDbService, IFoodDbService foodDbService,
            IComboDbService comboDbService)
        {
            InitializeComponent();

            MainPage = new MainPage()
            {
                ProductListModelView = new ProductListViewModel(categoryDbService, foodDbService, comboDbService)
            };
            
        }
    }
}