using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CoolAsiaApplication.Models
{
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public string JobTitle { get; set; }
        public decimal Salary { get; set; }
        public System.Nullable<DateTime> DateOfJoin { get; set; }
        public string Address { get; set; }
        public int Phone { get; set; }
        
        public Company Company { get; set; }
    }
}