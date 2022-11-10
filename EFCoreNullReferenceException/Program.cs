using Microsoft.EntityFrameworkCore;

namespace EFCoreNullReferenceException
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using var _context = new Context();

            var user1 = new User
            {
                Username = "One"
            };
            var user2 = new User
            {
                Username = "Two"
            };
            var user3 = new User
            {
                Username = "Three"
            };
            var user4 = new User
            {
                Username = "Four"
            };

            var list1 = new List<User> { user1, user2 };
            var list2 = new List<User> { user3, user4 };

            var model = new Call
            {
                CCUsers = list1,
                FollowUpUsers = list2
            };

            _context.Add(model);
        }
    }
}