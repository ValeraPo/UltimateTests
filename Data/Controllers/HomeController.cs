using System.Linq;

namespace Data.Controllers
{
    public class HomeController
    {
        public static void Test()
        {
            using (Context db = new Context())
            {
                var players = db.Users.ToList();
            }
        }
    }
}