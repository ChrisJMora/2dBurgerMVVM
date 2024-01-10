using _2dBurgerMobileApp.Domain.Entities.Models;
using _2dBurgerMobileApp.Domain.Sevices.DbServices;
using _2dBurgerMobileApp.Extension;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;

namespace _2dBurgerMobileApp.ViewModels
{
    public class ProductListViewModel : BindableObject, INotifyPropertyChanged
    {
        private readonly ICategoryDbService _categoryDbService;
        private readonly IFoodDbService _foodDbService;
        private readonly IComboDbService _comboDbService;

        private bool _categoryStatusIsFood;
        public ObservableCollection<Category> FoodCategories { get; set; } = new();
        public ObservableCollection<Category> ComboCategories { get; set; } = new();
        public ObservableCollection<Category> Categories { get; set; } = new();

        public ObservableCollection<Product> Foods { get; set; } = new();
        public ObservableCollection<Product> Combos { get; set; } = new();
        public ObservableCollection<Product> Products { get; set; } = new();


        private string _selectedOption;
        public string SelectedOption
        {
            get { return _selectedOption; }
            set
            {
                _selectedOption = value;
                OnPropertyChanged(nameof(SelectedOption));

                PickerSelectedItemCommand.Execute(_selectedOption);
            }
        }

        private Category _selectedCategory;
        public Category SelectedCategory
        {
            get { return _selectedCategory; }
            set
            {
                _selectedCategory = value;
                OnPropertyChanged(nameof(SelectedCategory));

                PickerSelectedCategoryCommand.Execute(_selectedCategory);
            }
        }


        public ICommand PickerSelectedItemCommand { get; private set; }
        public ICommand PickerSelectedCategoryCommand { get; private set; }

        public ProductListViewModel(ICategoryDbService categoryDbService, IFoodDbService foodDbService,
            IComboDbService comboDbService)
        {
            _categoryDbService = categoryDbService;
            _foodDbService = foodDbService;
            _comboDbService = comboDbService;


            PickerSelectedItemCommand = new Command<string>(HandlePickerSelectedItem);
            PickerSelectedCategoryCommand = new Command<Category>(HandlePickerSelectedCategory);
        }

        public async Task InitializeModelView()
        {
            FoodCategories = new ObservableCollection<Category>(await _categoryDbService.GetFoodCategoriesAsync());
            ComboCategories = new ObservableCollection<Category>(await _categoryDbService.GetComboCategoriesAsync());
            Categories.AddRange(FoodCategories);

            Foods = new ObservableCollection<Product>(await _foodDbService.GetFoodsAsync());
            Combos = new ObservableCollection<Product>(await _comboDbService.GetCombosAsync());
            Products.AddRange(Foods);
        }

        private void HandlePickerSelectedItem(string productType)
        {
            Products.Clear();
            Categories.Clear();

            if (productType.Equals("Food"))
            {
                _categoryStatusIsFood = true;
                Products.AddRange(Foods);
                Categories.AddRange(FoodCategories);
            }

            if (productType.Equals("Combo"))
            {
                _categoryStatusIsFood = false;
                Products.AddRange(Combos);
                Categories.AddRange(ComboCategories);
            }
        }

        private async void HandlePickerSelectedCategory(Category category)
        {
            Products.Clear();
            if (_categoryStatusIsFood)
            {
                Products.AddRange(await _foodDbService.GetFoodsByCategoryIdAsync(category.Id));
            }
            else
            {
                Products.AddRange(await _comboDbService.GetCombosByCategoryIdAsync(category.Id));
            }
        }
    }
}