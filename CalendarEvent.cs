using System;
using System.Globalization;
using UnityEngine;
namespace AssemblyCSharp
{
	
	public class CalendarEvent
	{

		public string Subject;
		public string Location;
		public string LocationFull;

		public DateTime Start; // convert to time
		public DateTime End; // convert to time
		public DateTime Date; // convert to date

		public string Categories;

		public string LastModifiedName;
		public DateTime LastModifiedTime;

		public string Target;
		public string GroupName;

		public CalendarEvent (string subject, string location, string locationFull, string start, string end, string date, string categories, string lastModifiedName, string lastModifiedTime, string target, string groupName)
		{
			
			this.Subject = subject;
			this.Location = location;
			this.LocationFull = locationFull;
			this.Start = DateTime.Parse(start);
			this.End = DateTime.Parse(end);
			this.Date = DateTime.ParseExact(date, "MM/dd/yyy", CultureInfo.InvariantCulture);
			this.Categories = categories;
			this.LastModifiedName = lastModifiedName;
			this.LastModifiedTime = DateTime.Parse(lastModifiedTime);
			this.Target = target;
			this.GroupName = groupName;
		}

		// puts the 11 arguments to make a Calendar Event into an array
		public CalendarEvent (string[] eventParams)
		{

			this.Subject = eventParams[0];
			this.Location = eventParams[1];
			this.LocationFull = eventParams[2];
			this.Start = DateTime.Parse(eventParams[3]);
			this.End = DateTime.Parse(eventParams[4]);
			this.Date = DateTime.ParseExact(eventParams[5], "MM/dd/yyy", CultureInfo.InvariantCulture);
			this.Categories = eventParams[6];
			this.LastModifiedName = eventParams[7];
			this.LastModifiedTime = DateTime.Parse(eventParams[8]);
			this.Target = eventParams[9];
			this.GroupName = eventParams[10];

		}
	
		public GameObject createBlock()
		{
			GameObject go = new GameObject ();
			return go;
		}


		public override string ToString ()
		{
			return string.Format ("[CalendarEvent: Subject={0}, Location={1}, LocationFull={2}, Start={3}, End={4}, Date={5}, Categories={6}, LastModifiedName={7}, LastModifiedTime={8}, Target={9}, GroupName={10}]", Subject, Location, LocationFull, Start, End, Date, Categories, LastModifiedName, LastModifiedTime, Target, GroupName);
		}

	
	}
}

