using Karaoke_api.AggregateModels.UserAggregates;
using Karaoke_api.DbContext;
using Karaoke_api.Features.UserFeatures.UserQueries;
using Karaoke_api.Infrastructures;
using Karaoke_api.AggregateModels.RoleAggregates;
using Karaoke_api.Features.RoleFeatures.RoleQueries;
using Karaoke_api.Features.EmployeeFeatures;
using Karaoke_api.Features.EmployeeFeatures.EmployeeQueries;
using Karaoke_api.Features.RoomTypeFeatures.RoomTypeQueries;
using Karaoke_api.Features.ServiceFeatures.ServiceQueries;
using Karaoke_api.Features.AccountFeatures.AccountQueries;
using Karaoke_api.Features.ShiftFeatures.ShiftQueries;
using Karaoke_api.Features.ShiftDetailFeatures.ShiftDetailQueries;
using Karaoke_api.Features.RoomFeatures.RoomQueries;
using Karaoke_api.Features.ExtraServiceFeatures.ExtraServiceQueries;
using Karaoke_api.Features.BookingFeatures.BookingQueries;
using Karaoke_api.Features.UserFeatures.UserMutations;
using Karaoke_api.Features.ServiceFeatures.ServiceMutations;
using Karaoke_api.Features.AccountFeatures.AccountMutations;
using Karaoke_api.Features.EmployeeFeatures.EmployeeMutations;
using Karaoke_api.Features.RoleFeatures.RoleMutations;
using Karaoke_api.Features.RoomTypeFeatures.RoomTypeMutations;
using Karaoke_api.Features.ShiftDetailFeatures.ShiftDetailMutations;
using Karaoke_api.Features.ShiftFeatures.ShiftMutations;
using Karaoke_api.Features.RoomFeatures.RoomMutations;
using Karaoke_api.Features.ExtraServiceFeatures.ExtraServiceMutations;
using Karaoke_api.Features.BookingFeatures.BookingMutaions;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddInfrastructure();
builder.Services.AddMongoQueriesCollections(builder.Configuration);
builder.Services.AddGraphQLServer()
    .AddMutationConventions(applyToAllMutations: true)
        .AddQueryType(c => c.Name("Query"))
            .AddTypeExtension<UserQueries>()
            .AddTypeExtension<RoleQueries>()
            .AddTypeExtension<EmployeeQueries>()
            .AddTypeExtension<RoomTypeQueries>()
            .AddTypeExtension<ServiceQueries>()
            .AddTypeExtension<AccountQueries>()
            .AddTypeExtension<ShiftQueries>()
            .AddTypeExtension<ShiftDetailQueries>()
            .AddTypeExtension<RoomQueries>()
            .AddTypeExtension<ExtraServiceQueries>()
            .AddTypeExtension<BookingQueries>()
        .AddMutationType(c => c.Name("Mutation"))
            .AddTypeExtension<UserMutations>()
            .AddTypeExtension<ServiceMutations>()
            .AddTypeExtension<EmployeeMutations>()
            .AddTypeExtension<RoleMutations>()
            .AddTypeExtension<AccountMutations>()
            .AddTypeExtension<RoomTypeMutations>()
            .AddTypeExtension<ShiftMutations>()
            .AddTypeExtension<ShiftDetailMutations>()
            .AddTypeExtension<RoomMutations>()
            .AddTypeExtension<ExtraServiceMutations>()
            .AddTypeExtension<BookingMutations>()
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
