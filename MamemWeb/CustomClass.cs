using System;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;

namespace CustomClass
{
	//---------------------------------------------------------------
	//----------------------     classes   --------------------------
	//---------------------------------------------------------------


	/// <summary>	-------------------------------------
	/// 							Juegos.
	/// <summary>	-------------------------------------
	[Serializable]
	public class Juegos
	{
		public string NameList;
		public int Id;
		public List<Juego> game;

		public Juegos(string namelist, int id)
		{
			NameList = namelist;
			Id = id;
			game = new List<Juego>();
		}

		public void AddGame (string nameG, string romG)
		{
			game.Add (new Juego (romG, nameG));
		}

		public void RemoveGame(string rom)
		{
			int tam = game.Count;
			for (int i=0; i<tam; i++) 
			{
				if (game [i].Rom == rom) {
					game.RemoveAt (i);
					break;
				}
			}
		}
	}

	/// <summary>	-------------------------------------
	/// 							JuegO
	/// <summary>	-------------------------------------
	[Serializable]
	public class Juego
	{
		public string Rom;
		public string Name;
		public Juego(string rom, string name)
		{
			Rom = rom;
			Name = name;
		}
	}

	/// <summary>	-------------------------------------
	/// 							BIG DATA
	/// <summary>	-------------------------------------
	[Serializable]
	public class BigData
	{
		public List<Juegos> Hyperist;
		public BigData()
		{
			Hyperist =  new List<Juegos> ();
		}

		public void RemoveList(string lista)
		{
			int tam = Hyperist.Count;
			for (int i=1; i<tam; i++) {
				if (Hyperist [i].NameList == lista) {
					Hyperist.RemoveAt (i);


					for(int y=i; y<tam; y++){
						Hyperist [y].Id = y;
					}
					break;
				}
			}
		}
	}


}


