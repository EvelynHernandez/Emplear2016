using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Data;
using Entidades;

namespace TestEF
{
  class Program
  {
    static void Main(string[] args)
    {
      TestContext ctx = TestContext.DB;

      if (ctx.Database.Exists())
        Console.WriteLine("La base esta...");
      else
        Console.WriteLine(" >>>>>>> ERROR: no existe la base de datos...");

      Perfil p = ctx.Perfiles.FirstOrDefault();

      Usuario user = new Usuario()
      {
        Login = "root",
        Perfil = p
      };

      ctx.Usuarios.Add(user);
      ctx.SaveChanges();

      Console.WriteLine($"ID Perfil: {p.IDPerfil} ; Descripcion:  {p.Descripcion}");
      Console.ReadLine();
    }
  }
}
