using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DTO
{
    public class SubCategoryDTO
    {
        public int SubCategoryID { get; set; }
        public string SubCategoryName { get; set; }
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
    }
}
