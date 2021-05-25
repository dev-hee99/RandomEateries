using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace RandomEatery
{
  /// <summary>
  /// MainWindow.xaml에 대한 상호 작용 논리
  /// </summary>

  public partial class MainWindow : Window
  {
    public ObservableCollection<Eatery> Eateries;

    List<string> earr = new List<string>() {
      "영심이", "미담","한아름정식(백반)","편의점","더진국"
    };
        //test
    
    public MainWindow()
    {
      InitializeComponent();
      /*Eateries = new ObservableCollection<Eatery>()
      {
        new Eatery(){ name="영심이"},
        new Eatery(){ name="미담"},
        new Eatery(){ name="한아름정식(백반)"},
        new Eatery(){ name="더진국"},
        new Eatery(){ name="편의점"},
      };*/

      foreach (string name in earr)
      {
        eateryNames.Items.Add(name);
      }


      eateryNames.DataContext = Eateries;
    }

    //음식점 추가
    private void btnAdd_Click(object sender, RoutedEventArgs e)
    {
      if(!string.IsNullOrWhiteSpace(eateryName.Text) && !eateryNames.Items.Contains(eateryName.Text)){
        eateryNames.Items.Add(eateryName.Text);
        earr.Add(eateryName.Text);
        eateryName.Text="";
      }
      
    }

    //초기화 
    private void btnClear_Click(object sender, RoutedEventArgs e)
    {
      eateryNames.Items.Clear();
      earr.Clear();
    }

    private void btnSelect_Click(object sender, RoutedEventArgs e)
    {

      if (!eateryNames.Items.IsEmpty) {
      result.Foreground = Brushes.Navy;
      var ran = new Random();
      int index = ran.Next(earr.Count);
      result.Text = earr[index];
      }
      else {
        result.Foreground = Brushes.Red;
        result.Text = "음식점을 추가하세요";
      }
    }

    public class Eatery
    {
      public string name { get; set; }
    }
  }
}
