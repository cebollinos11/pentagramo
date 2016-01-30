using UnityEngine;
using System.Collections;

public class Enemy : Actor {
    GameObject player;
    bool chasingPlayer;
    public float chaseBoost;
    Animator anim;

	// Use this for initialization
	public override void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        anim = GetComponentInChildren<Animator>();
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
            anim.Play("mob_armature|kill");
            Debug.Log("start chasing");
            maxSpeed *= chaseBoost;
            chasingPlayer = true;
        
        }
       
        FindNewTarget();
    }

    public void StopChasing() {

        if (chasingPlayer) {
            anim.Play("mob_armature|walk");
            Debug.Log("Stop chasing");
            chasingPlayer = false;
            maxSpeed /= chaseBoost;
        
        }
        
        FindNewTarget();
    
    }


    void OnTriggerStay(Collider col)
    {

        if (col.gameObject.tag == "Player")
        {

            Pentagramo p = col.gameObject.GetComponent<Pentagramo>();
            if (p.state == Pentagramo.State.Glowing || p.state == Pentagramo.State.Fading)
            {

                p.Die();
            }


        }
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
