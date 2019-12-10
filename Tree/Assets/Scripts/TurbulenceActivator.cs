using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurbulenceActivator : MonoBehaviour {

	public WindZone windZone;
	public float minTurbulence = 10;
	public float maxTurbulence = 60;
	private float turbulence = 10;
	private bool isTurbulence;
	public Color tranquilityColor;
	public Color turbulenceColor;
	public Color transitionColor;
	public Light worldLight;
	public AudioSource wind;
	private float windVolume;

	private void Update() {
		if(isTurbulence){
			turbulence = Mathf.Lerp(turbulence, maxTurbulence,  Time.deltaTime);
			windZone.windTurbulence = turbulence;
			transitionColor = Color.Lerp(transitionColor, turbulenceColor, Time.deltaTime);
			windVolume = Mathf.Lerp( 1, 0.5f, Time.deltaTime);
		}else{
			turbulence  = Mathf.Lerp(turbulence, minTurbulence,  Time.deltaTime);
			windZone.windTurbulence = turbulence;
			transitionColor = Color.Lerp(transitionColor, tranquilityColor, Time.deltaTime);
			windVolume = Mathf.Lerp(0.5f, 1, Time.deltaTime);
		}
			worldLight.color = transitionColor;
			RenderSettings.ambientLight = transitionColor;
			Camera.main.backgroundColor = transitionColor;
			RenderSettings.fogColor = transitionColor;
			wind.volume = windVolume;
	}

	private void OnTriggerEnter(Collider other) {
		if(other.gameObject.CompareTag("Player")){
			isTurbulence = true;
		}
	}

	private void OnTriggerExit(Collider other) {
		if(other.gameObject.CompareTag("Player")){
			isTurbulence= false;
		}
	}
}
