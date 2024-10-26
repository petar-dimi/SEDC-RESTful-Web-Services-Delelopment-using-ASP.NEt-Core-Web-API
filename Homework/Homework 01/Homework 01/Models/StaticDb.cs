namespace Homework_01.Models
{
    public static class StaticDb
    {
        // Static list of user names
        public static List<string> Users { get; } = new List<string>
        {
            "Alice",
            "Bob",
            "Charlie",
            "Diana"
        };
    }
}
