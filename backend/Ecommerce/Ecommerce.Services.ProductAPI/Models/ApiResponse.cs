namespace Ecommerce.Services.ProductAPI.Models
{
    public class ApiResponse<T>
    {
        public bool Success { get; set; }
        public T? Data { get; set; }
        public string Message { get; set; }
        public List<string>? Errors { get; set; }

        private ApiResponse(bool success, T? data, string message, List<string>? errors = null)
        {
            Success = success;
            Data = data;
            Message = message;
            Errors = errors;
        }

        public static ApiResponse<T> Successful(T data, string message = "Operation completed successfully.")
        {
            return new ApiResponse<T>(true, data, message);
        }

        public static ApiResponse<T> Failure(string errorMessage)
        {
            return new ApiResponse<T>(false, default, errorMessage, new List<string> { errorMessage });
        }

        public static ApiResponse<T> Failure(List<string> errors, string message = "An error occurred.")
        {
            return new ApiResponse<T>(false, default, message, errors);
        }
    }
}
