namespace BackOfficeManagerModels.Core
{
    public class ServerPropertiesService : IServerPropertiesService
    {

        private Uri NormalizeUrl(string adress)
        {
            if (!string.IsNullOrEmpty(adress))
            {
                try
                {
                    var uri = new Uri(adress);
                    if (uri.PathAndQuery != "/resto")
                    {
                        adress = adress + "/resto";
                    }
                }
                catch (Exception)
                {

                    throw;
                }

                return new Uri(adress);
            }
            else
            {
                throw new Exception("url is empty");
            }

        }

        public async Task<ServerProperties> GetServerProperties(string adress)
        {
            var url = NormalizeUrl(adress);

            using (var client = new HttpClient())
            {
                var endpoint = new Uri(url + "/get_server_info.jsp?encoding=UTF-8");

                var response = await client.GetAsync(endpoint);

                try
                {
                    StreamReader objReader = new StreamReader(await response.Content.ReadAsStreamAsync());
                    DeserializationResultService dtoService = new DeserializationResultService();
                    ServerProperties serverProperties = (ServerProperties)dtoService.TransferToData(url, objReader.ReadLine());
                    return serverProperties;
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }
    }
}