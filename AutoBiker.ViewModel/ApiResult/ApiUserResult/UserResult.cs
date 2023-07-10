using AutoBiker.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoBiker.ViewModel.ApiResult.ApiUserResult
{
    public class UserResult : BaseResult
    {
        public AppUser user { get; set; }
        public UserResult(bool success, string message, AppUser user) : base(success, message) { }
        public UserResult(AppUser user) : this(true, string.Empty, user)
        { }

        public UserResult(string message) : this(false, message, null)
        { }
    }
}
