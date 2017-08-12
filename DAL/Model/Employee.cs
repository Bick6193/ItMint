using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Model
{
    public class Employee : ApplicationUser
    {
        public DateTime WorkingHoursStartTime { get; set; }
        public DateTime WorkingHoursEndTime { get; set; }
        public string Location { get; set; }
        public bool Active { get; set; }
    }
}
