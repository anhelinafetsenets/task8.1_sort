using System;
using System.Collections.Generic;
using System.IO;
namespace task8._1_sort
{
	public delegate int CompareDelegate<T>( T obj1, T obj2);
	static class SortClass
	{
		
		public static void Sort(object[] array, CompareDelegate<object> cd)
		{
			bool fl = true;

			while (fl)
			{
				fl = false;
				for (int i = 0; i < array.Length - 1; i++)
				{
					if (cd.Invoke(array[i], array[i + 1]) == 0)
					{
						object temp = array[i];
						array[i] = array[i + 1];
						array[i + 1] = temp;


					}

				}
			}
		}

		
	}
	class Program
    {
		public static int CompareByName(object a, object b)
		{
			if (String.Compare(((Product)a).Name, ((Product)b).Name) == 0)
			{
				return 1;
			}
			else
			{
				return 0;
			}
		}
		public static int CompareByPrice(object a, object  b)
		{
			
			if (((Product)a).Price < ((Product)b).Price)
			{
				return 1;
			}
			else
			{
				return 0;
			}
		}
		static void Main(string[] args)
        {
			List<Product> listOfProducts = new List<Product>();
			Console.WriteLine("Enter path of file");
			string[] lines = File.ReadAllLines(Console.ReadLine());
		    foreach(string line in lines)
            {
				Product p = new Product(line);
				listOfProducts.Add(p);
            }
			Product[] arrayproduct = new Product[listOfProducts.Count];
			CompareDelegate<object> cd1 = CompareByPrice;
			SortClass.Sort(arrayproduct, cd1);
			CompareDelegate<object> cd2 = CompareByName;
			SortClass.Sort(arrayproduct, cd2);
		}
	}
}
