namespace LetsFish.Shared.Identity
{
    public class UpdateUserRequest
    {
        public bool ActivateUser { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string PhoneNumber { get; set; }
        public bool CaseManager { get; set; }
        public string UserId { get; set; }
        public string SupervisorUserId { get; set; }
        public string NewPassword { get; set; }
    }
}