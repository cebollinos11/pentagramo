using UnityEngine;
using System.Collections;

public class Actor : MonoBehaviour {


    GameObject player;
    Rigidbody rB;

    public enum aI_states { 
    
        follow
    
    }

	// Use this for initialization
	void Start () {

        player = GameObject.FindGameObjectWithTag("Player");
        rB = GetComponent<Rigidbody>();
	    
	}
	
	// Update is called once per frame
	void Update () {

        Vector3 dir;
        dir = player.transform.position - transform.position;
        dir = dir.normalized;
        
	
	}
}
