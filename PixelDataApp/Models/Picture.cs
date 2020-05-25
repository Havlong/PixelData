using System;
using System.ComponentModel.DataAnnotations;

namespace PixelDataApp.Models
{
    public class Picture
    {
        public int Id { get; set; }

        public String Filepath { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime PublishTime { get; set; }
        public String Info { get; set; }

        public int AnswerId { get; set; }
        public Label Answer { get; set; }
    }
}