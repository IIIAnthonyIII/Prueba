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

    [HttpPost]
    [Route("agregar")]
    public dynamic AgregarProducto (ProductModel product)
    {
      List<Parametro> parametros = new List<Parametro>
      {
        new Parametro("@descriptionSP", product.description),
        new Parametro("@priceSP", product.price.ToString()),
        new Parametro("@detailSP", product.detail),
        new Parametro("@imageSP", product.image),
      };
      bool exito = ConectionBD.Ejecutar("insertProduct_SP", parametros);
      return new
      {
        codigoRetorno = "0001",
        mensajeRetorno = exito ? "Se ha guardado" : "Error al guardar",
        data = ""
      };
    }
  }
}
