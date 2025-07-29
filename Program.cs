using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<DBcontext>(options => options.UseSqlite("DataSource=SimpleBank.db"));

builder.Services.AddScoped<IDempotency, IdempotencyStore>();
builder.Services.AddScoped<AccountService>();
builder.Services.AddScoped<CustomerService>();
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();


builder.Services.AddScoped<IAccountRepository, AccountRepository>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


app.MapControllers();

app.Run();