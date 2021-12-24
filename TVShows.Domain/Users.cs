namespace TVShows.Domain
{
    public class Users
    {
        public int UserID { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string UserRoles { get; set; }

        public int UserRoleID { get; set; }

        public int RoleID { get; set; }

        public UserShowLists UserShowLists { get; set; }

    }
}
