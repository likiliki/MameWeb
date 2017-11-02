
// This file has been generated by the GUI designer. Do not modify.

public partial class MainWindow
{
	private global::Gtk.UIManager UIManager;
	
	private global::Gtk.Action ArchivoAction;
	
	private global::Gtk.Action SalirAction;
	
	private global::Gtk.Action VerAction;
	
	private global::Gtk.Action ModoNormalAction;
	
	private global::Gtk.Action ModoImagenesAction;
	
	private global::Gtk.Action ModoYoutubeAction;
	
	private global::Gtk.Action Action;
	
	private global::Gtk.Action FullScreenAction;
	
	private global::Gtk.VBox vbox1;
	
	private global::Gtk.MenuBar menubar1;
	
	private global::Gtk.HBox hbox1;
	
	private global::Gtk.Label label2;
	
	private global::Gtk.Entry entryFind;
	
	private global::Gtk.Button button1;
	
	private global::Gtk.Button button2;
	
	private global::Gtk.Button button3;
	
	private global::Gtk.Button button4;
	
	private global::Gtk.Label labelSelectedRom;
	
	private global::Gtk.HPaned hpaned1;
	
	private global::Gtk.VBox vbox2;
	
	private global::Gtk.Frame frame1;
	
	private global::Gtk.Alignment GtkAlignment;
	
	private global::Gtk.ScrolledWindow scrolledwindow1;
	
	private global::Gtk.NodeView nodeview1;
	
	private global::Gtk.Label GtkLabel7;
	
	private global::Gtk.Frame frame2;
	
	private global::Gtk.Alignment GtkAlignment1;
	
	private global::Gtk.HBox hbox2;
	
	private global::Gtk.Button button5;
	
	private global::Gtk.Label label1;
	
	private global::Gtk.Button button6;
	
	private global::Gtk.Button button7;
	
	private global::Gtk.Label GtkLabel10;
	
	private global::Gtk.Frame frame3;
	
	private global::Gtk.Alignment GtkAlignment2;
	
	private global::Gtk.ScrolledWindow GtkScrolledWindow;
	
	private global::Gtk.NodeView nodeview2;
	
	private global::Gtk.Label GtkLabel11;
	
	private global::Gtk.VPaned vpaned1;
	
	private global::Gtk.Statusbar statusbar1;
	
	private global::Gtk.Label label3;

	protected virtual void Build ()
	{
		global::Stetic.Gui.Initialize (this);
		// Widget MainWindow
		this.UIManager = new global::Gtk.UIManager ();
		global::Gtk.ActionGroup w1 = new global::Gtk.ActionGroup ("Default");
		this.ArchivoAction = new global::Gtk.Action ("ArchivoAction", global::Mono.Unix.Catalog.GetString ("Archivo"), null, null);
		this.ArchivoAction.ShortLabel = global::Mono.Unix.Catalog.GetString ("Archivo");
		w1.Add (this.ArchivoAction, null);
		this.SalirAction = new global::Gtk.Action ("SalirAction", global::Mono.Unix.Catalog.GetString ("Salir"), null, null);
		this.SalirAction.ShortLabel = global::Mono.Unix.Catalog.GetString ("Salir");
		w1.Add (this.SalirAction, null);
		this.VerAction = new global::Gtk.Action ("VerAction", global::Mono.Unix.Catalog.GetString ("Ver"), null, null);
		this.VerAction.ShortLabel = global::Mono.Unix.Catalog.GetString ("Ver");
		w1.Add (this.VerAction, null);
		this.ModoNormalAction = new global::Gtk.Action ("ModoNormalAction", global::Mono.Unix.Catalog.GetString ("Modo Normal"), null, null);
		this.ModoNormalAction.ShortLabel = global::Mono.Unix.Catalog.GetString ("Modo Normal");
		w1.Add (this.ModoNormalAction, "<Primary><Mod2>n");
		this.ModoImagenesAction = new global::Gtk.Action ("ModoImagenesAction", global::Mono.Unix.Catalog.GetString ("Modo Imagenes"), null, null);
		this.ModoImagenesAction.ShortLabel = global::Mono.Unix.Catalog.GetString ("Modo Imagenes");
		w1.Add (this.ModoImagenesAction, "<Primary><Mod2>i");
		this.ModoYoutubeAction = new global::Gtk.Action ("ModoYoutubeAction", global::Mono.Unix.Catalog.GetString ("Modo Youtube"), null, null);
		this.ModoYoutubeAction.ShortLabel = global::Mono.Unix.Catalog.GetString ("Modo Youtube");
		w1.Add (this.ModoYoutubeAction, "<Primary><Mod2>y");
		this.Action = new global::Gtk.Action ("Action", global::Mono.Unix.Catalog.GetString ("-------------------------------"), null, null);
		this.Action.ShortLabel = global::Mono.Unix.Catalog.GetString ("-------------------------------");
		w1.Add (this.Action, null);
		this.FullScreenAction = new global::Gtk.Action ("FullScreenAction", global::Mono.Unix.Catalog.GetString ("Full Screen"), null, null);
		this.FullScreenAction.ShortLabel = global::Mono.Unix.Catalog.GetString ("Full Screen");
		w1.Add (this.FullScreenAction, "<Mod2>F11");
		this.UIManager.InsertActionGroup (w1, 0);
		this.AddAccelGroup (this.UIManager.AccelGroup);
		this.Name = "MainWindow";
		this.Title = global::Mono.Unix.Catalog.GetString ("MameWeb");
		this.Icon = new global::Gdk.Pixbuf (global::System.IO.Path.Combine (global::System.AppDomain.CurrentDomain.BaseDirectory, "./icon.png"));
		this.WindowPosition = ((global::Gtk.WindowPosition)(1));
		// Container child MainWindow.Gtk.Container+ContainerChild
		this.vbox1 = new global::Gtk.VBox ();
		this.vbox1.Name = "vbox1";
		this.vbox1.Spacing = 6;
		this.vbox1.BorderWidth = ((uint)(5));
		// Container child vbox1.Gtk.Box+BoxChild
		this.UIManager.AddUiFromString ("<ui><menubar name='menubar1'><menu name='ArchivoAction' action='ArchivoAction'><menuitem name='SalirAction' action='SalirAction'/></menu><menu name='VerAction' action='VerAction'><menuitem name='ModoNormalAction' action='ModoNormalAction'/><menuitem name='ModoImagenesAction' action='ModoImagenesAction'/><menuitem name='ModoYoutubeAction' action='ModoYoutubeAction'/><menuitem name='Action' action='Action'/><menuitem name='FullScreenAction' action='FullScreenAction'/></menu></menubar></ui>");
		this.menubar1 = ((global::Gtk.MenuBar)(this.UIManager.GetWidget ("/menubar1")));
		this.menubar1.Name = "menubar1";
		this.vbox1.Add (this.menubar1);
		global::Gtk.Box.BoxChild w2 = ((global::Gtk.Box.BoxChild)(this.vbox1 [this.menubar1]));
		w2.Position = 0;
		w2.Expand = false;
		w2.Fill = false;
		// Container child vbox1.Gtk.Box+BoxChild
		this.hbox1 = new global::Gtk.HBox ();
		this.hbox1.HeightRequest = 40;
		this.hbox1.Name = "hbox1";
		this.hbox1.Spacing = 6;
		// Container child hbox1.Gtk.Box+BoxChild
		this.label2 = new global::Gtk.Label ();
		this.label2.Name = "label2";
		this.label2.LabelProp = global::Mono.Unix.Catalog.GetString ("Buscar->");
		this.hbox1.Add (this.label2);
		global::Gtk.Box.BoxChild w3 = ((global::Gtk.Box.BoxChild)(this.hbox1 [this.label2]));
		w3.Position = 0;
		w3.Expand = false;
		w3.Fill = false;
		// Container child hbox1.Gtk.Box+BoxChild
		this.entryFind = new global::Gtk.Entry ();
		this.entryFind.WidthRequest = 300;
		this.entryFind.CanFocus = true;
		this.entryFind.Name = "entryFind";
		this.entryFind.IsEditable = true;
		this.entryFind.InvisibleChar = '●';
		this.hbox1.Add (this.entryFind);
		global::Gtk.Box.BoxChild w4 = ((global::Gtk.Box.BoxChild)(this.hbox1 [this.entryFind]));
		w4.Position = 1;
		// Container child hbox1.Gtk.Box+BoxChild
		this.button1 = new global::Gtk.Button ();
		this.button1.CanFocus = true;
		this.button1.Name = "button1";
		this.button1.UseUnderline = true;
		this.button1.Label = global::Mono.Unix.Catalog.GetString ("GtkButton");
		this.hbox1.Add (this.button1);
		global::Gtk.Box.BoxChild w5 = ((global::Gtk.Box.BoxChild)(this.hbox1 [this.button1]));
		w5.Position = 2;
		w5.Expand = false;
		w5.Fill = false;
		// Container child hbox1.Gtk.Box+BoxChild
		this.button2 = new global::Gtk.Button ();
		this.button2.CanFocus = true;
		this.button2.Name = "button2";
		this.button2.UseUnderline = true;
		this.button2.Label = global::Mono.Unix.Catalog.GetString ("GtkButton");
		this.hbox1.Add (this.button2);
		global::Gtk.Box.BoxChild w6 = ((global::Gtk.Box.BoxChild)(this.hbox1 [this.button2]));
		w6.Position = 3;
		w6.Expand = false;
		w6.Fill = false;
		// Container child hbox1.Gtk.Box+BoxChild
		this.button3 = new global::Gtk.Button ();
		this.button3.CanFocus = true;
		this.button3.Name = "button3";
		this.button3.UseUnderline = true;
		this.button3.Label = global::Mono.Unix.Catalog.GetString ("GtkButton");
		this.hbox1.Add (this.button3);
		global::Gtk.Box.BoxChild w7 = ((global::Gtk.Box.BoxChild)(this.hbox1 [this.button3]));
		w7.Position = 4;
		w7.Expand = false;
		w7.Fill = false;
		// Container child hbox1.Gtk.Box+BoxChild
		this.button4 = new global::Gtk.Button ();
		this.button4.CanFocus = true;
		this.button4.Name = "button4";
		this.button4.UseUnderline = true;
		this.button4.Label = global::Mono.Unix.Catalog.GetString ("GtkButton");
		this.hbox1.Add (this.button4);
		global::Gtk.Box.BoxChild w8 = ((global::Gtk.Box.BoxChild)(this.hbox1 [this.button4]));
		w8.Position = 5;
		w8.Expand = false;
		w8.Fill = false;
		this.vbox1.Add (this.hbox1);
		global::Gtk.Box.BoxChild w9 = ((global::Gtk.Box.BoxChild)(this.vbox1 [this.hbox1]));
		w9.Position = 1;
		w9.Expand = false;
		w9.Fill = false;
		// Container child vbox1.Gtk.Box+BoxChild
		this.labelSelectedRom = new global::Gtk.Label ();
		this.labelSelectedRom.Name = "labelSelectedRom";
		this.labelSelectedRom.LabelProp = global::Mono.Unix.Catalog.GetString ("<b>No Roms selected</b>");
		this.labelSelectedRom.UseMarkup = true;
		this.vbox1.Add (this.labelSelectedRom);
		global::Gtk.Box.BoxChild w10 = ((global::Gtk.Box.BoxChild)(this.vbox1 [this.labelSelectedRom]));
		w10.Position = 2;
		w10.Expand = false;
		w10.Fill = false;
		// Container child vbox1.Gtk.Box+BoxChild
		this.hpaned1 = new global::Gtk.HPaned ();
		this.hpaned1.CanFocus = true;
		this.hpaned1.Name = "hpaned1";
		this.hpaned1.Position = 343;
		// Container child hpaned1.Gtk.Paned+PanedChild
		this.vbox2 = new global::Gtk.VBox ();
		this.vbox2.Name = "vbox2";
		this.vbox2.Spacing = 6;
		// Container child vbox2.Gtk.Box+BoxChild
		this.frame1 = new global::Gtk.Frame ();
		this.frame1.Name = "frame1";
		this.frame1.ShadowType = ((global::Gtk.ShadowType)(0));
		// Container child frame1.Gtk.Container+ContainerChild
		this.GtkAlignment = new global::Gtk.Alignment (0F, 0F, 1F, 1F);
		this.GtkAlignment.Name = "GtkAlignment";
		this.GtkAlignment.LeftPadding = ((uint)(12));
		// Container child GtkAlignment.Gtk.Container+ContainerChild
		this.scrolledwindow1 = new global::Gtk.ScrolledWindow ();
		this.scrolledwindow1.CanFocus = true;
		this.scrolledwindow1.Name = "scrolledwindow1";
		this.scrolledwindow1.ShadowType = ((global::Gtk.ShadowType)(1));
		// Container child scrolledwindow1.Gtk.Container+ContainerChild
		this.nodeview1 = new global::Gtk.NodeView ();
		this.nodeview1.CanFocus = true;
		this.nodeview1.Name = "nodeview1";
		this.scrolledwindow1.Add (this.nodeview1);
		this.GtkAlignment.Add (this.scrolledwindow1);
		this.frame1.Add (this.GtkAlignment);
		this.GtkLabel7 = new global::Gtk.Label ();
		this.GtkLabel7.WidthRequest = 350;
		this.GtkLabel7.HeightRequest = 30;
		this.GtkLabel7.Name = "GtkLabel7";
		this.GtkLabel7.LabelProp = global::Mono.Unix.Catalog.GetString ("<b>GtkFrame</b>");
		this.GtkLabel7.UseMarkup = true;
		this.frame1.LabelWidget = this.GtkLabel7;
		this.vbox2.Add (this.frame1);
		global::Gtk.Box.BoxChild w14 = ((global::Gtk.Box.BoxChild)(this.vbox2 [this.frame1]));
		w14.Position = 0;
		// Container child vbox2.Gtk.Box+BoxChild
		this.frame2 = new global::Gtk.Frame ();
		this.frame2.Name = "frame2";
		this.frame2.ShadowType = ((global::Gtk.ShadowType)(0));
		// Container child frame2.Gtk.Container+ContainerChild
		this.GtkAlignment1 = new global::Gtk.Alignment (0F, 0F, 1F, 1F);
		this.GtkAlignment1.Name = "GtkAlignment1";
		this.GtkAlignment1.LeftPadding = ((uint)(12));
		// Container child GtkAlignment1.Gtk.Container+ContainerChild
		this.hbox2 = new global::Gtk.HBox ();
		this.hbox2.Name = "hbox2";
		this.hbox2.Spacing = 6;
		// Container child hbox2.Gtk.Box+BoxChild
		this.button5 = new global::Gtk.Button ();
		this.button5.CanFocus = true;
		this.button5.Name = "button5";
		this.button5.UseUnderline = true;
		this.button5.Label = global::Mono.Unix.Catalog.GetString ("GtkButton");
		this.hbox2.Add (this.button5);
		global::Gtk.Box.BoxChild w15 = ((global::Gtk.Box.BoxChild)(this.hbox2 [this.button5]));
		w15.Position = 0;
		w15.Expand = false;
		w15.Fill = false;
		// Container child hbox2.Gtk.Box+BoxChild
		this.label1 = new global::Gtk.Label ();
		this.label1.Name = "label1";
		this.label1.LabelProp = global::Mono.Unix.Catalog.GetString ("label1");
		this.hbox2.Add (this.label1);
		global::Gtk.Box.BoxChild w16 = ((global::Gtk.Box.BoxChild)(this.hbox2 [this.label1]));
		w16.Position = 1;
		w16.Expand = false;
		w16.Fill = false;
		// Container child hbox2.Gtk.Box+BoxChild
		this.button6 = new global::Gtk.Button ();
		this.button6.CanFocus = true;
		this.button6.Name = "button6";
		this.button6.UseUnderline = true;
		this.button6.Label = global::Mono.Unix.Catalog.GetString ("GtkButton");
		this.hbox2.Add (this.button6);
		global::Gtk.Box.BoxChild w17 = ((global::Gtk.Box.BoxChild)(this.hbox2 [this.button6]));
		w17.Position = 2;
		w17.Expand = false;
		w17.Fill = false;
		// Container child hbox2.Gtk.Box+BoxChild
		this.button7 = new global::Gtk.Button ();
		this.button7.CanFocus = true;
		this.button7.Name = "button7";
		this.button7.UseUnderline = true;
		this.button7.Label = global::Mono.Unix.Catalog.GetString ("GtkButton");
		this.hbox2.Add (this.button7);
		global::Gtk.Box.BoxChild w18 = ((global::Gtk.Box.BoxChild)(this.hbox2 [this.button7]));
		w18.Position = 3;
		w18.Expand = false;
		w18.Fill = false;
		this.GtkAlignment1.Add (this.hbox2);
		this.frame2.Add (this.GtkAlignment1);
		this.GtkLabel10 = new global::Gtk.Label ();
		this.GtkLabel10.WidthRequest = 60;
		this.GtkLabel10.HeightRequest = 30;
		this.GtkLabel10.Name = "GtkLabel10";
		this.GtkLabel10.LabelProp = global::Mono.Unix.Catalog.GetString ("<b>Gestion</b>");
		this.GtkLabel10.UseMarkup = true;
		this.frame2.LabelWidget = this.GtkLabel10;
		this.vbox2.Add (this.frame2);
		global::Gtk.Box.BoxChild w21 = ((global::Gtk.Box.BoxChild)(this.vbox2 [this.frame2]));
		w21.Position = 1;
		w21.Expand = false;
		w21.Fill = false;
		// Container child vbox2.Gtk.Box+BoxChild
		this.frame3 = new global::Gtk.Frame ();
		this.frame3.HeightRequest = 150;
		this.frame3.Name = "frame3";
		this.frame3.ShadowType = ((global::Gtk.ShadowType)(0));
		// Container child frame3.Gtk.Container+ContainerChild
		this.GtkAlignment2 = new global::Gtk.Alignment (0F, 0F, 1F, 1F);
		this.GtkAlignment2.Name = "GtkAlignment2";
		this.GtkAlignment2.LeftPadding = ((uint)(12));
		// Container child GtkAlignment2.Gtk.Container+ContainerChild
		this.GtkScrolledWindow = new global::Gtk.ScrolledWindow ();
		this.GtkScrolledWindow.HeightRequest = 120;
		this.GtkScrolledWindow.Name = "GtkScrolledWindow";
		this.GtkScrolledWindow.ShadowType = ((global::Gtk.ShadowType)(1));
		// Container child GtkScrolledWindow.Gtk.Container+ContainerChild
		this.nodeview2 = new global::Gtk.NodeView ();
		this.nodeview2.CanFocus = true;
		this.nodeview2.Name = "nodeview2";
		this.GtkScrolledWindow.Add (this.nodeview2);
		this.GtkAlignment2.Add (this.GtkScrolledWindow);
		this.frame3.Add (this.GtkAlignment2);
		this.GtkLabel11 = new global::Gtk.Label ();
		this.GtkLabel11.WidthRequest = 350;
		this.GtkLabel11.HeightRequest = 30;
		this.GtkLabel11.Name = "GtkLabel11";
		this.GtkLabel11.LabelProp = global::Mono.Unix.Catalog.GetString ("<b>GtkFrame</b>");
		this.GtkLabel11.UseMarkup = true;
		this.frame3.LabelWidget = this.GtkLabel11;
		this.vbox2.Add (this.frame3);
		global::Gtk.Box.BoxChild w25 = ((global::Gtk.Box.BoxChild)(this.vbox2 [this.frame3]));
		w25.Position = 2;
		this.hpaned1.Add (this.vbox2);
		global::Gtk.Paned.PanedChild w26 = ((global::Gtk.Paned.PanedChild)(this.hpaned1 [this.vbox2]));
		w26.Resize = false;
		// Container child hpaned1.Gtk.Paned+PanedChild
		this.vpaned1 = new global::Gtk.VPaned ();
		this.vpaned1.CanFocus = true;
		this.vpaned1.Name = "vpaned1";
		this.vpaned1.Position = 223;
		this.hpaned1.Add (this.vpaned1);
		this.vbox1.Add (this.hpaned1);
		global::Gtk.Box.BoxChild w28 = ((global::Gtk.Box.BoxChild)(this.vbox1 [this.hpaned1]));
		w28.Position = 3;
		// Container child vbox1.Gtk.Box+BoxChild
		this.statusbar1 = new global::Gtk.Statusbar ();
		this.statusbar1.Name = "statusbar1";
		this.statusbar1.Spacing = 6;
		// Container child statusbar1.Gtk.Box+BoxChild
		this.label3 = new global::Gtk.Label ();
		this.label3.Name = "label3";
		this.label3.LabelProp = global::Mono.Unix.Catalog.GetString ("label3");
		this.statusbar1.Add (this.label3);
		global::Gtk.Box.BoxChild w29 = ((global::Gtk.Box.BoxChild)(this.statusbar1 [this.label3]));
		w29.Position = 1;
		w29.Expand = false;
		w29.Fill = false;
		this.vbox1.Add (this.statusbar1);
		global::Gtk.Box.BoxChild w30 = ((global::Gtk.Box.BoxChild)(this.vbox1 [this.statusbar1]));
		w30.Position = 4;
		w30.Expand = false;
		w30.Fill = false;
		this.Add (this.vbox1);
		if ((this.Child != null)) {
			this.Child.ShowAll ();
		}
		this.DefaultWidth = 1091;
		this.DefaultHeight = 727;
		this.Show ();
		this.DeleteEvent += new global::Gtk.DeleteEventHandler (this.OnDeleteEvent);
		this.DestroyEvent += new global::Gtk.DestroyEventHandler (this.OnDestroyEventClicked);
		this.FocusInEvent += new global::Gtk.FocusInEventHandler (this.OnFocusInEvent);
		this.SalirAction.Activated += new global::System.EventHandler (this.QuitCliked);
		this.ModoNormalAction.Activated += new global::System.EventHandler (this.ModoNormalClicked);
		this.ModoImagenesAction.Activated += new global::System.EventHandler (this.ModoImagenesClicked);
		this.ModoYoutubeAction.Activated += new global::System.EventHandler (this.ModoYoutubeClicked);
		this.FullScreenAction.Activated += new global::System.EventHandler (this.FullScreenClicked);
		this.entryFind.Activated += new global::System.EventHandler (this.EntryFindActivated);
	}
}
