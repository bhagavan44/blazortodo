using System.Collections.Generic;
using System.Threading.Tasks;
using BlazorTodo.Models;
using RestSharp;

namespace BlazorTodo.Services
{
    public class TodoService
    {
        private readonly IRestClient restClient;

        public TodoService()
        {
            restClient = new RestClient
            {
                BaseUrl = new System.Uri("https://jsonplaceholder.typicode.com/todos"),
                Timeout = 2000
            };
        }

        public async Task<List<Todo>> GetAsync()
        {
            RestRequest restRequest = new RestRequest("?_limit=5");

            var response = await restClient.ExecuteGetTaskAsync<List<Todo>>(restRequest);

            return response.Data;
        }

        public async Task<Todo> ToggleCompletedAsync(Todo todo)
        {
            RestRequest restRequest = new RestRequest("/" + todo.Id);
            restRequest.AddHeader("Content-Type", "application/json");
            restRequest.AddJsonBody(todo);

            var response = await restClient.PutAsync<Todo>(restRequest);

            return response;
        }

        public async Task<Todo> DeleteAsync(Todo todo)
        {
            RestRequest restRequest = new RestRequest("/" + todo.Id);
            restRequest.AddHeader("Content-Type", "application/json");

            var response = await restClient.DeleteAsync<Todo>(restRequest);

            return response;
        }

        public async Task<Todo> AddAsync(Todo todo)
        {
            RestRequest restRequest = new RestRequest();
            restRequest.AddHeader("Content-Type", "application/json");
            restRequest.AddJsonBody(todo);

            var response = await restClient.PostAsync<Todo>(restRequest);

            return response;
        }
    }
}
