namespace TVShows.Domain
{
    public class Contents
    {
        public int ID { get; set; }
        public string Title { get; set; }

        public string Description { get; set; }

        public int Rate { get; set; }

        public int PremiereDate { get; set; }

        public string Img { get; set; }

        public virtual Genres GenreID { get; set; }

        public UserShowLists UserShowLists { get; set; }

    }
}