using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace T4Trip_end.Models
{
    public class Reservation 
    {
        public int Id { get; set; }
        public House HouseRes { get; set; }
        public int HouseId { get; set; }
        public string renter { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "StartDate")]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime StartDate { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "EndDate")]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        
        public DateTime EndDate { get; set; }


        public int Occupants { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "DateOfBooking")]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DateOfBooking { get; set; }


        public string CustommerComments { get; set; }
        public double PricePerNightCharged { get; set; }


        int Status = 1; // 1 means that the status is Active

    }
}