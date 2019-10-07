using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MilanCorp.Domain.Models
{
    public class Aniversariante
    {
        public Guid id { get; set; }
        public string title { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
         public DateTime? start { get; set; }
    }
}
