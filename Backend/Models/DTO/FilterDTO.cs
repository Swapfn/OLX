using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DTO
{
    public class FilterDTO
    {
        public int? locationId { set; get; }
        public int? subCategoryId { set; get; }
        public int? minPrice { get; set; }
        public int? maxPrice { get; set; }
        /*public int? categoryId { get; set; }*/
    }
}
