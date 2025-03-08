using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Digital_Library.Models
{
    internal class Books

    {
        public int BookID { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public int GenreID { get; set; }
        public int Length { get; set; }
    }
}
