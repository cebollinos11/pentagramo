using UnityEngine;
using System.Collections;

public class Enemy : Actor {
    GameObject player;
    bool chasingPlayer;
    public float chaseBoost;

	// Use this for initialization
	public override void Start () {
        player = GameObject.FindGameObjectWithTag("Player");        
        base.Start();
	
	}


    

    public override void FindNewTarget()
    {
        if (chasingPlayer)
        {
            currentTarget = player.transform.position;
            

        }
        else {
            base.FindNewTarget();
        }        
    }

    public void StartChasing() {
        if (!chasingPlayer) {

            Debug.Log("start chasing");
            maxSpeed *= chaseBoost;
            chasingPlayer = true;
        
        }
       
        FindNewTarget();
    }

    public void StopChasing() {

        if (chasingPlayer) {

            Debug.Log("Stop chasing");
            chasingPlayer = false;
            maxSpeed /= chaseBoost;
        
        }
        
        FindNewTarget();
    
    }



    public override void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q)) {
            StartChasing();
        }

        if (Input.GetKeyDown(KeyCode.W)) {
            StopChasing();
        }
        base.Update();
    }
}
