using Client.Repositories.Interface;
using Client.ViewModels;
using Newtonsoft.Json;
using System.Net.Http.Json;
using System.Reflection.Metadata;
using System.Security.AccessControl;
using System.Text;
using System.Text.Json.Serialization;

namespace Client.Repositories
{ 
    public class GeneralRepository<Entity, Key> : IRepository<Entity, Key>
    where Entity : class
    {
        private readonly string request;
        private readonly HttpClient _httpClient;
        public GeneralRepository(string request)
        {
            this.request = request;
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri("https://localhost:7290/api/")
            };
        }
        

        //DETAIL
        public async Task<ResponseListVM<Entity>> Get()
        {
            ResponseListVM<Entity> responseListVM = null;
            using (var response = await _httpClient.GetAsync(request)) //--> Disposable
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                responseListVM = JsonConvert.DeserializeObject<ResponseListVM<Entity>>(apiResponse);
            }

            return responseListVM;
        }


        //DETAIL
        public async Task<ResponseVM<Entity>> Get(Key? id)
        {
            ResponseVM<Entity> entity = null;
            using (var response = await _httpClient.GetAsync(request + id)) //--> Disposable
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                entity = JsonConvert.DeserializeObject<ResponseVM<Entity>>(apiResponse);
            }

            return entity;
        }
        
        
        //CREATE
        public async Task<ResponseStatusVM> Post(Entity entity)
        {
            ResponseStatusVM entityVM = null;
            StringContent content = new StringContent(JsonConvert.SerializeObject(entity), Encoding.UTF8, "application/json");
            using (var response = _httpClient.PostAsync(request, content).Result) //--> Disposable
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                entityVM = JsonConvert.DeserializeObject<ResponseStatusVM>(apiResponse);
            }

            return entityVM;
        }

        //EDIT
        public async Task<ResponseStatusVM> Put(Entity entity, Key id)
        {
            ResponseStatusVM entityVM = null;
            StringContent content = new StringContent(JsonConvert.SerializeObject(entity), Encoding.UTF8, "application/json");
            using (var response = _httpClient.PutAsync(request, content).Result) //--> Disposable
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                entityVM = JsonConvert.DeserializeObject<ResponseStatusVM>(apiResponse);
            }

            return entityVM;
        }


        //DELETE
        public async Task<ResponseStatusVM> Delete(Key id)
        {
            ResponseStatusVM entityVM = null;
            using (var response = _httpClient.DeleteAsync(request +id).Result) //--> Disposable
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                entityVM = JsonConvert.DeserializeObject<ResponseStatusVM>(apiResponse);
            }

            return entityVM;
        }
    }
}
