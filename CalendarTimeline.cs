using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AssemblyCSharp;
using System.Linq;

namespace Timeline
{
	public class CalendarTimeline : MonoBehaviour {

		private List<CalendarEvent> eventList;

		// default constructor
		public CalendarTimeline()
		{
			
		}

		public CalendarTimeline (List<CalendarEvent> eventList)
		{
			this.eventList = eventList.OrderBy (o => o.Start).ToList ();
		}

		public void updateEvents(List<CalendarEvent> eventList)
		{
			this.eventList = eventList.OrderBy (o => o.Start).ToList ();
		}


		// this should draw the updated game objects in a time line view
		public void drawTimeLine()
		{


		}
		// update the text on each game object in the time line
		// also update the position of each game object (relative to imagetarget)
		private void updateGameObjects()
		{

		}

	}
}



