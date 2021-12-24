namespace TVShows.Domain
{
    public class UserHasRole
    {

        public int UserRoleID { get; set; }

        public virtual Users User { get; set; }

        public int UserID { get; set; }

        public virtual Role Role { get; set; }

        public int RoleID { get; set; }

    }
}
