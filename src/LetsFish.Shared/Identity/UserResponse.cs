namespace LetsFish.Shared.Identity
{
    public class UserResponse
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public bool IsActive { get; set; } = true;
        public bool IsCaseManager { get; set; } = true;
        public bool EmailConfirmed { get; set; }
        public string PhoneNumber { get; set; }
        public string ProfilePictureDataUrl { get; set; }
        public string SupervisorUserId { get; set; }

        public string FullName
        {
            get
            {
                if (!(String.IsNullOrEmpty(FirstName) || String.IsNullOrEmpty(LastName)))
                {
                    return $"{this.LastName}, {this.FirstName}";
                }
                return String.Empty;
            }
        }

        public UserResponse Clone()
        {
            return (UserResponse)this.MemberwiseClone();
        }
    }
}