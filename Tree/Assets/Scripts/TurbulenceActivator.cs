using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurbulenceActivator : MonoBehaviour {

	public WindZone windZone;

	private void OnTriggerEnter(Collider other) {
		if(other.gameObject.CompareTag("Player")){
			windZone.windTurbulence = 50f;
		}
	}

	private void OnTriggerExit(Collider other) {
		if(other.gameObject.CompareTag("Player")){
			windZone.windTurbulence = 10f;
		}
	}
}
