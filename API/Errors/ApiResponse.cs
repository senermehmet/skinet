namespace API.Errors
{
    public class ApiResponse
    {
        public ApiResponse(int statusCode, string message=null)
        {
            StatusCode = statusCode;
            Message = message ?? GetDefaultForStatusCode(statusCode);
        }

        private string GetDefaultForStatusCode(int statusCode)
        {
            return statusCode switch
            {
                    400 => "A bad reques, you have made.",
                    401 => "Authorized, you are not.",
                    404 => "Resource path, it was not.",
                    500 => "Errors ara the path to dark side. The server cannot find a better 5xx error code to response. Sometimes, server administrators log error responses like the 500 status code with more details about the request to prevent the error from happening again in the future.",
                    
                    _ => null
            };
        }

        public int StatusCode { get; set; }
        public string Message { get; set; }
    }
}