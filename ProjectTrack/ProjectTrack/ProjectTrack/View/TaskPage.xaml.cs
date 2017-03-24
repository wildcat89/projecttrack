using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProjectTrack.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class TaskPage : ContentPage
	{
		public TaskPage (string Id)
		{
			InitializeComponent ();
		    var viewModel = App.Locator.Task;
		    BindingContext = viewModel;
		    viewModel.ProjectId = string.IsNullOrEmpty(Id) ? "No parameter set" : Id;
		}
	}
}
