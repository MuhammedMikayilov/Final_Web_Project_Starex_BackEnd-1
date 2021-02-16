using Core.Repository.EFRepository;
using DataAccess.Abstract;
using Entity.Entities.HomePages;

namespace DataAccess.Concret
{
    public class EFAdvantagesDal: EFEntityRepositoryBase<Advantages, AppDbContext>, IAdvantagesDal
    {
    }
}
