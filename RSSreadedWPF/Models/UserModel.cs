using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSSreaderWPF
{
    public class UserModel
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public virtual ICollection<FavoriteSite> FavoriteSites { get; set; }
        public UserModel()
        {
            FavoriteSites = new List<FavoriteSite>();
        }
      
       
    }
}
