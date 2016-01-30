using UnityEngine;
using System.Collections;

public class Prop : Actor {

    public enum aiTypes{
        random,scared

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
                Debug.Log(player);
                currentTarget = transform.position - player.transform.position;
                break;
        
        }

    }


    public override void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        base.Start();
        
        Debug.Log("player found " + player);
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

