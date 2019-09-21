using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace RSSreaderWPF
{
    public class ReaderContext: DbContext
    {
        public ReaderContext() : base("DbConnection")
        {
        }
        public DbSet<UserModel> Users { get; set; }
        public DbSet<FavoriteSite> Favorites { get; set; }

        public UserModel UserModel
        {
            get => default(UserModel);
            set
            {
            }
        }

        public FavoriteSite FavoriteSite
        {
            get => default(FavoriteSite);
            set
            {
            }
        }
    }
}
