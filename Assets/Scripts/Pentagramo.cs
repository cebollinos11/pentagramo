using UnityEngine;
using System.Collections;

public class Pentagramo : MonoBehaviour
{

    
    public float MovementSpeed = 5;
    public float FlatDuration = 1;

    public Transform rotationTransform;
    public Transform parentTransform;

    public GameObject FaceToRotate;

    PentagramoDisplay pDisplay;

    GameManager gameManager;

    

    public enum State
    {
        Upright,
        Dropping,
        Flat,
        FrameGlowing,
        Glowing,
        Fading,
        Rising
    }
	public bool isMoving;

    public State state;
    private float timer;
    GameObject invokeParticles;

    // Use this for initialization
    void Start()
    {

        invokeParticles = (GameObject)Resources.Load("InvocationParticle");
        state = State.Upright;
        pDisplay = GetComponent<PentagramoDisplay>();

        gameManager = GameObject.FindGameObjectWithTag("GameMaker").GetComponent<GameManager>();
        
    }

    // Update is called once per frame
    void Update()
    {
        StateMachine();
        //Debug.Log(state);
        switch (state)
        {
            case State.Upright:
                if (!Mathf.Approximately(Input.GetAxis("Horizontal"), 0) || !Mathf.Approximately(Input.GetAxis("Vertical"), 0))
                {
                    Vector3 inputDir = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
                    inputDir.Normalize();
                    // Facing direction
                    parentTransform.rotation = Quaternion.LookRotation(inputDir, Vector3.up);
                    // Movement
                    parentTransform.position = parentTransform.position + parentTransform.forward * MovementSpeed * Time.deltaTime;

                    FaceToRotate.transform.Rotate(-Vector3.forward*Time.deltaTime*300f);
                }
                else
                {
                    isMoving = false;
                }
                break;
            case State.Dropping:
                rotationTransform.localRotation = Quaternion.Euler(new Vector3(0, 0, 90));
                break;
            case State.Flat:
                            
                break;
            case State.FrameGlowing:
                pDisplay.StartParticles();
                GameObject go = (GameObject)Instantiate(invokeParticles, transform.position+Vector3.up, Quaternion.identity);
                go.transform.Rotate(new Vector3(-90f, 0, 0));
                
                state = State.Glowing;
                break;

            case State.Glowing:
                // Glowing effect
                break;
            case State.Fading:
                // Increment timer
                timer += Time.deltaTime;
                pDisplay.StopParticles();
                break;
            case State.Rising:
                rotationTransform.localRotation = Quaternion.Euler(new Vector3(0, 0, 0));
                break;
        }
    }

    public void Die() {

        Debug.Log("GAME OVER");
        GetComponent<AudioSource>().Play();
        StartCoroutine(DieRoutine());
        
    
    }


    IEnumerator DieRoutine() {

        Vector3 ratio = parentTransform.localScale/50f;

        do
        {
            parentTransform.localScale -= ratio;
            yield return new WaitForSeconds(0.1f);
        } while (parentTransform.localScale.x > 0);

        yield return new WaitForSeconds(3f);
        gameManager.Restart();
        Destroy(parentTransform.gameObject);
    }


  

    void StateMachine()
    {
        switch(state)
        {
            case State.Upright:
                if(Input.GetButtonDown("Fire1"))
                {
                    state = State.Dropping;    
                }
                break;
            case State.Dropping:
                // Angle check
                state = State.Flat;
                break;
            case State.Flat:
                if (Input.GetButtonDown("Fire1"))
                {
                    state = State.Rising;
                }
                else if(Input.GetButtonDown("Fire2"))
                {
                    state = State.FrameGlowing;
                }
                break;
            case State.Glowing:
                // TODO: Switch to GetButton?
                if(Input.GetButtonUp("Fire2"))
                {
                    state = State.Fading;
                    timer = 0;
                }
                break;
            case State.Fading:
                if (Input.GetButtonDown("Fire2"))
                {
                    state = State.FrameGlowing;
                }
                else if (timer >= FlatDuration)
                {
                    state = State.Flat;
                }
                break;
            case State.Rising:
                // Angle check
                state = State.Upright;
                break;
        }
        
    }
}
