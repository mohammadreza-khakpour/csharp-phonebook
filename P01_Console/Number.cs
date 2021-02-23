using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace P01_Console
{
    class Number
    {
        public int Id { get; set; }
        public string NumberCity { get; set; }

        public int PersonId { get; set; }
        [ForeignKey("PersonId")]
        public Person NumberPerson { get; set; }
    }
}
