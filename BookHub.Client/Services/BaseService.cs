namespace BookHub.Client.Services
{
    public class BaseService
    {
        protected readonly HttpClient _Client;
        private readonly object baseUrl;

        public BaseService(HttpClient httpClient, IConfiguration config)
        {
            _Client = httpClient;
            baseUrl = config.GetSection("ApiSettings:BaseUrl").Value;
        }

        public async Task<T> MakeApiRequestAsync<T>(string address)
        {
            if(!string.IsNullOrEmpty(address))
            {
                var apiResponse = await _Client.GetAsync(baseUrl + address);
                
                if (apiResponse != null)
                {
                    if (apiResponse.IsSuccessStatusCode)
                    {
                        var data = await apiResponse.Content.ReadFromJsonAsync<T>();
                        if(data != null)
                        {
                            return data;
                        }
                    }
                }   
            }
            return default(T);
        }
    }
}
