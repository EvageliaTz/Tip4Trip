using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace T4Trip_end.Models
{
    public class Location
    {
       
            public int Id { get; set; }
            [Required]
            public string NameCity { get; set; }
            public string NameMunicipality { get; set; }

    }
}