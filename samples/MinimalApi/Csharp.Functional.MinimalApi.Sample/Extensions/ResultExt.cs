using Serilog;

namespace Csharp.Functional.MinimalApi.Sample.Extensions
{
    public class ResultExt
    {
        public static IResult BadRequestWithLog(Exception ex)
        {
            Log.Error(ex, "An error occurred: {ErrorMessage}", ex.Message);
            return Results.BadRequest(ex.Message);
        }
    }
}
