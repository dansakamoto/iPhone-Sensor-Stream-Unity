using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class EstimotePass : NetworkBehaviour {

	public double us = 0, ds = 0, sl = 0, sr = 0;
	//public bool setOffset = false;

	OMobile.EstimoteUnity.EstimotePosition ePos;

	protected void Start(){

		ePos = GameObject.Find ("Controllers").GetComponent<OMobile.EstimoteUnity.EstimotePosition> ();
	}

	[Command]
	public void CmdSetUS(double x){
		us = x;
	}

	[Command]
	public void CmdSetDS(double x){
		ds = x;
	}

	[Command]
	public void CmdSetSR(double x){
		sr = x;
	}

	[Command]
	public void CmdSetSL(double x){
		sl = x;
	}

	[Command]
	public void CmdSetOffset(){
		//setOffset = true;
	}

	protected void Update(){
		if (ePos.us != us) {
			CmdSetUS (ePos.us);
		}

		if (ePos.ds != ds) {
			CmdSetDS (ePos.ds);
		}

		if (ePos.sl != sl) {
			CmdSetSL (ePos.sl);
		}

		if (ePos.sr != sr) {
			CmdSetSR (ePos.sr);
		}


	}

}
