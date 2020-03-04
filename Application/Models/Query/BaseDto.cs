namespace dotnet_mediatr.Application.Models.Query
{
    public abstract class BaseDto
    {
        public bool Success { set; get; }
        public string Message { set; get; }
    }
}