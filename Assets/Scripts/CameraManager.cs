using UnityEngine;
using System.Collections;

public class CameraManager : MonoBehaviour {

	public bool curCameraIsHigh = true;

	public Pentagramo pentagramo;

	public GameObject highCam;
	public GameObject lowCam;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(pentagramo.state == Pentagramo.State.Flat){
			if(curCameraIsHigh)
				switchToLow();
		}
		else if(pentagramo.state == Pentagramo.State.Upright){
			if(!curCameraIsHigh)
				switchToHigh();
		}
	
	}

	public void switchToHigh(){
		curCameraIsHigh = true;
		highCam.SetActive(true);
		lowCam.SetActive(false);
	}

	public void switchToLow(){
		curCameraIsHigh = false;

		lowCam.SetActive(true);
		highCam.SetActive(false);
	}

}
