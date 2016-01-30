using UnityEngine;
using System.Collections;

public class rotateY : MonoBehaviour {

    public float speed;

	// Use this for initialization
	
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(new Vector3(0,0,1) * speed*Time.timeScale, Space.Self);

    }
}
