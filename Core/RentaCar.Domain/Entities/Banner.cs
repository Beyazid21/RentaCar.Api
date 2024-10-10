using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentaCar.Domain.Entities
{
    public class Banner
    {
        public int BannerId { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string VieoDescription { get; set; }

        public string VideoUrl { get; set; }
    }
}
