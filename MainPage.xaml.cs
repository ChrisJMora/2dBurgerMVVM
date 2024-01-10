using _2dBurgerMobileApp.Layouts;
using _2dBurgerMobileApp.ViewModels;

namespace _2dBurgerMobileApp
{
    public partial class MainPage : ContentPage
    {
        private StackLayout _mainLayout = new StackLayout();
        private ProductListView _productListView = null!;
        public ProductListViewModel ProductListModelView = null!;

        public MainPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await ProductListModelView.InitializeModelView();
            _productListView = new ProductListView(ProductListModelView);
            AddYourContentView();
        }

        private void AddYourContentView()
        {
            ScrollView scrollView = new();

            _mainLayout.Spacing = 10;
            _mainLayout.Children.Add(_productListView);

            scrollView.Content = _mainLayout;

            Content = scrollView;
        }
    }
}