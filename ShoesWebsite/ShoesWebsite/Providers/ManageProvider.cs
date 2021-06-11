using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShoesWebsite.Models;

namespace ShoesWebsite.Providers
{
    public class ManageProvider : IManageProvider
    {
        private readonly List<ShoesModel> _entities = new List<ShoesModel>();
        public Task<ShoesModel> Create(ShoesModel model)
        {
            model.Id = Guid.NewGuid();
            _entities.Add(model);
            return Task.FromResult(model);
        }

        public Task<IEnumerable<ShoesModel>> GetAll()
        {
            return Task.FromResult<IEnumerable<ShoesModel>>(_entities.OrderBy(o => o.Name));
        }

        public Task<ShoesModel> Get(Guid id)
        {
            var entity = _entities.FirstOrDefault(i => i.Id == id);
            return Task.FromResult(entity);
        }

        public Task Delete(Guid id)
        {
            _entities.RemoveAll(i => i.Id == id);

            return Task.CompletedTask;
        }

        public async Task<ShoesModel> Update(ShoesModel model)
        {
            var entity = await Get(model.Id);
            entity.Brand = model.Brand;
            entity.Name = model.Name;
            entity.Category = model.Category;
            entity.Price = model.Price;

            return entity;
        }
    }
}
