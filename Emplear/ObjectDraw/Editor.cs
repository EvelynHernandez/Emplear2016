using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
using ObjectDraw.Figuras;

namespace ObjectDraw
{
  public class Editor : INotifyPropertyChanged
  {
    public static Editor Instancia { get; private set; }

    private Canvas _canvas;
    private Rectangulo _rectActual;
    private ObservableCollection<Rectangulo> _objetos;

    public ICommand Mostrar { get; set; }

    public ICommand Ocultar { get; set; }

    public ICommand Mover { get; set; }

    public event PropertyChangedEventHandler PropertyChanged;

    static Editor()
    {
      Instancia = new Editor();
    }

    private Editor()
    {
      _canvas = GetElementByName("mainArea", App.Current.MainWindow) as Canvas;

      if (_canvas != null)
        Console.WriteLine("Canvas encontrado con exito!");

      Objetos = new ObservableCollection<Rectangulo>();

      Mostrar = new SimpleCommand(MostrarElementoActual, EstadoElementoActual);

      Ocultar = new SimpleCommand((o) =>
      {
        _canvas.Children.Remove(RectanguloActual.Ocultar());
      }, (o) =>
      {
        if (RectanguloActual == null)
          return false;
        return RectanguloActual.Visible;
      });

      Mover = new SimpleCommand((o) =>
      {
        _canvas.Children.Remove(RectanguloActual.Ocultar());
        RectanguloActual.Mover(NewX, NewY);
        MostrarElementoActual(null);
      }, (o) => RectanguloActual != null && RectanguloActual.Visible);
  }

    private bool EstadoElementoActual(object obj)
    {
      if (RectanguloActual == null)
        return false;
      return !RectanguloActual.Visible;
    }

    private void MostrarElementoActual(object obj)
    {
      Rectangle item = RectanguloActual.Mostrar();
      _canvas.Children.Add(item);
      item.SetValue(Canvas.TopProperty, RectanguloActual.Y);
      item.SetValue(Canvas.LeftProperty, RectanguloActual.X);
    }

    public ObservableCollection<Rectangulo> Objetos
    {
      get { return _objetos; }
      set
      {
        _objetos = value;
        OnPropertyChanged(nameof(Objetos));
      }
    }

    public Rectangulo RectanguloActual
    {
      get { return _rectActual; }
      set
      {
        _rectActual = value;
        OnPropertyChanged(nameof(RectanguloActual));
      }
    }

    private double _x;
    public double NewX
    {
      get { return _x; }
      set
      {
        _x = value;
        OnPropertyChanged(nameof(NewX));
      }
    }

    private double _y;
    public double NewY
    {
      get { return _y; }
      set
      {
        _y = value;
        OnPropertyChanged(nameof(NewY));
      }
    }

    /*
       public List<Type> FigurasValidas { get; set; }


       private Type _figuraElegida;
       public Type FiguraElegida
       {
         get
         {
           return _figuraElegida;
         }
         set
         {
           _figuraElegida = value;
           OnPropertyChanged(nameof(FiguraElegida));
         }
       }
   */

    private void OnPropertyChanged(string prop)
    {
      PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
    }

    private FrameworkElement GetElementByName(string nombre, DependencyObject root)
    {
      FrameworkElement result = null;
      int hijos = VisualTreeHelper.GetChildrenCount(root);

      if (hijos >= 1)
      {
        //  obtener cada hijo de este objeto, chequear que sea el que tiene el nombre buscado
        //  si lo encuentro, lo retorno enseguida
        //  si no, continuo buscando
        for (int idx = 0; idx < hijos; idx++)
        {
          FrameworkElement probar = VisualTreeHelper.GetChild(root, idx) as FrameworkElement;

          if (probar != null)
          {
            //  o sea...si es un framework element....
            if (probar.Name == nombre)
            {
              result = probar;
            }
            else
            {
              probar = GetElementByName(nombre, probar);
              if (probar != null)
                result = probar;
            }
          }
        }
      }
      return result;
    }
  }
}
