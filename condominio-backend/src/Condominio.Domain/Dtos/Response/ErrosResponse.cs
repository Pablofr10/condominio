
using Newtonsoft.Json;

namespace Condominio.Domain.Dtos.Response
{
    public class ErrosResponse
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
        
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}