using System.Data.Linq.Mapping;
namespace DataBase
{
	[Table(Name = "User")]
	partial class User
	{
		[Column(IsPrimaryKey = true, IsDbGenerated = true)]
		public int id { get; set; }
		[Column(Name = "Name")]
		public string FirstName { get; set; }
	}

	partial class DataClasses1DataContext
	{

	}

	partial class Table2
	{

	}
}