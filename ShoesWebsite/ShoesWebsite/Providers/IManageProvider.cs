using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ShoesWebsite.Models;

namespace ShoesWebsite.Providers
{
    public interface IManageProvider
    {
        Task<ShoesModel> Get(Guid id);
        Task<List<ShoesModel>> GetAll();
        Task<ShoesModel> Create(ShoesModel model);
        Task<ShoesModel> Update(ShoesModel model);
        Task<bool> Delete(Guid id);

    }
}
