using Lipy.HeaderApi.Interfaces;
using Lipy.HeaderApi.Model;

namespace Lipy.HeaderApi.Repository
{
    public class HeaderRepository : BaseRepository<Header>, IHeaderRepository
    {
        public HeaderRepository(IHeaderDbContext context) : base(context)
        {
        }
    }
}
