using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using ShoesWebsite.Helpers;
using ShoesWebsite.Models;

namespace ShoesWebsite.Providers
{
    public class ManageProvider : IManageProvider
    {
        private readonly IHttpHelper _httpHelper;
        private readonly IOptions<ApiSettings> _apiSettings;

        public ManageProvider(IHttpHelper httpHelper, IOptions<ApiSettings> apiSettings)
        {
            _httpHelper = httpHelper;
            _apiSettings = apiSettings;
        }

        public async Task<ShoesModel> Get(Guid id)
        {
            var url = GetApiUrl(id.ToString());
            var response = await _httpHelper.Send<ShoesModel>(url, HttpMethod.Get);
            return response;
        }

        public async Task<List<ShoesModel>> GetAll()
        {
            var url = GetApiUrl(string.Empty);
            var response = await _httpHelper.Send<List<ShoesModel>>(url, HttpMethod.Get);
            return response;
        }

        public async Task<ShoesModel> Create(ShoesModel model)
        {
            var url = GetApiUrl(string.Empty);
            var response = await _httpHelper.Send<ShoesModel>(url, HttpMethod.Post, model);
            return response;
        }

        public async Task<ShoesModel> Update(ShoesModel model)
        {
            var url = GetApiUrl(string.Empty);
            var response = await _httpHelper.Send<ShoesModel>(url, HttpMethod.Put, model);
            return response;
        }

        public Task<bool> Delete(Guid id)
        {
            var url = GetApiUrl(id.ToString());
            return _httpHelper.Send(url, HttpMethod.Delete);
        }

        private string GetApiUrl(string path)
        {
            return $"{_apiSettings.Value.Host}/manage/{path}";
        }
    }
}
