using System;
using System.Windows;

//Jiwant Singh
//Nihal Ahmed Gesudraz
//Apoorva Solanki
//Kiranpreet Kaur
//Harkirat Kaur

namespace TicTacToe
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		ViewModel vm = new ViewModel();
		public MainWindow()
		{
			InitializeComponent();
			DataContext = vm;
		}

		private void GameStart(object sender, EventArgs e)
		{
			vm.GameStart();
		}

		private void GameReset(object sender, EventArgs e)
		{
			vm.TotalReset();
		}

		private void ClickOpt11(object sender, EventArgs e)
		{
			vm.SelectOption(1, 1);
		}

		private void ClickOpt12(object sender, EventArgs e)
		{
			vm.SelectOption(1, 2);
		}

		private void ClickOpt13(object sender, EventArgs e)
		{
			vm.SelectOption(1, 3);
		}

		private void ClickOpt21(object sender, EventArgs e)
		{
			vm.SelectOption(2, 1);
		}

		private void ClickOpt22(object sender, EventArgs e)
		{
			vm.SelectOption(2, 2);
		}

		private void ClickOpt23(object sender, EventArgs e)
		{
			vm.SelectOption(2, 3);
		}

		private void ClickOpt31(object sender, EventArgs e)
		{
			vm.SelectOption(3, 1);
		}

		private void ClickOpt32(object sender, EventArgs e)
		{
			vm.SelectOption(3, 2);
		}

		private void ClickOpt33(object sender, EventArgs e)
		{
			vm.SelectOption(3, 3);
		}

		private void NextRound(object sender, EventArgs e)
		{
			vm.NextRound();
		}
	}
}
