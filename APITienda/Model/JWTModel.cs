﻿namespace APITienda.Model
{
  public class JWTModel
  {
    public string Key { get; set; }
    public string Issuer { get; set; }
    public string Audience { get; set; }
    public string Subject { get; set; }
   }
}
