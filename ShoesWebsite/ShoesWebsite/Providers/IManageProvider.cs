using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ShoesWebsite.Models;

namespace ShoesWebsite.Providers
{
    public interface IManageProvider
    {
        Task<ShoesModel> Create(ShoesModel model);
        Task<ShoesModel> Get(Guid id);
        Task Delete(Guid id);
        Task<IEnumerable<ShoesModel>> GetAll();
        Task<ShoesModel> Update(ShoesModel model);
    }
}
