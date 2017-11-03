using System;
using Gtk;

namespace MameWeb
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			Application.Init ();
			MainWindow win = new MainWindow ();
			win.Resize (1280, 720);
			//win.Maximize ();
			win.Show ();
			Application.Run ();
		}
	}
}
