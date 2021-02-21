using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.IO;

namespace Wevo.Github.Explore.Infra.CrossCutting.Ioc
{
    public static class SwaggerInjection
    {
        public static void RegisterSwagger(this IServiceCollection services, string swaggerFileName)
        {
            services.AddSwaggerGen(
               options =>
               {
                   options.SwaggerDoc("v1", new OpenApiInfo
                   {
                       Version = "API",
                       Title = "Github information query API",
                       Description = "An api developed with.NET Core Web API, to provide the github data requested in the Wevo test",
                        //TermsOfService = new Uri("https://example.com/terms"),
                        Contact = new OpenApiContact
                       {
                           Name = "Gabriel Fülber Dalpian",
                           Email = "gabrieldalpian@gmail.com",
                           Url = new Uri("https://www.linkedin.com/in/dalpian/"),
                       },
                       License = new OpenApiLicense
                       {
                           Name = string.Empty,
                           Url = new Uri("https://www.linkedin.com/in/dalpian/"),
                       }
                   });


                    // Set the comments path for the Swagger JSON and UI.
                    var xmlFile = $"{swaggerFileName}.xml";
                   var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                   options.IncludeXmlComments(xmlPath);

                   //options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                   //{
                   //    Description = "Header de autorização JWT usando esquema Bearer. Exemplo: \"Authorization: Bearer {token}\"",
                   //    Name = "Authorization",
                   //    In = ParameterLocation.Header,
                   //    Type = SecuritySchemeType.ApiKey,
                   //    Scheme = "bearer"
                   //});


                   //options.AddSecurityRequirement(
                   //    new OpenApiSecurityRequirement
                   //    {
                   //         {
                   //             new OpenApiSecurityScheme
                   //             {
                   //                 Reference = new OpenApiReference
                   //                 {
                   //                     Id = "Bearer", //The name of the previously defined security scheme.
                   //                     Type = ReferenceType.SecurityScheme
                   //                  }
                   //             },
                   //             new List<string>()
                   //         }
                   //    });
               }
           );
        }


        public static void ConfigureSwagger(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("swagger/v1/swagger.json", "V1");
                c.RoutePrefix = string.Empty;
            });
        }
    }
}
