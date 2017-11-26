using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using System.Xml.Linq;
using System.Linq;
using System.Globalization;
using AssemblyCSharp;
using Timeline;
/**
 * TODO: 
 *	 Have sendPostRequest throw errors instead of returning a string
 * 
 * */
namespace ARCalendar
{
	public class CalendarAPI : MonoBehaviour {
		
		public string duc_url = "https://reserve.wustl.edu/eventdataexports/DUC4WindsEntry.xml";
		public string duc_funroom_url = "https://reserve.wustl.edu/eventdataexports/DUC4WindsFunRoom.xml";
		public string olin_url = "https://reserve.wustl.edu/eventdataexports/OlinSign.xml";

		public CalendarTimeline currentTimeline = new CalendarTimeline ();
		public List<CalendarEvent> eventList = new List<CalendarEvent>();

		public CalendarAPI()
		{
			// empty constructor
		}

		void Start () {
			
			// calendar is updated on startup
			this.updateEventList (duc_url);
		
		}

		// Update is called once per frame
		void Update () {
	

		}

		// draw the timeline without updating the events
		public void drawCalendar(string location)
		{

			List<CalendarEvent> roomEvents = new List<CalendarEvent> ();
			// filter events of specified room
			foreach (var e in eventList) 
			{
				if (e.Location == location) 
				{
					roomEvents.Add (e);
					Debug.Log(e.ToString ());
				}

			}

			// update the events in the current timeline
			this.currentTimeline.updateEvents (roomEvents);
			// draw it
			this.currentTimeline.drawTimeLine ();
		}



		public void updateEventList(string url)
		{

			// send the request to get response text
			string responseText = this.sendPostRequest (url);

			// format the response text
			string xmlResponse = this.cleanXmlResponseString(responseText);
	
			// convert XmlDocument to list of game objects
			// updated eventlist to most up to date events
			eventList = this.convertXmlToEventList(xmlResponse);


		}


		private List<CalendarEvent> convertXmlToEventList(string xmlResponse)
		{
			XmlDocument eventXmlDoc = new XmlDocument ();
			eventXmlDoc.LoadXml (xmlResponse);

			List<CalendarEvent> eventList = new List<CalendarEvent> ();

			// For each event Node, 
			//	put all the event children into an array (inner for loop)
			//	create a calendarEvent object from that array
			//	append the calendarEvent object to the list
			// 	return the List of CalendarEvents
			foreach (XmlNode eventNode in eventXmlDoc.DocumentElement) 
			{

				string[] eventParams = new string[eventNode.ChildNodes.Count];

				for (int i = 0; i < eventNode.ChildNodes.Count; i++) 
				{
					eventParams[i] = eventNode.ChildNodes.Item(i).InnerText;
				}

				// create a calendar event object from the eventParams array
				CalendarEvent calendarEvent = new CalendarEvent (eventParams);

				eventList.Add (calendarEvent);

			}

			return eventList;

		}

		private string sendPostRequest(string url)
		{
			WWW post_request = new WWW (url);

			while (!post_request.isDone) {
				Debug.Log ("Loading events...");
			}

			if (post_request.error == null) {
				
				Debug.Log ("POST Request Successful.");

				return post_request.text;

			} else {
				
				Debug.Log("POST Request Failure: " + post_request.error);

				return post_request.error;
			}
		}


		private string cleanXmlResponseString(string response){
			
			// get rid of UTF-8 BOM
			System.IO.StringReader stringReader = new System.IO.StringReader(response);
			stringReader.Read(); // skip BOM
			System.Xml.XmlReader.Create(stringReader);
			string loadableXmlResponse = stringReader.ReadToEnd ();

			return loadableXmlResponse;

		}
			

	}
}
