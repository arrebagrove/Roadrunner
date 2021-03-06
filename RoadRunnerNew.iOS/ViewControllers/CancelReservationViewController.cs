using Foundation;
using System;
using System.CodeDom.Compiler;
using RoadRunnerNew.iOS.Extension;
using UIKit;
using RoadRunner.Shared;
using Plugin.Messaging;

namespace RoadRunnerNew.iOS
{
	partial class CancelReservationViewController : BaseViewController
	{
		public GetMyBookedReservationsResponseReservation item{ get; set;}

		public CancelReservationViewController (IntPtr handle) : base (handle)
		{
			Title = "MY TRIPS";
		}
		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			NavigationItem.Customize (NavigationController);

			DateTime pDate = DateTime.Parse(item.createdOn);
			string[] arrDate = pDate.GetDateTimeFormats ();

			lblDetailTripTitle.Text = arrDate[8];

			btnDetailReservationID.SetCustomRIDButton ();
			string strReservationID = String.Format("{1} {2}", Environment.NewLine, "  Reservation #: ", item.ReservationID);
			btnDetailReservationID.SetTitle (strReservationID, UIControlState.Normal);

			btnCancelReservation.SetCustomButton();
			btnCancelReservation.TouchUpInside += (object sender, EventArgs e) => {

				var phoneCallTask = MessagingPlugin.PhoneDialer;
				if(phoneCallTask.CanMakePhoneCall){
					phoneCallTask.MakePhoneCall("8002477919", "Roadrunner Support");
				}else{
					var okAlertController = UIAlertController.Create("error", "you can't make phone call on emulator", UIAlertControllerStyle.Alert);
					okAlertController.AddAction(UIAlertAction.Create("ok", UIAlertActionStyle.Default, null));
					PresentViewController(okAlertController, true, null);
				}
			};

			if (item.pickUpTime == "")
				pDate = DateTime.Now;
			else
				pDate = DateTime.Parse(item.pickUpTime);
			arrDate = pDate.GetDateTimeFormats ();

			lblDetailPickupDate.Text = String.Format("{1} {2} {3}", Environment.NewLine, "Pick up at ", arrDate[106], " from");

			var pCity = item.Pickcity.IsMatchRegex
				? String.Format("{1} {2} {3} {4} {5} {6}", Environment.NewLine, item.Pickcity.stNum, item.Pickcity.street, item.Pickcity.complex, item.Pickcity.unit,
					item.Pickcity.city, item.Pickcity.zip)
				: String.Format("{1}", Environment.NewLine, item.Pickcity.raw);

			lblDetailPickupLocation.Text = pCity;

			if (item.dropOffTime == "")
				pDate = DateTime.Now;
			else
				pDate = DateTime.Parse(item.dropOffTime);
			arrDate = pDate.GetDateTimeFormats ();

			lblDetailDropoffDate.Text = String.Format("{1} {2} {3}", Environment.NewLine, "Take off at ", arrDate[106], " from");

			var dCity = item.Dropoff.IsMatchRegex
				? String.Format("{1} {2} {3} {4} {5} {6}", Environment.NewLine, item.Dropoff.stNum, item.Dropoff.street, item.Dropoff.complex, item.Dropoff.unit, item.Dropoff.city,
					item.Dropoff.zip)
				: String.Format("{1}", Environment.NewLine, item.Dropoff.raw);

			lblDetailDropoffLocation.Text = dCity;
		}
	}
}
