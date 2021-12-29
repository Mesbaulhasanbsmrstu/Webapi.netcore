using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Webapi.netcore.Model
{
    public class Books
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Descriptions { get; set; }
    }
}
