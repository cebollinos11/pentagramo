using UnityEngine;
using System.Collections;

public class Pentagramo : MonoBehaviour
{
    public float MovementSpeed;


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(!Mathf.Approximately(Input.GetAxis("Horizontal"), 0) || !Mathf.Approximately(Input.GetAxis("Vertical"), 0))
        {
            Vector3 inputDir = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            inputDir.Normalize();
            // Facing direction
            transform.rotation = Quaternion.LookRotation(inputDir, Vector3.up);
            // Movement
            transform.position = transform.position + transform.forward * MovementSpeed * Time.deltaTime;
        }


    }
}
