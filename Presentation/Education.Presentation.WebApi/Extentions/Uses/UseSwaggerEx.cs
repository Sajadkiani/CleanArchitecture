using Microsoft.AspNetCore.Builder;

namespace Education.Presentation.WebApi.Extentions.Uses
{
    public static class UseSwaggerEx
    {
        public static void UseAppSwagger(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }
    }
}
