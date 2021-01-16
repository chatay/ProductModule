using System.Collections.Generic;

namespace DigitArc.ProductModule.WebApiService.Models
{
    public class ServiceResponse<T> : BaseResponse
    {
        //Bir tane kayıt dönmesi durumunda
        public T Entity { get; set; }
        public List<T> Entities { get; set; }
        public int EntitiesCount { get; set; }

        //Alanların içi boş gelirse hataya düşmesin
        public ServiceResponse()
        {
            Errors = new List<string>();
            Entities = new List<T>();
        }
    }
}
