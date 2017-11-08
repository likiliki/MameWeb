using System;
using Gtk;
using WebKit;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using CustomClass;
using WINFAV;

public partial class MainWindow: Gtk.Window
{
	//variables  ----------------------------------------------
	private BigData self = new BigData(); 
	private Juegos searchGames = new Juegos("Search", -1);

	private string FILENAME = "mameWebData.bin";
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

		cargarFile (FILENAME);

		SetUp ();
		//AddData ();

		DataRefresh (SELI);
		DataFavRefresh ();
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

	protected void PicClicked (object sender, EventArgs e)
	{
		WebPictureSearch ();
	}

	protected void YoutubeClicked (object sender, EventArgs e)
	{
		WebYoutubeSearch ();
	}

	private void WebPictureSearch()
	{
		try{
			MyTreeNode node = (MyTreeNode) nodeview1.NodeSelection.SelectedNode;
			labelImagenes.Text	= "Imagenes de: " + node.Game;
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
		frameImagenes.LabelXalign = 0.35f;
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

	protected void GoPlayGameActivated (object sender, EventArgs e)
	{
		PlayTheGame ();
	}

	protected void PlayGameClicked (object sender, EventArgs e)
	{
		PlayTheGame ();
	}

	protected void PlayTheGame()
	{
		try{
			MyTreeNode node = (MyTreeNode) nodeview1.NodeSelection.SelectedNode;
			labelSelectedRom.Text = "Selected ROM -> " + node.Game;

			Console.WriteLine(node.Rom);
			LanzarJuego("mame", node.Rom);
		}
		catch (Exception){
			show_error ("No Rom Selected \n\n Select a Game");
		}
	}

	protected void EntryFindActivated (object sender, EventArgs e)
	{
		BuscaJuego (entryFind.Text);
	}

	protected void ButtonSearchClicked (object sender, EventArgs e)
	{
		BuscaJuego (entryFind.Text);
	}

	private void BuscaJuego(string juego)
	{		
		if (juego != "") {
			SearchDataRefresh (juego);
		} 
		else {
			DataRefresh (0);
		}
	}

	private void LanzarJuego(string mame, string juego)
	{
		try {
			System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo ();
			startInfo.FileName = mame;
			startInfo.Arguments = juego;

			startInfo.UseShellExecute = false;
			startInfo.ErrorDialog = false;
			startInfo.CreateNoWindow = false;

			//Inicializa el proceso
			System.Diagnostics.Process proc = new System.Diagnostics.Process();
			proc.StartInfo = startInfo;
			proc.Start();
		}				
		catch (Exception err) {
			show_error (err.Message);
		}
	}

	protected void QuitCliked(object o, EventArgs e)
	{
		Salir ();
	}

	protected void OnDeleteEvent (object sender, DeleteEventArgs a)
	{
		Salir ();
		a.RetVal = true;
	}

	protected void OnDestroyEventClicked (object o, DestroyEventArgs args)
	{
		Salir ();
	}

	protected void Salir ()
	{
		//guardarFile (FILENAME);
		Application.Quit ();
	}

	protected void PicBackClicked (object sender, EventArgs e)
	{
		try
		{
			webPictures.GoBack ();

		}
		catch (Exception){}
	}

	protected void PicForClicked (object sender, EventArgs e)
	{
		try
		{
			webPictures.GoForward ();

		}
		catch (Exception){}
	}

	protected void PicZoomInClick (object sender, EventArgs e)
	{
		try
		{
			webPictures.ZoomIn ();

		}
		catch (Exception){}
	}

	protected void PicZoomOutClick (object sender, EventArgs e)
	{
		try
		{
			webPictures.ZoomOut ();

		}
		catch (Exception){}
	}

	protected void BackTubeClick (object sender, EventArgs e)
	{
		try{
			webYoutube.GoBack();
		}
		catch(Exception){}
	}

	protected void ForTubeClick (object sender, EventArgs e)
	{
		try{
			webYoutube.GoForward();
		}
		catch(Exception){}
	}

	protected void ZoomInTube (object sender, EventArgs e)
	{
		try{
			webYoutube.ZoomIn();
		}
		catch(Exception){}
	}

	protected void ZoomOutTube (object sender, EventArgs e)
	{
		try{
			webYoutube.ZoomOut();
		}
		catch(Exception){}
	}

	protected void ModoNormalClicked (object sender, EventArgs e)
	{
		frameImagenes.Show ();
		frameYoutube.Show ();
		vbox2.Show ();
		frame3.Show ();
		frame2.Show ();
	}

	protected void ModoImagenesClicked (object sender, EventArgs e)
	{
		frameImagenes.Show ();
		frameYoutube.Hide ();
		frame3.Hide ();
		frame2.Hide ();
	}

	protected void ModoYoutubeClicked (object sender, EventArgs e)
	{
		frameYoutube.Show ();
		frame3.Hide ();
		frame2.Hide ();
		frameImagenes.Hide ();
	}

	protected void FullScreenClicked (object sender, EventArgs e)
	{
		try
		{
			if(FULL){
				this.Unfullscreen();
				FULL = false;
			}
			else{
				this.Fullscreen();
				FULL = true;
			}
		}
		catch(Exception){}
	}

	protected void OnFocusInEvent(object o, FocusInEventArgs args)
	{
		//DataFavRefresh ();
		//Console.WriteLine ("FOCUS");
	}

	protected void EditFavsClick (object sender, EventArgs e)
	{
		//WinFavList WinFav = new WinFavList();
		//WinFav.CargaWinFav (self);
		//WinFav.Run ();
		DataFavRefresh ();
	}

	protected void RowFavActivated (object o, RowActivatedArgs args)
	{
		Console.WriteLine (self.Hyperist.Count);
		MyFavTreeNode node = (MyFavTreeNode) nodeview2.NodeSelection.SelectedNode;
		Console.WriteLine (node.Id);
		DataRefresh (node.Id);
	}

	protected void AnyadirJuegoClick (object sender, EventArgs e)
	{
		try{
			MyTreeNode node = (MyTreeNode) nodeview1.NodeSelection.SelectedNode;
			MyFavTreeNode node2 = (MyFavTreeNode) nodeview2.NodeSelection.SelectedNode;
			self.Hyperist [node2.Id].AddGame (node.Game, node.Rom);
			DataFavRefresh();

		}
		catch(Exception){
			show_error ("Selecciona Lista de Favoritos");
		}
	}

	protected void EliminarJuegoClicked (object sender, EventArgs e)
	{
		try{
			if(SELI != 0){
				show_mess();
			}
			else{
				string mes = "Lista FULL\n\nNo es posible eliminar de esta lista";
				show_error(mes);
			}
		}
		catch(Exception){
			Console.WriteLine ("Selecciona Juego");
		}
	}

	private void show_mess()
	{
		MyTreeNode node = (MyTreeNode) nodeview1.NodeSelection.SelectedNode;

		string mess = "¿Desea eliminar el Juego\n\n   " + node.Game +
			"\n\nde:  " + self.Hyperist[SELI].NameList + " ?"; 

		MessageDialog md = new MessageDialog
			(this, DialogFlags.Modal, MessageType.Error, ButtonsType.YesNo, mess); 

		if ((ResponseType)md.Run () == ResponseType.Yes) 
		{
			Console.WriteLine ("Yes");
			self.Hyperist[SELI].RemoveGame(node.Rom);
			DataFavRefresh();
			DataRefresh(SELI);
		} 
		else {
			Console.WriteLine ("NO");
		}
		md.Destroy ();
	}

	private void show_error(string mes)
	{
		MessageDialog md = new MessageDialog
			(this, DialogFlags.Modal, MessageType.Error, ButtonsType.Ok, mes); 
		md.Run ();
		md.Destroy ();
	}

	//-------------------------------------
	//-------    NODES   	STORE ---------
	//-------------------------------------
	private void DataRefresh(int sel)
	{
		try{
			SELI = sel;
			int tam = self.Hyperist[SELI].game.Count;
			Console.WriteLine(tam);
			nodeview1.NodeStore = Store;
			labelRoms.Text = self.Hyperist [SELI].game.Count.ToString() + " Roms.";
		}
		catch(Exception){}
	}

	private void DataFavRefresh ()
	{
		nodeview2.NodeStore = FavStore;
		Console.WriteLine ("DataFavRefresh ();");
	}

	private void SearchDataRefresh(string searchGame)
	{
		searchGame = searchGame.ToLower ();
		//Console.WriteLine (searchGame + "  ################\n");
		searchGames = new Juegos(searchGame, -1);
		bool bool1 = false;
		int tam = self.Hyperist[SELI].game.Count;

		//Console.WriteLine ("Tamanyo->  " + tam);
		string juego1 = "";
		string rom1 = "";

		for (int i=0; i<tam; i++) 
		{
			juego1 = self.Hyperist [SELI].game [i].Name.ToLower ();
			rom1 = self.Hyperist [SELI].game [i].Rom;
			bool1 = juego1.Contains (searchGame);
			//Console.WriteLine (juego1);

			if (bool1) 
			{
				searchGames.AddGame(self.Hyperist [SELI].game [i].Name, rom1);
			}
		}

		nodeview1.NodeStore = SearchStore;
		labelRoms.Text = searchGames.game.Count.ToString () + "Roms";
	}

	//------------------------------------------------------------------
	Gtk.NodeStore Store {
		get {
			//string line = "";
			string s = "";
			string r = "";
			Gtk.NodeStore store = new Gtk.NodeStore (typeof (MyTreeNode));

			try{
				GtkLabel7.Text = "Lista: "+ self.Hyperist[SELI].NameList;
				int tam = self.Hyperist[SELI].game.Count;
				for(int  i=0; i<tam; i++)
				{
					r = self.Hyperist[SELI].game[i].Rom;
					s = self.Hyperist[SELI].game[i].Name;
					store.AddNode (new MyTreeNode (r, s));
				}
			}
			catch(Exception err){

				show_error (err.Message);
			} 
			return store;		
		}
	}

	//------------------------------------------------------------------
	//--FUNCTIONS OF TREESTORE------------------------------------------
	//------------------------------------------------------------------
	Gtk.NodeStore SearchStore {
		get {
			//string line = "";
			string s = "";
			string r = "";
			Gtk.NodeStore search_store = new Gtk.NodeStore (typeof (MyTreeNode));

			try{
				int tam = searchGames.game.Count;
				for(int i=0; i<tam; i++)
				{
					r = searchGames.game[i].Rom;
					s = searchGames.game[i].Name;
					search_store.AddNode (new MyTreeNode (r, s));
				}
			}
			catch(Exception err){

				show_error (err.Message);
			} 
			return search_store;		
		}
	}

	//------------------------------------------------------------------
	Gtk.NodeStore FavStore {
		get {
			//string line = "";
			string l = "";
			int n = 0;
			int id = 0;
			Gtk.NodeStore store = new Gtk.NodeStore (typeof (MyFavTreeNode));

			try{
				int tam = self.Hyperist.Count;
				for(int  i=1; i<tam; i++)
				{
					id = self.Hyperist[i].Id;
					l = self.Hyperist[i].NameList;
					n = self.Hyperist[i].game.Count;
					store.AddNode (new MyFavTreeNode (id, l, n));
				}
			}
			catch(Exception err){
				show_error (err.Message);
			} 
			return store;		
		}
	}

	//-------------------------------------
	// CLASS   of   NODEVIEW     ----------
	//-------------------------------------
	public class MyTreeNode : Gtk.TreeNode 
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="MainWindow+MyTreeNode"/> class.
		/// </summary>
		/// <param name="favUri">Fav URI.</param>
		public MyTreeNode (string rom, string game)
		{
			Game = game;
			Rom = rom;
		}

		[Gtk.TreeNodeValue (Column=0)]
		public string Game;

		[Gtk.TreeNodeValue (Column=1)]
		public string Rom;
	}

	//-------------------------------------
	// CLASS   of   NODEVIEW     ----------
	//-------------------------------------
	public class MyFavTreeNode : Gtk.TreeNode 
	{
		public MyFavTreeNode (int id, string list, int no)
		{
			Lista = list;
			No = no;
			Id = id;
		}

		[Gtk.TreeNodeValue (Column=0)]
		public int Id;

		[Gtk.TreeNodeValue (Column=1)]
		public string Lista;

		[Gtk.TreeNodeValue (Column=2)]
		public int No;
	}

}