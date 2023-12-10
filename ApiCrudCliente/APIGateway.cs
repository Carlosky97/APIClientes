using ApiCrudCliente.Models;
using Newtonsoft.Json;
using System.Net;
using System.Text;

namespace ApiCrudCliente
{
    public class APIGateway
    {
        private string url = "https://localhost:7017/api/Cliente";
        private HttpClient httpClient = new HttpClient();

        public List<Cliente> ListClientes()
        {
            List<Cliente> clientes = new List<Cliente>();

            if(url.Trim().Substring(0,5).ToLower() == "https")
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            try 
            {
                HttpResponseMessage response = httpClient.GetAsync(url).Result;

                if (response.IsSuccessStatusCode)
                {
                    string result = response.Content.ReadAsStringAsync().Result;
                    var datacol = JsonConvert.DeserializeObject<List<Cliente>>(result);

                    if(datacol != null )
                    {
                        clientes = datacol;
                    }
                }
                else
                {
                    string result = response.Content.ReadAsStringAsync().Result;
                    throw new Exception("Se produjo un error en el punto de conexión de la API, Información de error." + result);
                }
            
            }catch(Exception ex) 
            {
                throw new Exception("Se produjo un error en el punto de conexión de la API, Información de error." + ex.Message);
            }
            finally { }
            return clientes;
        }

        public Cliente CreateCliente(Cliente cliente)
        {
            if (url.Trim().Substring(0, 5).ToLower() == "https")
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            string json = JsonConvert.SerializeObject(cliente);

            try 
            {
                HttpResponseMessage response = httpClient.PostAsync(url, new StringContent(json, Encoding.UTF8, "application/json")).Result;
                if (response.IsSuccessStatusCode)
                {
                    string result = response.Content.ReadAsStringAsync().Result;
                    var data = JsonConvert.DeserializeObject<Cliente>(result);
                    if (data != null)
                        cliente = data;
                }
                else
                {
                    string result = response.Content.ReadAsStringAsync().Result;
                    throw new Exception("Se produjo un error en el punto de conexión de la API, Información de error." + result);
                }
            }
            catch(Exception ex) 
            {
                throw new Exception("Se produjo un error en el punto de conexión de la API, Información de error." + ex.Message); 
            }
            finally { }
            return cliente;
        }

        public Cliente GetCliente(int id)
        {
            Cliente cliente = new Cliente();
            url = url + "/" + id;
            if (url.Trim().Substring(0, 5).ToLower() == "https")
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            try
            {
                HttpResponseMessage response = httpClient.GetAsync(url).Result;
                if (response.IsSuccessStatusCode)
                {
                    string result = response.Content.ReadAsStringAsync().Result;
                    var data = JsonConvert.DeserializeObject<Cliente>(result);
                    if(data != null)
                        cliente = data;
                }
                else
                {
                    string result = response.Content.ReadAsStringAsync().Result;
                    throw new Exception("Se produjo un error en el punto de conexión de la API, Información de error." + result);
                }
            }catch(Exception ex)
            {
                throw new Exception("Se produjo un error en el punto de conexión de la API, Información de error." + ex.Message);
            }
            finally { }
            return cliente;
        }

        public void UpdateCliente(Cliente cliente)
        {
            if (url.Trim().Substring(0, 5).ToLower() == "https")
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            int id = cliente.id;

            url = url + "/" + id;
            string Json = JsonConvert.SerializeObject(cliente);

            try
            {
                HttpResponseMessage response = httpClient.PutAsync(url, new StringContent(Json, Encoding.UTF8, "application/json")).Result;
                if (response.IsSuccessStatusCode)
                {
                    string result = response.Content.ReadAsStringAsync().Result;
                    throw new Exception("Se produjo un error en el punto de conexión de la API, Información de error." + result);
                }
            }
            catch (Exception)
            {
                //throw new Exception("Se produjo un error en el punto de conexión de la API, Información de error." + ex.Message);
            }
            finally { }
            return;
        }

        public void DeleteCliente(int id)
        {
            if (url.Trim().Substring(0, 5).ToLower() == "https")
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

                url = url + "/" + id;
            try
            {
                HttpResponseMessage response = httpClient.DeleteAsync(url).Result;
                if (response.IsSuccessStatusCode)
                {
                    string result = response.Content.ReadAsStringAsync().Result;
                    throw new Exception("Se produjo un error en el punto de conexión de la API, Información de error." + result);
                }
            }
            catch (Exception)
            {
                //throw new Exception("Se produjo un error en el punto de conexión de la API, Información de error." + ex.Message);
            }
            finally { }
            return;
        }
    }
}
