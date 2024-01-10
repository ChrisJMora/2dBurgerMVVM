using _2dBurgerMobileApp.ViewModels;

namespace _2dBurgerMobileApp.Layouts;

public partial class ProductListView : ContentView, IView
{
    public ProductListView(ProductListViewModel productListModelView)
	{
		InitializeComponent();
		BindingContext = productListModelView;
	}
}