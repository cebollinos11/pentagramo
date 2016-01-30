using UnityEngine;
using System.Collections;

public class Prop : Actor {

    GameObject followWho;
    

    public enum aiTypes{
        random,scared,followMop

    }

    public aiTypes ai;
    GameObject player;

    public override void FindNewTarget()
    {
        Debug.Log("finding new tar");
        //base.FindNewTarget();
        switch(ai){

            case aiTypes.random:
                base.FindNewTarget();
                break;
            case aiTypes.scared:
                
                currentTarget = transform.position - player.transform.position;
                currentTarget  = Vector3.Scale( currentTarget , new Vector3(1,0,1))+new Vector3(0,1,0)*transform.position.y;
                
                Debug.Log("going to "+currentTarget.ToString());
                break;
            case aiTypes.followMop:
                currentTarget = followWho.transform.position;
                break;
        
        }

    }


    public override void Start()
    {
        Debug.Log("player found " + player);
        if (ai == aiTypes.followMop)
        {
            followWho = GameObject.FindGameObjectWithTag("Enemy");
            Debug.Log("following " + followWho.ToString());

        }
        player = GameObject.FindGameObjectWithTag("Player");
        base.Start();
        
        
        animator.Play("book_armature|walk");

       
        
    }

    void GetSwallowed()
    {

        Debug.Log("suchiiiiiiiiiiii");
        Destroy(this.gameObject);

    }

    void OnTriggerStay(Collider col) {

        if (col.gameObject.tag == "Player")
        {

            Pentagramo p = col.gameObject.GetComponent<Pentagramo>();
            if (p.state == Pentagramo.State.Glowing || p.state == Pentagramo.State.Fading)
            {
                GetSwallowed();
            }

           // Debug.Log(p.state);

        }
    
    }

}

