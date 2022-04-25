using MAUI_Demo_01.Services;
using MAUI_Demo_01.Services.Platforms;

namespace MAUI_Demo_01;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
				fonts.AddFont("Metropolis-Black.otf", "Metropolis Black");
				fonts.AddFont("Metropolis-Light.otf", "Metropolis Light");
				fonts.AddFont("Metropolis-Medium.otf", "Metropolis Medium");
				fonts.AddFont("Metropolis-Regular.otf", "Metropolis Regular");
				fonts.AddFont("Metropolis-Regular.otf", "Metropolis Regular");
				fonts.AddFont("MaterialIcons-Regular.ttf", "Material Icons");
			});

		builder.Services.AddScoped<IAuthService, AuthService>();
		builder.Services.AddSingleton<IKeyboardService, KeyboardService>();
		builder.Services.AddSingleton<IMessageService, MessageService>();

		builder.Services.AddScoped<DesktopShell>();
		builder.Services.AddScoped<AppShell>();

		// Views
		builder.Services.AddScoped<Pages.Register>();
		builder.Services.AddScoped<Pages.ForgotPassword>();
		builder.Services.AddScoped<Pages.Chat>();
		builder.Services.AddTransient<Pages.ChatDetail>();

		// ViewModels
		builder.Services.AddScoped<RegisterViewModel>();
		builder.Services.AddScoped<ForgotPasswordViewModel>();
		builder.Services.AddScoped<ChatViewModel>();
		builder.Services.AddScoped<ChatDetailViewModel>();

		return builder.Build();
	}
}
