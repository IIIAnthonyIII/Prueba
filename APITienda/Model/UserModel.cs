using System.Numerics;

namespace APITienda.Model
{
  public class UserModel
  {

    public string idUsuario { get; set; }
    public string email { get; set; }
    public string password { get; set; }
    public string nombre { get; set; }
    public int plan {  get; set; }
    public string telefono { get; set; }
    public static List<UserModel> UserDB ()
    {
      var list = new List<UserModel>()
      {
        new UserModel
        {
          idUsuario = "1",
          email = "danielsilvaorrego@gmail.com",
          password = "89e495e7941cf9e40e6980d14a16bf023ccd4c91",
          nombre = "Daniel Silva Orrego",
          plan = 6,
          telefono = "0981222673",
        }
      };
      return list;
    }
  }
}