using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Demo.ViewModels
{
    public class MainWindowViewModel : ObservableObject
    {
		private string? text;

		public string? Text
		{
			get { return text; }
			set { SetProperty(ref text, value); }
		}

		public MainWindowViewModel()
		{
			Timer timer = new(ChangeText);
			timer.Change(1000,50);
		}

		public void ChangeText(object? state)
		{
			Text = DateTime.Now.ToString();
		}

		public string[] Strs { get; set; } = new string[] { "item1", "item2", "item3" };

	}
}
