using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using MiniJSON;

namespace OMobile.EstimoteUnity
{
	public class EstimotePosition : MonoBehaviour
	{

		#region Public Variables

		public EstimoteUnity _EstimoteUnity;
		public Text _DebugText;

		public int maj, us_min, ds_min, sr_min, sl_min;
		public double us, ds, sr, sl;

		#endregion

		#region Unity Methods

		void Start ()
		{
			_EstimoteUnity.OnDidRangeBeacons += HandleDidRangeBeacons;
		}

		#endregion

		#region Public Methods

		public void StartScanning ()
		{
			_EstimoteUnity.StartScanning ();
		}

		public void StopScanning ()
		{
			_EstimoteUnity.StopScanning ();
			_DebugText.text = "Press \"Start Scanning\" to scan for beacons";
		}

		#endregion

		#region Private Methods

		private void HandleDidRangeBeacons (List<EstimoteUnityBeacon> beacons)
		{
			string debugBeacons = "";
			if (beacons != null && beacons.Count > 0) {
				foreach (EstimoteUnityBeacon beacon in beacons) {

					if (beacon.Minor == us_min) {
						us = beacon.Accuracy;
						debugBeacons += "US: " + beacon.ToString () + "\n";
					} else if (beacon.Minor == ds_min) {
						ds = beacon.Accuracy;
						debugBeacons += "DS: " + beacon.ToString () + "\n";
					} else if (beacon.Minor == sl_min) {
						sl = beacon.Accuracy;
						debugBeacons += "SL: " + beacon.ToString () + "\n";
					} else if (beacon.Minor == sr_min) {
						sr = beacon.Accuracy;
						debugBeacons += "SR: " + beacon.ToString () + "\n";
					}
				}
			}
			_DebugText.text = debugBeacons;
			//Debug.Log ("values: " + us + ds + sr + sl);
		}

		#endregion

	}
}