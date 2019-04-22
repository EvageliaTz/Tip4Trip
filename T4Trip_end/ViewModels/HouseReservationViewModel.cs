using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using T4Trip_end.Models;

namespace T4Trip_end.ViewModels
{
    public class HouseReservationViewModel
    {
        public House House { get; set; }
        public List<Reservation> Reservations1 { get; set; }
    }
}