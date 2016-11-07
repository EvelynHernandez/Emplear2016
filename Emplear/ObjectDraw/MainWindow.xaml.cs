using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ObjectDraw.Figuras;

namespace ObjectDraw
{
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window
  {
    public MainWindow()
    {
      InitializeComponent();
    }

    private void Windows_Loaded(object sender, RoutedEventArgs e)
    {
      Editor edit = Editor.Instancia;

      toolPanel.DataContext = edit;

      //  agregamos figuras al editor
      edit.Objetos.Add(new Rectangulo() { X = 50, Y = 20, Base = 200, Altura = 30 });
      edit.Objetos.Add(new Rectangulo() { X = 200, Y = 300, Base = 200, Altura = 150 });
      edit.Objetos.Add(new Circulo() { X = 300, Y = 85, Radio = 40 });
      edit.Objetos.Add(new Circulo() { X = 500, Y = 240, Radio = 95 });
      edit.Objetos.Add(new Linea() {X = 50, Y = 20, Longitud = 200, Direccion = 30 });
    }
  }
}
