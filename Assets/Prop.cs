using UnityEngine;
using System.Collections;

public class Prop : Actor {


    public override void Start()
    {
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

