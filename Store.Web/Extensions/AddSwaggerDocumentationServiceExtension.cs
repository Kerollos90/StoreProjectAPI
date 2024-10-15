using Microsoft.OpenApi.Models;

namespace Store.Web.Extensions
{
    public static class AddSwaggerDocumentationServiceExtension
    {
        public static IServiceCollection AddSwaggerService(this IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
             {
                 options.SwaggerDoc("v1", new OpenApiInfo
                 {
                     Version = "v1",
                     Title = "Store API",
                     Contact = new OpenApiContact
                     {
                         Name = "Contact",
                         Email = "emadkero318@gmail.com"
                     }
                 });


                 var securityScheme = new OpenApiSecurityScheme
                 {
                     Description = "JWT Authorization header using the Bearer scheme (Example: 'Bearer 12345abcdef')",
                     Name = "Authorization",
                     In = ParameterLocation.Header,
                     Type = SecuritySchemeType.ApiKey,
                     Scheme = "Bearer",
                     Reference = new OpenApiReference
                     {
                         Type = ReferenceType.SecurityScheme,
                         Id = "Bearer"
                     }
                 };

                 options.AddSecurityDefinition("Bearer", securityScheme);


                 var securityRequirment = new OpenApiSecurityRequirement
                 {
                     {securityScheme , new[]{ "Bearer"} }



                 };

                 options.AddSecurityRequirement(securityRequirment);            
               
            });



                 return services;
        
        
        }





}
}
