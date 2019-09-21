using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSSreaderWPF
{
    public class FavoriteSite
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public int? UserModelId { get; set; }
        public UserModel User { get; set; }
    }
}
