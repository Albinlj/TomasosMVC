using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tomasos.Models.AdminViewModels
{
    public class UserEditViewModel
    {
        public List<UserPremiumViewModel> Users { get; set; }

        public UserEditViewModel()
        {
            Users = new List<UserPremiumViewModel>();
        }

        public class UserPremiumViewModel
        {
            public string Name { get; set; }
            public int BonusPoints { get; set; }
            public string UserId { get; set; }
            public bool IsPremium { get; set; }
        }


    }
}
