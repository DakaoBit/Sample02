using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sample02.Models.ViewModels
{
    public class MemberViewModel
    {
        public int id { get; set; }
        public string Account { get; set; }
        public string Name { get; set; }
        public Nullable<bool> Gender { get; set; }
        public Nullable<System.DateTime> Birthday { get; set; }
        public string Title { get; set; }
        public Nullable<decimal> Salary { get; set; }
    }
}