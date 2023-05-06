using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Student_MS.Database;
using Student_MS.Service;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.Configure<StudentStoreDBConfiguration>
(
    builder.Configuration.GetSection(nameof(StudentStoreDBConfiguration))
);
builder.Services.AddSingleton<IStudentStoreDatabaseConfiguration>
(
    sp => sp.GetRequiredService<IOptions<StudentStoreDBConfiguration>>().Value
);

builder.Services.AddSingleton<IMongoClient>
(
    s => new MongoClient(builder.Configuration.GetValue<string>
    ("StudentMangDBSettings:ConnectionString"))
);

builder.Services.AddScoped<IStudentService, StudentServices>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
