using APITienda.Connection;
using APITienda.Model;
using APITienda.Resource;

using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Data;

namespace APITienda.Controllers
{
  [ApiController]
  [Route("productos")]
  public class ProductoController : ControllerBase
  {
    [HttpGet]
    public dynamic ListarProdutos ()
    {
      DataTable tProductos = ConectionBD.Listar("showProduct_SP");
      string jsonProductos = JsonConvert.SerializeObject(tProductos);
      return new
      {
        codigoRetorno = "0001",
        mensajeRetorno = "Consulta Ok",
        data = JsonConvert.DeserializeObject<List<ProductModel>>(jsonProductos)
      };
    }
  }
}
