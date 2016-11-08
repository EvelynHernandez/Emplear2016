using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Shapes;

namespace ObjectDraw.Figuras
{
  public class Figura
  {
    public double X { get; set; }
    public double Y { get; set; }

    public bool Visible { get; set; }

    private Shape FiguraVisual { get; set; }

    public Shape Mostrar()
    {
      if (FiguraVisual == null)
        FiguraVisual = CrearFiguraVisual();

      Visible = true;

      return FiguraVisual;
    }

    public virtual Shape CrearFiguraVisual()
    {
      return null;
    }
  }
}
