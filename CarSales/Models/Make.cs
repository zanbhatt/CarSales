using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarSales.Models
{
    public class Make
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<Model> modelList { get; set; }
        public IEnumerable<BodyType> bodyTypeList { get; set; }

    }
}