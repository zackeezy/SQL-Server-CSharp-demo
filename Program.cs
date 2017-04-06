using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace SQLTest
{
	class MainClass
	{
		public static void Main(string[] args)
		{
			string connetionString = null;
			SqlConnection cnn;
			connetionString = "Data Source=localhost;Initial Catalog=pubs;User ID=SA;Password=Password1";
			cnn = new SqlConnection(connetionString);
			try
			{
				cnn.Open();
				System.Console.WriteLine("Connection Open!\n");
			}
			catch (Exception ex)
			{
				System.Console.WriteLine("Can not open connection!\n");
				System.Console.WriteLine(ex.ToString());
			}

			SqlCommand cmd = new SqlCommand ("SELECT * FROM titles", cnn);
			SqlDataReader reader = cmd.ExecuteReader();
			List<List<Object>> list = new List<List<Object>>();
			while (reader.Read())
			{
				List<Object> _list = new List<Object>();
				for (int i = 0; i < reader.FieldCount; i++)
				{
					_list.Add(reader.GetValue(i));
				}
				list.Add(_list);
			}
			Object[] array = list.ToArray();
			foreach (List<Object> i in array)
			{
				Object[] _array = i.ToArray();
				foreach (Object j in _array)
				{
					System.Console.Write(j.ToString());
					System.Console.Write(' ');
				}
				Console.Write('\n');
			}
			cnn.Close ();
		}
	}
}
