using UnityEngine;
using System.Collections;

public class Actor : MonoBehaviour {


    GameObject player;
    
    Vector3 currentTarget;
    public float speed;
    public float wanderRange;
    public float wanderFrequencyChange;
    float currentWanderFrequencyTimer;
    public enum aI_states { 
    
        follow
    
    }

	// Use this for initialization
	void Start () {

        player = GameObject.FindGameObjectWithTag("Player");
        FindNewRandomTarget();
        
	    
	}

    void FindNewRandomTarget() {

        currentTarget = transform.position + new Vector3(Random.Range(-wanderRange, wanderRange), 0f, Random.Range(-wanderRange, wanderRange));
    
    }

    void Move(Vector3 dir) {

        dir *= 0.0001f;
        dir *= speed;
        transform.position = new Vector3(transform.position.x + dir.x, transform.position.y, transform.position.z + dir.z);

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
}
