namespace SWCLMS.Models.Responses
{
    public class DataResponse<T> : Response
    {
        public T Data { get; set; }
    }
}
