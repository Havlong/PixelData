using System;
using System.ComponentModel.DataAnnotations;

namespace PixelDataApp.Models
{
    public class Label
    {
        public int Id { get; set; }

        public String Name { get; set; }
        public String NameRu { get; set; }
        public String StringID { get; set; }
    }
}