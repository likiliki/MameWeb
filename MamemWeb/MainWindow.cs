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
	private BigData self = new BigData(); 
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
		this.webPictures.LoadFinished += new global::WebKit.LoadFinishedHandler (this.OnWebPicturesLoadFinished);
		this.webYoutube.LoadFinished += new global::WebKit.LoadFinishedHandler (this.OnWebYoutubeLoadFinished);

		//cargarFile (FILENAME);

		SetUp ();
		AddData ();

		DataRefresh (SELI);
		DataFavRefresh ();
		//guardarFile (FILENAME);
	}

	private void guardarFile(string nameFile)
	{
		string Nombre_Del_Archivo = nameFile;
		myStream = File.Create(Nombre_Del_Archivo);//se crea carchivo con el nombre seleccionado
		BinaryFormatter seri = new BinaryFormatter();
		seri.Serialize (myStream, self);             
		myStream.Close();
	}

	private void cargarFile(string nameFile)
	{
		myStream = File.OpenRead(nameFile);//Leemos el archivo seleccionado
		BinaryFormatter deseri = new BinaryFormatter();
		self = deseri.Deserialize(myStream) as BigData;//Abrimos el archivo como Objeto BigData
		myStream.Close();		       
	}

	protected void SetUp ()
	{
		nodeview1.HeadersVisible = true;
		nodeview1.AppendColumn ("Nombre del Juego", new Gtk.CellRendererText (), "text", 0);
		nodeview1.AppendColumn ("   ROM", new Gtk.CellRendererText (), "text", 1);

		nodeview2.HeadersVisible = true;
		nodeview2.AppendColumn ("-", new Gtk.CellRendererText (), "text", 0);
		nodeview2.AppendColumn ("Lista", new Gtk.CellRendererText (), "text", 1);
		nodeview2.AppendColumn ("Nº Juegos", new Gtk.CellRendererText (), "text", 2);

		scrolledwindow1.Add (webPictures);
		scrolledwindow2.Add (webYoutube);
		webPictures.Show ();
		webYoutube.Show ();
		webYoutube.Open ("https://www.youtube.com/yt/about/media/images/brand-resources/logos/YouTube-logo_monochrome_light.svg");
	}

	protected void TreeRowActivated (object o, RowActivatedArgs args)
	{
		WebPictureSearch ();
	}

	private void WebPictureSearch()
	{
		try{
			MyTreeNode node = (MyTreeNode) nodeview1.NodeSelection.SelectedNode;
			labelPictures.Text	= "Imagenes de: " + node.Game;
			labelSelectedRom.Text = "Selected ROM -> " + node.Game;
			URLweb = "http://www.google.es/search?q=ROM " + node.Game + "+arcade&tbm=isch";
			webPictures.Open (URLweb);
		}
		catch (Exception){
			show_error ("No Rom Selected \n\n Select a Game");
		}
	}

	private void WebYoutubeSearch()
	{
		try{
			MyTreeNode node = (MyTreeNode) nodeview1.NodeSelection.SelectedNode;
			labelYoutube.Text	= "Videos de: " + node.Game;
			labelSelectedRom.Text = "Selected ROM -> " + node.Game;
			URLtube = "http://www.youtube.com/results?search_query=gameplay " +
				node.Game + " mame";
			webYoutube.Open (URLtube);
		}
		catch (Exception){
			show_error ("No Rom Selected \n\n Select a Game");
		}
	}

	protected void OnWebPicturesLoadFinished(object sender, EventArgs e)
	{ 
		string aux = webPictures.Uri;
		aux = aux.Replace ("https", "");
		aux = aux.Replace ("http", "");
		aux = aux.Replace ("://www.google.es/search?q=ROM", "");
		aux = aux.Replace ("+arcade&tbm=isch", "");
		aux = aux.Replace ("%20", " ");
		aux = aux.Replace ("&gws_rd=ssl", "");

		labelImagenes.Text	= "Imagenes de: " + aux;
		frameImegenes.LabelXalign = 0.35f;
	}


	protected void OnWebYoutubeLoadFinished(object sender, EventArgs e)
	{
		string aux = webYoutube.Uri;
		aux = aux.Replace ("https", "");
		aux = aux.Replace ("http", "");
		aux = aux.Replace ("://www.youtube.com/results?search_query=gameplay", "");
		aux = aux.Replace ("%20mame", "");
		aux = aux.Replace ("%20", " ");

		labelYoutube.Text = "Videos de:" + aux;	
		frameYoutube.LabelXalign = 0.35f;
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
