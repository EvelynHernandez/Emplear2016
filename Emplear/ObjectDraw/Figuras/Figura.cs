using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Shapes;

namespace ObjectDraw.Figuras
{
  public class Figura
  {
    public double X { get; set; }
    public double Y { get; set; }

    public bool Visible { get; set; }

    protected Shape Forma { get; set; }

    public Shape Mostrar()
    {
      if (Forma == null)
      {
        //  no se que shape voy a crear concretamente...pero se que siempre voy a tener que crear una!!
        Forma = CrearShape();
      }

      Visible = true;

      return Forma;
    }

    protected virtual Shape CrearShape()
    {
      return null;
    }

    public Shape Ocultar()
    {
      Visible = false;
      return Forma;
    }

    public void Mover(double newX, double newY)
    {
      X = newX;
      Y = newY;
    }
  }
}
