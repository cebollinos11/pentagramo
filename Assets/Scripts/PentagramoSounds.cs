using UnityEngine;
using System.Collections;

public class PentagramoSounds : MonoBehaviour {

	Pentagramo pentagramo;
	
	public AudioSource walkStart;
	public AudioSource walkLoop;

	bool startedMoving;

	// Use this for initialization
	void Start () {

        pentagramo = GetComponent<Pentagramo>();
	
	}
	
	// Update is called once per frame
	void Update () {
        
		if(pentagramo.isMoving){
			if(!startedMoving){
                
				startedMoving = true;
				walkStart.Play();
				walkLoop.Play(); //TODO needs to fade in
			}
		}
		else{
			if(startedMoving){
				startedMoving = false;
				walkStart.Stop();
				walkLoop.Stop();
			}

		}
	
	}
}
