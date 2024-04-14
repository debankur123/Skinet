namespace API.Errors
{
    public class ApiResponse
    {
        public ApiResponse(int statusCode,string message = null)
        {
            Message = message ?? GetDefaultMessageForStatusCode(statusCode);
            StatusCode = statusCode;
        }
        public int    StatusCode { get; set; }
        public string Message    { get; set; }
        private string GetDefaultMessageForStatusCode(int statusCode)
        {
            return statusCode switch {
                400 => "A bad request,you have made",
                401 => "Authorized,you are not",
                404 => "Resource found,it was not",
                500 => "OMG,you've made some serious blunder(s)",
                _ => null
            };
        }
    }
}