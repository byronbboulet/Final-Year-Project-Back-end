namespace MentalHealthAppAPI.Models
{
    public class User
    {
        public int Id { get; set; }
        // Add other properties as needed, such as:
        public string Username { get; set; }
        public string Email { get; set; }
        // Password should be stored securely, consider hashing
        public string PasswordHash { get; set; }
        
        public string ProfileImage { get; set; }

    }
}
