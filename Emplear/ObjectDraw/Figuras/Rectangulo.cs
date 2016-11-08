using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Shapes;

namespace ObjectDraw.Figuras
{
  public class Rectangulo : Figura
  {
    public float Base { get; set; }
    public float Altura { get; set; }

    private Rectangle _rect;

    public void Mover(double newX, double newY)
    {
      X = newX;
      Y = newY;
    }

    public override Shape CrearFiguraVisual()
    {
      _rect = new Rectangle();

      _rect.StrokeThickness = 4;
      _rect.Stroke = Brushes.Black;
      _rect.Width = Base;
      _rect.Height = Altura;

      return _rect;
    }

    public Rectangle Ocultar()
    {
      Visible = false;
      return _rect;
    }
  }
}
