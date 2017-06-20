using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamReset : MonoBehaviour {

	public void camReset(){
		GameObject.FindGameObjectWithTag ("Player").GetComponent<EstimotePass> ().CmdSetOffset ();
	}
}
