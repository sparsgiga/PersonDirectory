using PersonDirectory.Common.Configs;
using System.Globalization;

public class LocalizationMiddleware
{
    private readonly RequestDelegate _next;

    public LocalizationMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        var requestedCultures = context.Request.Headers["Accept-Language"].ToString();
        var culture = new CultureInfo(CultureLanguageConfig.CultureDefault);

        if (!string.IsNullOrEmpty(requestedCultures))
        {
            var preferredCulture = requestedCultures.Split(',')
                                        .Select(c => c.Split(';')[0].Trim())
                                        .FirstOrDefault(c => c.Equals(CultureLanguageConfig.CultureGeorgian, StringComparison.OrdinalIgnoreCase) ||
                                                             c.Equals(CultureLanguageConfig.CultureDefault, StringComparison.OrdinalIgnoreCase));

            if (preferredCulture != null)
            {
                culture = new CultureInfo(preferredCulture);
            }
        }

        CultureInfo.CurrentCulture = culture;
        CultureInfo.CurrentUICulture = culture;

        await _next(context);
    }
}
