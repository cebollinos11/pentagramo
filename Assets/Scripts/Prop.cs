﻿using UnityEngine;
using System.Collections;

public class Prop : Actor {

    public GameObject followWho;
    bool alreadySwallowed;
    GameObject satanicParticle;

    public enum aiTypes{
        random,scared,followMop

    }


    public Recipe.Ingredient ObjectID;

    public aiTypes ai;
    GameObject player;
    Recipe recipeManager;

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

        satanicParticle = (GameObject)Resources.Load("SatanicParticle");

        Debug.Log("player found " + player);
        if (ai == aiTypes.followMop && followWho == null)
        {
            followWho = GameObject.FindGameObjectWithTag("Enemy");
            Debug.Log("following " + followWho.ToString());

        }
        player = GameObject.FindGameObjectWithTag("Player");
        base.Start();

        recipeManager = GameObject.FindGameObjectWithTag("RecipePanel").GetComponent<Recipe>();
        animator.Play("book_armature|walk");

       
        
    }

    void GetSwallowed()
    {

        if (!alreadySwallowed) {
            GameObject go = (GameObject)Instantiate(satanicParticle, transform.position+Vector3.up, Quaternion.identity);
            go.transform.parent = transform;
            go.transform.Rotate(new Vector3(-90f, 0, 0));
            StartCoroutine(DieRoutine());
            alreadySwallowed = true;
        }

        

    }


    IEnumerator DieRoutine()
    {
        Debug.Log("Audioexecuted");
        GetComponent<AudioSource>().Play();
        maxSpeed = 0f;
        Vector3 ratio = transform.localScale / 20f;

        do
        {
            transform.localScale -= ratio;
            //transform.Translate(0, 0.1f, 0);
            yield return new WaitForSeconds(0.1f);
        } while (transform.localScale.x > 0);

        yield return new WaitForSeconds(0.1f);
        recipeManager.UpdateIngredient(ObjectID);
        Destroy(transform.gameObject);
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

