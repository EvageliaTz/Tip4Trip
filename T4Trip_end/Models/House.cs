
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace T4Trip_end.Models
{
    public class House
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please, provide a title")]
        public string Title { get; set; }
        public string Owner { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }

        public Location Location { get; set; }


        [Display(Name = "Location")]
        [Required]
        public int LocationId { get; set; }

        //public Reservation Reservation { get; set; }
        //[Display(Name = "StartDate")]
        //[Required]
        //public int ReservationId { get; set; }



        string image;
        public int MaxOccupancy { get; set; }
        public int PriceperNight { get; set; }

        //public virtual Reservation Reservation { get; set; }
    }
}