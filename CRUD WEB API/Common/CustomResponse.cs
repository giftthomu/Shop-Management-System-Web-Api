namespace CRUD_WEB_API.Common
{
    public class CustomResponse<T>
    {
        public int StatusCode { get; set; }
        public string Remark { get; set; }
        public T Data { get; set; }
        public string Errors { get; set; }
    }
}
