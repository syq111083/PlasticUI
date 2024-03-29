﻿using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Demo.ViewModels;

public class MainWindowViewModel : ObservableObject
{
	private string? _text;

	public string? Text
	{
		get => _text;
		set => SetProperty(ref _text, value);
	}

	public MainWindowViewModel()
	{
		Timer timer = new(OnChangeText);
		timer.Change(1000,50);
	}

	private void OnChangeText(object? state)
	{
		Text = DateTime.Now.ToString(provider: CultureInfo.InvariantCulture);
	}

	public string[] Strs { get; set; } = new string[] { "item1", "item2", "item3" };

	private bool _checked = true;

	public bool Checked
	{
		get => _checked;
		set => SetProperty(ref _checked, value);
	}


}