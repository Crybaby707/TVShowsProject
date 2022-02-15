using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TVShows.Domain
{
    public class ContentGenre
    {

        [Key]
        public int ContentGenreID { get; set; }

        public virtual Content Content { get; set; }

        public int ContentID { get; set; }

        public virtual Genre Genre { get; set; }

        public int GenreID { get; set; }


    }
}
