using System;
using Gtk;
using WebKit;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using CustomClass;
//using WINFAV;

public partial class MainWindow: Gtk.Window
{
	//variables  ----------------------------------------------
	private BigData TreeSelectionFunc = new BigData();
	private Juegos searchGames = new Juegos("Search", -1);

	private string FILENAME = "Archivodeprueba.bin";
	private WebView webPictures = new WebView();
	private WebView webYoutube = new WebView();
	private Stream myStream;
	private int SELI = 0;
	private bool FULL = false;
	private bool WIN = false;
	private string URLweb = "";
	private string URLtube = "";

	public MainWindow () : base (Gtk.WindowType.Toplevel)
	{
		Console.WriteLine ("##--INIT--##");

		SELI = 0;
		Build ();
	}

	protected void OnDeleteEvent (object sender, DeleteEventArgs a)
	{
		Application.Quit ();
		a.RetVal = true;
	}

	protected void OnDestroyEventClicked (object o, DestroyEventArgs args)
	{
		//throw new NotImplementedException ();
	}

	protected void OnFocusInEvent(object o, FocusInEventArgs args)
	{
		Console.WriteLine ("OnFocusInEvent -- MainWindow.cs");
	}

	protected void QuitCliked(object o, EventArgs e)
	{
		//throw new NotImplementedException ();
	}

	protected void ModoNormalClicked (object sender, EventArgs e)
	{
		//throw new NotImplementedException ();
	}

	protected void ModoImagenesClicked (object sender, EventArgs e)
	{
		//throw new NotImplementedException ();
	}

	protected void ModoYoutubeClicked (object sender, EventArgs e)
	{
		//throw new NotImplementedException ();
	}

	protected void FullScreenClicked (object sender, EventArgs e)
	{
		//throw new NotImplementedException ();
	}

	protected void EntryFindActivated (object sender, EventArgs e)
	{
		//throw new NotImplementedException ();
	}
}
