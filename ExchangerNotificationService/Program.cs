using ExchangerNotificationService.Helpers;
using ExchangerNotificationService.Services.Interfaces;
using ExchangerNotificationService.Services;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

// ������ ��������� �� ������������ (appsettings.json)
builder.Services.Configure<EmailSettings>(builder.Configuration.GetSection("EmailSettings"));

// ������������ ������� � ���������� ������������
builder.Services.AddScoped<IEmailService, EmailService>();

// ��������� �����������
builder.Services.AddControllers();

// �������� ��������� ������ (���������� ������ 400 ��� ������������ ������)
builder.Services.AddControllers().ConfigureApiBehaviorOptions(options =>
{
	options.InvalidModelStateResponseFactory = context =>
	{
		return new BadRequestObjectResult(context.ModelState);
	};
});

// ��������� Swagger ��� �������� ������������ API (�����������)
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// �������� Swagger, ���� ���������� �������� � ������ ����������
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();