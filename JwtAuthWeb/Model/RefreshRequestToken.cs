namespace JwtAuthWeb.Model
{
    public class RefreshRequestToken
    {
        public Guid Userid { get; set; }

        public string RefreshToken { get; set; } = string.Empty;

    }
}
