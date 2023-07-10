using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoBiker.ViewModel.Resource
{
    public class UserResource
    {
        public string Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? CIC { get; set; } //CCCD
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
    }
}
