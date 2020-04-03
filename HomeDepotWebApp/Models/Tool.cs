using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HomeDepotWebApp.Models
{
    public class Tool
    {
        
        public int Id { get; set; }
        public String Name { get; set; }
        public String Description { get; set; }
        public double Depos { get; set; }
        public double DayPrice { get; set; }

        
    }
}