using ApiCrudCliente.Models;
using Microsoft.AspNetCore.Mvc;

namespace ApiCrudCliente.Controllers
{
    public class ClienteController : Controller
    {

        private readonly APIGateway apiGateway;

        public ClienteController(APIGateway apiGateway)
        {
            this.apiGateway = apiGateway;
        }

        public IActionResult Index()
        {
            List<Cliente> clientes;
            clientes = apiGateway.ListClientes();
            return View(clientes);
        }

        [HttpGet]
        public IActionResult Create()
        {
            Cliente cliente = new Cliente();
            return View();
        }

        [HttpPost]
        public IActionResult Create(Cliente cliente)
        {
            apiGateway.CreateCliente(cliente);
            //realice la acción de creación de API y envíe el control a la acción de índice
            return RedirectToAction("Index");
        }

        public IActionResult Details(int Id)
        {
            //obtener el cliente de la API y mostrar los detalles del cliente en la vista de detalles
            Cliente cliente = new Cliente();

            cliente = apiGateway.GetCliente(Id);
            return View(cliente);
        }

        [HttpGet]
        public IActionResult Edit(int Id)
        {
            Cliente cliente;
            // //obtener el cliente de la API y mostrar los detalles del cliente en la vista de editar
            cliente = apiGateway.GetCliente(Id);
            return View(cliente);
        }

        [HttpPost]
        public IActionResult Edit(Cliente cliente)
        {
            //realice la acción de edición de la API y envíe el control a la acción de índice
            apiGateway.UpdateCliente(cliente);
            return RedirectToAction("index");
        }

        [HttpGet]
        public IActionResult Delete(int Id)
        {
            //obtener el cliente de la API y mostrar los detalles del cliente en la vista Eliminar
            Cliente cliente;
            cliente = apiGateway.GetCliente(Id);
            return View(cliente);
        }

        [HttpPost]
        public IActionResult Delete(Cliente cliente)
        {
            apiGateway.DeleteCliente(cliente.id);
            //realice la acción de eliminación de API y envíe el control a la acción de índice
            return RedirectToAction("index");
        }
    }
}
