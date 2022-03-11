using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Northwind.Models
{
    [Table("CondicionMultiple")]
    public partial class CondicionMultiple
    {
        [Key, Column(Order = 1)]
        public int OrderID { get; set; }
        [Key, Column(Order = 2)]
        public int ProductID { get; set; }
    }
}
