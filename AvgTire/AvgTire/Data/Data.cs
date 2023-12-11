using System.Security.AccessControl;

namespace AvgTire.Data
{
	public class Data
	{
		private int id;

		private int number;

		private int eventID;

		private DateTime startdate;

		//private DateTime enddate;

		private int type;


		public int Id { get => id; set => id = value; }
		public int Number { get => number; set => number = value; }
		public int EventID { get => eventID; set => eventID = value; }
		public DateTime Startdate { get => startdate; set => startdate = value; }
		//public DateTime Enddate { get => enddate; set => enddate = value; }
		public int Type { get => type; set => type = value; }
    }
}
