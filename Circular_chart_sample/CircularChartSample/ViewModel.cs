using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CircularChartSample
{
  public class SalesViewModel
    {
        public List<SalesModel> Data { get; set; }

        public SalesViewModel()
        {
            Data = new List<SalesModel>()
            {
                new SalesModel(){Product = "iPad", SalesRate = 70},
                new SalesModel(){Product = "iPhone", SalesRate = 65},
                new SalesModel(){Product = "MacBook", SalesRate = 60},
                new SalesModel(){Product = "Mac", SalesRate = 55},
                new SalesModel(){Product = "Others", SalesRate = 50},
            };
        }
    }
    public class SalesModel
    {
        public string Product { get; set; }
        public double SalesRate { get; set; }
    }
}
