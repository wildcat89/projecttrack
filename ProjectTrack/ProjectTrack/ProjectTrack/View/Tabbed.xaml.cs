using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectTrack;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProjectTrack
{ 
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Tabbed : TabbedPage
    {
        public Tabbed()
        {
            InitializeComponent();
            Children.Add(new MainPage());
            Children.Add(new ProjectPage());
        }
    }
}
