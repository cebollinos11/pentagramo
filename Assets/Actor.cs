using UnityEngine;
using System.Collections;

public class Actor : MonoBehaviour {


    GameObject player;
    
    Vector3 currentTarget;
    public float speed;
    public float wanderRange;
    public float wanderFrequencyChange;
    float currentWanderFrequencyTimer;
    public float maxSpeed;
    public enum aI_states { 
    
        follow
    
    }

    Vector3 originalpos;

    Rigidbody rB;

	// Use this for initialization
	void Start () {
        originalpos = transform.position;
        rB = GetComponent<Rigidbody>();
        player = GameObject.FindGameObjectWithTag("Player");
        FindNewRandomTarget();
        speed += Random.Range(0f, 3f);
        
	    
	}

    void FindNewRandomTarget() {

        currentTarget = transform.position + new Vector3(Random.Range(-wanderRange, wanderRange), 0f, Random.Range(-wanderRange, wanderRange));
    
    }

    void Move(Vector3 dir) {

        
        //transform.position = new Vector3(transform.position.x + dir.x, transform.position.y, transform.position.z + dir.z);
        //rB.velocity += new Vector3(transform.position.x + dir.x,0f, transform.position.z + dir.z);
        rB.velocity += dir*speed*Time.timeScale*0.01f;

        if (rB.velocity.magnitude > maxSpeed)
        {

            rB.velocity = rB.velocity.normalized * maxSpeed;
        }
    }
	
	// Update is called once per frame
	void Update () {

        Vector3 dir;
        dir = currentTarget - transform.position;
        dir = dir.normalized;
        Move(Vector3.Scale((currentTarget - transform.position), new Vector3(1, 0, 1)));

        if (Input.GetKeyDown(KeyCode.Space))
        {

            FindNewRandomTarget();
        }

        currentWanderFrequencyTimer -= Time.deltaTime;
        if (currentWanderFrequencyTimer < 0)
        {
            currentWanderFrequencyTimer = wanderFrequencyChange + Random.Range(0, 1f);
            FindNewRandomTarget();
        }
	
	}

    void OnCollisionEnter (Collision col){

        if (col.gameObject.tag == "Wall") {
            currentTarget = originalpos;
        }
    
    }
}
