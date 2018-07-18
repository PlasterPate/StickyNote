using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class NoteViewModel
    {
        [Key]
        public string Title { get; set; }

        public string Text { get; set; }

        public string Color { get; set; }
    }
}
