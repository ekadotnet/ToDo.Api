using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;

namespace ToDo.Api.Extensions
{
    /*
     To co tutaj robimy nie ma dużego znaczenia dla działania aplikacji - zachowa się ona tak samo w obu przypadkach:
     tak samo dla kodu bezpośrednio w metodach Configuration i Configure, tak samo dla kodu wydzielonego do osobnych metod.
     Co jednak jest istotne to fakt, że konfiguracja odbywa się "poza" klasą Startup - poniższe metody można sparametryzować, np pobierając wartości z appsettings.json lub użyć stałych w klasie.
     Oczywiście można też to zrobić bezpośrednio w Startup, ale stracimy wtedy na czytelności - co może być istotne w momencie kiedy konfigurowanych tam serwisów przybędzie.
     
        (no i poza tym jesteśmy kozakami, rozszerzyliśmy IServiceCollection i IApplicationBuilder ( ͡° ͜ʖ ͡°) )
    */
    public static class Swagger
    {
        public static IServiceCollection AddSwag(this IServiceCollection services) //w extension methods zawsze pierwszym parametrem jest rozszerzany typ
        {                                                                          //ze słówkiem kluczowym "this"
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "My API", Version = "v1" }); //ctrl c/v z dokumentacji .net core, najbardziej podstawowa konfiguracja generatora dokumentacji
            });

            return services;
        }

        public static IApplicationBuilder UseSwag(this IApplicationBuilder app)
        {
            app.UseSwagger();       //tutaj dodajemy middleware, które zbierze informacje o API na potrzeby generowania dokumentacji
            app.UseSwaggerUI(c =>   //tutaj dodajemy middleware, które "postawi" endpoint z gotową dokumentacją (taką, jaką przeklikiwaliśmy na zajęciach)
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

            return app;
        }
    }
}
