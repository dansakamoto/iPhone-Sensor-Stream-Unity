using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using MiniJSON;

namespace OMobile.EstimoteUnity
{
	public class EstimotePos : MonoBehaviour
	{

		public int maj, us_min, ds_min, sr_min, sl_min;
		//public double us_send, ds_send, sl_send, sr_send;

		EstimotePass player;
		bool playerFound = false;

		#region Public Variables

		public EstimoteUnity _EstimoteUnity;
		//public Text _DebugText;

		#endregion

		#region Unity Methods

		void Start ()
		{
			_EstimoteUnity.OnDidRangeBeacons += HandleDidRangeBeacons;
		}
		/*
		void Update (){
			if (!playerFound) {
				if (GameObject.Find ("Player") != null) {
					player = GameObject.Find ("Player").GetComponent<EstimotePass>();
					playerFound = true;
					StartScanning ();
				} else {
					return;
				}
			}
		}
		*/

		#endregion

		#region Public Methods

		public void StartScanning ()
		{
			_EstimoteUnity.StartScanning ();
		}

		public void StopScanning ()
		{
			_EstimoteUnity.StopScanning ();
			//_DebugText.text = "Press \"Start Scanning\" to scan for beacons";
		}

		#endregion

		#region Private Methods

		private void HandleDidRangeBeacons (List<EstimoteUnityBeacon> beacons)
		{

			Debug.Log ("did range beacons");

			if (!playerFound) {
				if (GameObject.Find ("Player") != null) {
					player = GameObject.Find ("Player").GetComponent<EstimotePass>();
					playerFound = true;
					StartScanning ();
				} else {
					return;
				}
			}

			string debugBeacons = "";
			double us = 0f, ds = 0f, sl = 0f, sr = 0f;

			if (beacons != null && beacons.Count > 0) {
				foreach (EstimoteUnityBeacon beacon in beacons) {
					Debug.Log (beacon.ToString());
					if (beacon.Major == maj) {
						debugBeacons += beacon.ToString () + "\n";

						if (beacon.Minor == us_min) {
							us = beacon.Accuracy;
						} else if (beacon.Minor == ds_min) {
							ds = beacon.Accuracy;
						} else if (beacon.Minor == sl_min) {
							sl = beacon.Accuracy;
						} else if (beacon.Minor == sr_min) {
							sr = beacon.Accuracy;
						}
					
					}
				}
			}
			player.ds = ds;
			player.us = us;
			player.sl = sl;
			player.sr = sr;
			Debug.Log(debugBeacons);
		}

		#endregion

	}
}