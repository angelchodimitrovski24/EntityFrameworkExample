using Backend.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd.DDD.Models
{
    public class Customers : Base
    {
        public string CustomerName { get; set; }

        public string City { get; set; }
    }
}
