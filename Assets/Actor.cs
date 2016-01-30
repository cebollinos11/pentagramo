using UnityEngine;
using System.Collections;

public class Actor : MonoBehaviour {
    
    protected Vector3 currentTarget;
    //public float speed;
    float wanderRange = 5f;
    public float wanderFrequencyChange;
    float currentWanderFrequencyTimer;
    public float maxSpeed;

    protected Animator animator;


    Vector3 originalpos;

    Rigidbody rB;

	// Use this for initialization
	public virtual void Start () {
        
        originalpos = transform.position;
        rB = GetComponent<Rigidbody>();

        animator = GetComponentInChildren<Animator>();
        
        FindNewTarget();
        //speed += Random.Range(0f, 3f);
        
	    
	}

    public virtual void FindNewTarget() {

        currentTarget = transform.position + new Vector3(Random.Range(-wanderRange, wanderRange), 0f, Random.Range(-wanderRange, wanderRange));
    
    }

    void Move(Vector3 dir) {

        
        //transform.position = new Vector3(transform.position.x + dir.x, transform.position.y, transform.position.z + dir.z);
        //rB.velocity += new Vector3(transform.position.x + dir.x,0f, transform.position.z + dir.z);
        rB.velocity += dir*20*Time.timeScale*0.01f;

        if (rB.velocity.magnitude > maxSpeed)
        {
            rB.velocity = rB.velocity.normalized * maxSpeed;
        }
    }
	
	// Update is called once per frame
 	public virtual void Update () {
        
        Vector3 dir;
        dir = currentTarget - transform.position;
        dir = dir.normalized;
        Move(Vector3.Scale((currentTarget - transform.position), new Vector3(1, 0, 1)));

        

        currentWanderFrequencyTimer -= Time.deltaTime;
        if (currentWanderFrequencyTimer < 0)
        {
            currentWanderFrequencyTimer = wanderFrequencyChange + Random.Range(0, 1f);
            FindNewTarget();
        }
	
	}

    void OnCollisionEnter (Collision col){

        if (col.gameObject.tag == "Wall") {
            currentTarget = originalpos;
        }

        Debug.Log("COLLIDERRRRRRR "+col.gameObject.tag);

       
    
    }

    

    
}
