namespace EscolaCV.Manager.ValuesObjects
{
    public class Response : EscolaCV.Core.Share.ValuesObjects.Response
    {
        public object? Data { get; set; }

        protected Response()
        {

        }

        public Response(string message, int status)
        {
            Message = message;
            Status = status;
        }

        public Response(string message, object data=null!)
        {
            Message = message;
            Status = 201;
            Data = data;
        }

        public Response( object data = null!)
        {
            Status = 200;
            Data = data;
        }
    }

    public record ResponseData(object data);
}
