
namespace AnonymForum2.Backend
{
    public class DBHelper
    {
        private readonly AnonymForumContext _context;
        public DBHelper(AnonymForumContext context)
        {
            _context = context;
        }
    }
}
