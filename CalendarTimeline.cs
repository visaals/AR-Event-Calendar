using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AssemblyCSharp;
using System.Linq;


public class CalendarTimeline : MonoBehaviour {

	List<CalendarEvent> eventList;

	public CalendarTimeline (List<CalendarEvent> eventList)
	{
		eventList = eventList.OrderBy (o => o.Start).ToList ();
	}




}
