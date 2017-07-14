using System;
using System.Collections.Generic;
using System.Text;
using Domain;

namespace DAL.Model
{
    public class Message : EntityBase
    {
        public string Text { get; set; }
        public bool IsViewed { get; set; }
    }
}
