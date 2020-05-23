using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PixelDataApp.Models
{
    public class LabelGroup
    {
        public int Id { get; set; }

        public String Name { get; set; }
        public String NameRu { get; set; }

        public List<Label> Labels { get; set; }
    }
}