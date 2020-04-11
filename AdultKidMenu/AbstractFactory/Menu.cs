using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdultKidMenu.AbstractFactory
{
	class AbstractFactoryDemo
	{
		public static void Demo()
		{
			var a = new Chef(new KidsMenu());
			var kidMenu = a.CookMenu();
			Console.WriteLine(kidMenu);

			var b = new Chef(new AdutMenu());
			var adultMenu = b.CookMenu();
			Console.WriteLine(adultMenu);
		}
	}

	abstract class Kitchen
	{
		public abstract Dessert MakeDessert();
		public abstract Savory MakeSavory();
	}

	class AdutMenu : Kitchen
	{
		public override Dessert MakeDessert()
		{
			return new AdultsDessert();
		}

		public override Savory MakeSavory()
		{
			return new AdultsSavory();
		}
	}

	class KidsMenu : Kitchen
	{
		public override Dessert MakeDessert()
		{
			return new KidsDessert();
		}

		public override Savory MakeSavory()
		{
			return new KidssSavory();
		}
	}

	class Chef
	{
		private Kitchen _kitchen;

		public Chef(Kitchen kitchen)
		{
			_kitchen = kitchen;
		}

		public Menu CookMenu()
		{
			var dessert = _kitchen.MakeDessert();
			var savory = _kitchen.MakeSavory();
			return new Menu(dessert, savory);
		}
	}

	abstract class Dessert
	{
		public string DessertName { get; protected set; }
	}

	class AdultsDessert : Dessert
	{
		public AdultsDessert()
		{
			DessertName = "Cheesecake";
		}
	}

	class KidsDessert : Dessert
	{
		public KidsDessert()
		{
			DessertName = "Ice cream";
		}
	}

	abstract class Savory
	{
		public string SavoryName { get; protected set; }
	}

	class AdultsSavory : Savory
	{
		public AdultsSavory()
		{
			SavoryName = "Pizza";
		}
	}

	class KidssSavory : Savory
	{
		public KidssSavory()
		{
			SavoryName = "Chicken Wings";
		}
	}

	class Menu
	{
		 public Dessert Dessert { get; }
		 public Savory Savory { get; }

		public Menu(Dessert d, Savory s)
		{
			Dessert = d;
			Savory = s;
		}

		public override string ToString()
		{
			return $"Your menu consists {Savory.SavoryName} and {Dessert.DessertName}";
		}
	}
}
