namespace School.Response
{
    public class DbResponse : IDbResponse
    {
     

        public bool Status {  get; set; }

        public string Message {  get; set; } = string.Empty;

        public object? Data {  get; set; }
        
    }
}
