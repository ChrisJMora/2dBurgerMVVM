using _2dBurgerMobileApp.Domain.Sevices.DbServices;
using _2dBurgerMobileApp.Services.DbServices;
using Microsoft.Extensions.Logging;

namespace _2dBurgerMobileApp
{
	public static class MauiProgram
	{
		public static MauiApp CreateMauiApp()
		{
			var builder = MauiApp.CreateBuilder();
			//Services
			builder.Services.AddScoped<IBaseDbService, BaseDbService>();
			builder.Services.AddScoped<ICategoryDbService, CategoryDbService>();
			builder.Services.AddScoped<IComboDbService, ComboDbService>();
			builder.Services.AddScoped<IFoodDbService, FoodDbService>();
			builder.Services.AddScoped<IOrderDbServices, OrderDbService>();
			builder.Services.AddScoped<IUserDbService, UserDbService>();

			builder
				.UseMauiApp<App>()
				.ConfigureFonts(fonts =>
				{
					fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
					fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
				});

#if DEBUG
		builder.Logging.AddDebug();
#endif

			return builder.Build();
		}
	}
}