using Karaoke_api.AggregateModels.UserAggregates;
using Karaoke_api.DbContext;
using Karaoke_api.Features.UserFeatures.UserQueries;
using Karaoke_api.Infrastructures;
using Karaoke_api.AggregateModels.RoleAggregates;
using Karaoke_api.Features.RoleFeatures.RoleQueries;
using Karaoke_api.Features.EmployeeFeatures;
using Karaoke_api.Features.EmployeeFeatures.EmployeeQueries;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddInfrastructure();
builder.Services.AddMongoQueriesCollections(builder.Configuration);
builder.Services.AddGraphQLServer()
    .AddMutationConventions(applyToAllMutations: true)
        .AddQueryType(c => c.Name("Query"))
        .AddTypeExtension<UserQueries>()
        .AddTypeExtension<RoleQueries>()
        .AddTypeExtension<EmployeeQueries>()
        .AddMongoDbFiltering()
        .AddMongoDbPagingProviders()
        .AddMongoDbSorting()
        .ModifyRequestOptions(opt => opt.IncludeExceptionDetails = true);
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
        builder => builder.AllowAnyOrigin()
                            .AllowAnyHeader()
                            .AllowAnyMethod());
});
builder.Services.AddAuthentication();
builder.Services.AddAuthorization();
builder.Services.AddHealthChecks();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseCors();
app.UseRouting()
    .UseEndpoints(endpoints =>
    {
        endpoints.MapGraphQL();
        endpoints.MapGet("/", context =>
        {
            context.Response.Redirect("/graphql");
            return Task.CompletedTask;
        });
    });

app.UseAuthentication();
app.UseAuthorization();
app.Run();
