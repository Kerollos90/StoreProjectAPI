using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Repository.Spcesifications.ProductSpecifications
{
    public class BaseProductSpecif
    {
        public int? TypeId { get; set; }


        public int? BrandId { get; set; }


       public string? Sort { get; set; }

        public int pageindex { get; set; } = 1;

        private const int MAXPAGESIZE  = 50;

        

        private int _pagesize = 5 ;

        public int pagesize 
        {
            get => _pagesize; 
            set=> _pagesize = (value > MAXPAGESIZE) ? int.MaxValue : value; 
        }


        

        

             



    }
}
