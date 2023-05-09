namespace AuthServer.Models
{
    public class ResulMessage
    {
        public string Message { get; set; }

        public int StatusCode { get; set; }

        public ResulMessage()
        {

        }
        public ResulMessage(string message , int statusCode)
        {
            Message= message;
            StatusCode = statusCode;
        }
    }
}
