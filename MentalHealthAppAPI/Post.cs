namespace MentalHealthAppAPI
{
    //this is the model for the post
    public class Post
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Username { get; set; } = string.Empty;
        public string ProfileImage { get; set; } = string.Empty;
        public string PostTitle { get; set; } = string.Empty;
        public string PostLabel { get; set; } = string.Empty;
        public string PostMediaUri { get; set; } = string.Empty;
        public DateTime PostTime { get; set; } = DateTime.Now;
        public int Likes { get; set; } = 0;
        public int Comments { get; set; } = 0;

       
    }

}
