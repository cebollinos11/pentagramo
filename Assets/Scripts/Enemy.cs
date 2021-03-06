﻿using UnityEngine;
using System.Collections;

public class Enemy : Actor {
    [SerializeField]GameObject player;
    [SerializeField]
    bool chasingPlayer;
    public float chaseBoost;
    Animator anim;
    Pentagramo pGramo;

	public float playerDistance = 5;

	// Use this for initialization
	public override void Start () {
        player = GameObject.FindGameObjectWithTag("Player");

        pGramo = player.GetComponent<Pentagramo>();
        anim = GetComponentInChildren<Animator>();
        base.Start();
	
	}


    

    public override void FindNewTarget()
    {
        if (chasingPlayer)
        {
            if(player!=null)
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
            FindNewTarget();
        }    
        
    }

    public void StopChasing() {

        if (chasingPlayer) {
            anim.Play("mob_armature|walk");
            Debug.Log("Stop chasing");
            chasingPlayer = false;
            maxSpeed /= chaseBoost;
            FindNewTarget();
        
        }
        
        
    
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

        if(pGramo.state == Pentagramo.State.Glowing  || pGramo.state == Pentagramo.State.Fading)
        {
            Debug.Log(Vector3.Distance(this.transform.position, player.transform.position));
			if(playerDistance > Vector3.Distance(this.transform.position, player.transform.position))
            	StartChasing();
        }
        else{
            StopChasing();
        }



        if (Input.GetKeyDown(KeyCode.Q)) {
            StartChasing();
        }

        if (Input.GetKeyDown(KeyCode.W)) {
            StopChasing();
        }
        base.Update();
    }
}
