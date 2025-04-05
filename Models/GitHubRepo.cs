namespace Backend_Api.Models
{
    public class GitHubRepo
    {
        public string Name { get; set; }
        public string Language { get; set; }
        public string Description { get; set; }
        public string Html_Url { get; set; }
    }

    public class SimplifiedRepo
    {
        public string Name { get; set; }
        public string Language { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
    }
}
