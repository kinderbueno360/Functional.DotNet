using System;
using System.Linq;

namespace Functional.DotNet
{
    /// <summary>
    /// This class is used on the client 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="Success"></param>
    /// <param name="Message"></param>
    /// <param name="Status"></param>
    /// <param name="Data"></param>
    public sealed record Result<T>(bool Success, string Message, int Status, T? Data);

    public sealed class Result
    {
        public static Result<T> Unauthorized<T>(string message = "") => new(false, message, 401, default);

        public static Result<T> BadRequest<T>(string message = "") => new(false, message, 400, default);

        public static Result<T> NotFound<T>(string message = "") => new(false, message, 404, default);

        public static Result<T> Error<T>(string message) => new(false, message, 500, default);

        public static Result<T> Success<T>(T data) => new(true, string.Empty, 200, data);
    }

}
