﻿
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
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
        //public DateTime Start_date { get; set; }
        //public DateTime End_date { get; set; }

        public Location Location { get; set; }

        [Display(Name = "Location")]
        [Required]
          public int LocationId { get; set; }

        public ICollection<Reservation> Reservations { get; set; }

       // public Reservation Reserve { get; set; }

       //[Display(Name = "Reservation")]
       // [Required]
       // public int ReserveId { get; set; }

        string image;
        public int MaxOccupancy { get; set; }
        public int PriceperNight { get; set; }

        public static implicit operator House(DbSet<House> v)
        {
            throw new NotImplementedException();
        }
    }
}