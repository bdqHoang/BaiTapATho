using System;
using System.Collections.Generic;

namespace BaiTapATho.Models
{
    public partial class Employee
    {
        public string EmployeeId { get; set; } = null!;
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? Address { get; set; }
        public string? EmployeeName { get; set; }
        public DateTime? Birthday { get; set; }
        public string? Phone { get; set; }
        public bool? Status { get; set; }
    }
}
