using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XamarinNewsReader.Data
{
    public class Favorite
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [Ignore]
        public NewsCategory Category { get; set; }

        public int CategoryId { get; set; }

        [MaxLength(100)]
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public DateTime ArticleDate { get; set; }
}

    public class NewsCategory
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Title { get; set; }

        [Ignore]
        public string InternalName { get; set; }

    }
}
