namespace School.Response
{
    public interface IDbResponse
    {
        bool Status { get; set; }

        string Message { get; set; }

        object? Data { get; set; }
    }
}
