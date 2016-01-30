using UnityEngine;
using System.Collections;

public class PentagramoDisplay : MonoBehaviour {

	public Pentagramo pentagramo;

	public GameObject dullFace;
	public GameObject glowingFace;

	bool isFading;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if(pentagramo.state == Pentagramo.State.Glowing){
			glowingFace.SetActive(true);
			dullFace.SetActive(false);
		}
		else if(pentagramo.state == Pentagramo.State.Fading){
			if(!isFading){
				InvokeRepeating("pulse", .1f, .1f);
				isFading = true;
			}
		}
		else{
			isFading = false;
			CancelInvoke("pulse");
			glowingFace.SetActive (false);
			dullFace.SetActive(true);
		}

	
	}

	void pulse(){
		

		if(glowingFace.activeSelf){
			glowingFace.SetActive(false);
		}
		else {
			glowingFace.SetActive(true);
		}
		//yield return new WaitForSeconds(.5f);
		//glowingFace.SetActive(true);
		//yield return WaitForSeconds(.5f);
	}
}
