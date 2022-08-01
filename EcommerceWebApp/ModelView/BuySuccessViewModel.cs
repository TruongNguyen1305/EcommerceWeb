using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceWebApp.ModelView
{
    public class BuySuccessViewModel
    {
        public int OrderId { get; set; }
        public int CustomerId { get; set; }
        public string FullName { get; set; }
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }
        public string Address { get; set; }
        public int PaymentID { get; set; }
        public string Note { get; set; }
    }
}
