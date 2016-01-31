using UnityEngine;
using System.Collections;

public class PentagramoCamera : MonoBehaviour {

	public Pentagramo pentagramo;

	Vector3 offset;

	// Use this for initialization
	void Start () {

		offset = new Vector3(0, 0 , 0);
		offset.z = pentagramo.transform.position.z - this.transform.position.z;
		offset.x = pentagramo.transform.position.x - this.transform.position.x;

	
	}
	
	// Update is called once per frame
	void Update () {

		//sync z and x

		Vector3 newPos = this.transform.position;

		newPos.z = pentagramo.transform.position.z + offset.z;
		newPos.x = pentagramo.transform.position.x + offset.x;
		this.transform.position = newPos;
	}

	void focusIn(){
	}

	void focusOut(){
	}

}
