using ExchangerNotificationService.Helpers;
using ExchangerNotificationService.Services.Interfaces;
using ExchangerNotificationService.Services;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

// Читаем настройки из конфигурации (appsettings.json)
builder.Services.Configure<EmailSettings>(builder.Configuration.GetSection("EmailSettings"));

// Регистрируем сервисы в контейнере зависимостей
builder.Services.AddScoped<IEmailService, EmailService>();

// Добавляем контроллеры
builder.Services.AddControllers();

// Включаем валидацию модели (возвращает ошибки 400 при некорректных данных)
builder.Services.AddControllers().ConfigureApiBehaviorOptions(options =>
{
	options.InvalidModelStateResponseFactory = context =>
	{
		return new BadRequestObjectResult(context.ModelState);
	};
});

// Добавляем Swagger для удобства тестирования API (опционально)
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Включаем Swagger, если приложение работает в режиме разработки
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();