using System;
using System.Reflection;

namespace AuthorProblem
{
    public class StartUp
    {
        [Author("Vasil Bay")]
        public static void Main(string[] args)
        {
            Tracker tracker = new Tracker();
            Tracker.PrintMethodsByAuthor();

        }
    }
}
