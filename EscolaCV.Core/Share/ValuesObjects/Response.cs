using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscolaCV.Core.Share.ValuesObjects
{
    public class Response
    {
        public string Message { get; set; } = string.Empty;
        public int Status { get; set; } = 400;
        public bool IsSuccess => Status is >= 200 and <= 299;
    }
}
