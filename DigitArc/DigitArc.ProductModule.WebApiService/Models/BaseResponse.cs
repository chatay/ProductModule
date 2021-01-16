using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DigitArc.ProductModule.WebApiService.Models
{
    public class BaseResponse
    {
        public List<string> Errors { get; set; }
        public List<string> HasError { get; set; }
        public List<string> IsSuccessfull { get; set; }
    }
}
