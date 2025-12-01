namespace AulaWebApi.WebApi.Extensions
{
    public static class CorsExtensions
    {
        private const string PolicyName = "AllowFrontEndLocal";
        
        public static IServiceCollection AddCorsPolicy(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(PolicyName, policy =>
                {
                     policy.WithOrigins("http://127.0.0.1:5500")
                           .AllowAnyMethod()
                           .AllowAnyHeader();
                });
            });

            return services;
        }

        public static IApplicationBuilder UseCorsPolicy(this IApplicationBuilder app)
        {
            app.UseCors(PolicyName);
            return app;
        }
    }
}
