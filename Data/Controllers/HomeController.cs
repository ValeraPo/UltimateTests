using System.Linq;

namespace Data.Controllers
{
    public class HomeController
    {
        public static void Test()
        {
            using (var db = Context.GetContext())
            {
                var players = db.Users.Where( t => t.Login == "petrov" ).ToList();
            }
        }
    }
}