using System;
using CustomClass;

namespace WINFAV
{
	public partial class WinFavList : Gtk.Dialog
	{
		private BigData self; 
		private string stRename = "##";

		//***********************************************************************
		//*******     MAIN        METHOD      ****     MAIN        METHOD      **
		//***********************************************************************
		public WinFavList ()
		{
			this.Build ();
			this.Modal = true;
			this.Show ();
			nodeview1.HeadersVisible = true;
			nodeview1.AppendColumn ("-", new Gtk.CellRendererText (), "text", 0);
			nodeview1.AppendColumn ("Lista", new Gtk.CellRendererText (), "text", 1);
			nodeview1.AppendColumn ("Nº Juegos", new Gtk.CellRendererText (), "text", 2);
			DataRefresh ();
		}

		protected void DataRefresh()
		{
			nodeview1.NodeStore = FavStore;
		}

		protected void ButtonAddClick (object sender, EventArgs e)
		{
			AddFav (entry1.Text);
		}

		protected void EntryAddActivated (object sender, EventArgs e)
		{
			AddFav (entry1.Text);
		}

		private void AddFav(string fav)
		{
			if (fav != "") {
				int id = self.Hyperist.Count;
				self.Hyperist.Add(new Juegos(fav, id));
				DataRefresh ();
				entry1.Text = "";

			} else {
				show_error ("VACIO\n\nEscriba un nombre para crear lista.");
			}
		}

		public void CargaWinFav(BigData big)
		{
			self = big;
			nodeview1.NodeStore = FavStore;
		}

		protected void WinFavDestroy (object o, Gtk.DestroyEventArgs args)
		{
			Salir ();
		}

		protected void WinFavClose (object sender, EventArgs e)
		{
			Salir ();
		}

		private void Salir()
		{
			this.Destroy ();
		}

		protected void AceptarClick (object sender, EventArgs e)
		{
			Salir ();
		}

		protected void RowActivated (object o, RowActivatedArgs args)
		{
			MyFavTreeNode node = (MyFavTreeNode) nodeview1.NodeSelection.SelectedNode;
			entry2.Text = node.Lista;
			stRename = node.Lista;
		}

		protected void EliminarListaClick (object sender, EventArgs e)
		{
			try{
				if(stRename != "##"){
					show_mess ();
				}else{
					show_error ("Seleccione Lista\n\npara eliminar");
				}
			}
			catch(Exception){}
		}

		private void show_mess()
		{
			MyFavTreeNode node = (MyFavTreeNode) nodeview1.NodeSelection.SelectedNode;

			string mess = "¿Desea eliminar la Lista de Juegos: " + stRename +
				"\n\nPerderá su lista " + stRename + "\n\n ¿Estás seguro?";

			MessageDialog md = new MessageDialog
				(this, DialogFlags.Modal, MessageType.Error, ButtonsType.YesNo, mess); 

			if ((ResponseType)md.Run () == ResponseType.Yes) 
			{
				Console.WriteLine ("Yes");
				self.RemoveList (node.Lista);
				DataRefresh ();
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

		/// <summary>--------------------------
		/// Gets the store.
		/// Create Store for nodeView
		/// </summary>
		/// <value>The store.</value>
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
				catch(Exception){
					//show_error (err.Message);
				} 
				return store;		
			}
		}

		protected void RenombrarClick (object sender, EventArgs e)
		{
			try{
				if(stRename != "##" && entry2.Text != ""){

					string aux = "";
					int tam = self.Hyperist.Count;

					for(int  i=1; i<tam; i++)
					{
						aux = self.Hyperist[i].NameList;
						if(aux == stRename){
							self.Hyperist[i].NameList = entry2.Text;
							DataRefresh();
							break;
						}
					}
				}
			}catch(Exception){}
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
}