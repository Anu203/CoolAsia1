using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CoolAsiaApplication.Models
{
    public class Company
    {
        [Key]
        public int CompanyID { get; set; }
        public string CompanyName { get; set; }
        public string ComapnyAddress { get; set; }
        public int CompanyPhone { get; set; }
        public List<Employee> Employees { get; set; }
    }
}