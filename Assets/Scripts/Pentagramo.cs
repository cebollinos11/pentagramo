using UnityEngine;
using System.Collections;

public class Pentagramo : MonoBehaviour
{


    public float MovementSpeed = 5;
    public float FlatDuration = 1;


    public Transform bodyTransform;

    public enum State
    {
        Upright,
        Dropping,
        Flat,
        Glowing,
        Fading,
        Rising
    }
    public State state;
    private float timer;

    // Use this for initialization
    void Start()
    {
        state = State.Upright;
    }

    // Update is called once per frame
    void Update()
    {
        StateMachine();
        Debug.Log(state);
        switch (state)
        {
            case State.Upright:
                if (!Mathf.Approximately(Input.GetAxis("Horizontal"), 0) || !Mathf.Approximately(Input.GetAxis("Vertical"), 0))
                {
                    Vector3 inputDir = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
                    inputDir.Normalize();
                    // Facing direction
                    transform.rotation = Quaternion.LookRotation(inputDir, Vector3.up);
                    // Movement
                    transform.position = transform.position + transform.forward * MovementSpeed * Time.deltaTime;
                }
                break;
            case State.Dropping:
                bodyTransform.localRotation = Quaternion.Euler(new Vector3(0, 0, 90));
                break;
            case State.Flat:
                            
                break;
            case State.Glowing:
                // Glowing effect
                break;
            case State.Fading:
                // Increment timer
                timer += Time.deltaTime;
                break;
            case State.Rising:
                bodyTransform.localRotation = Quaternion.Euler(new Vector3(0, 0, 0));
                break;
        }
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
                    state = State.Glowing;
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
                    state = State.Glowing;
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
