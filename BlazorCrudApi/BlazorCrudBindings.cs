using BlazorCrudApi.Interfaces;

namespace BlazorCrudApi
{
    public static class BlazorCrudBindings
    {
        public static void RegisterBindings(IServiceCollection services, IConfiguration configuration) 
        {
            services.AddScoped<IBookRepository, BookRepository>();
        }
    }
}
