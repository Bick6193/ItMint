using System;
using System.Collections.Generic;
using System.Text;
using Domain;

namespace DAL.Model
{
    public class User : EntityBase
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsOnline { get; set; }
        private List<Message> Messages { get; set; }
        private List<Channel> Channels { get; set; }
    }
}
