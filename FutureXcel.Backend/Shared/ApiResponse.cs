using FutureXcel.Backend.Shared.Enums;
using System.Net;
using System.Text.Json.Serialization;

namespace FutureXcel.Backend.Shared
{
    public class ApiResponse<T>
    {
        [JsonPropertyName("data")]
        public T Data { get; set; }

        [JsonPropertyName("isSuccess")]
        public bool IsSuccess { get; set; }

        [JsonPropertyName("message")]
        public string Message { get; set; }

        [JsonPropertyName("status")]
        public HttpStatusCode Status { get; set; }


        public static ApiResponse<T> Success(T data, string message = "", HttpStatusCode status = HttpStatusCode.OK)
        {
            return new ApiResponse<T>
            {
                Data = data,
                IsSuccess = true,
                Message = message,
                Status = status
            };
        }

        public static ApiResponse<T> Failure(string message, HttpStatusCode status = HttpStatusCode.BadRequest)
        {
            return new ApiResponse<T>
            {
                Data = default(T),
                IsSuccess = false,
                Message = message,
                Status = status
            };
        }
        public static ApiResponse<T> Failure(T data, string message, HttpStatusCode status = HttpStatusCode.BadRequest)
        {
            return new ApiResponse<T>
            {
                Data = data,
                IsSuccess = false,
                Message = message,
                Status = status
            };
        }

    }
}
