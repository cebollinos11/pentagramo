using UnityEngine;
using System.Collections;

public class texture_tiler : MonoBehaviour {
    
    public int x, y;
    // Use this for initialization

    MeshRenderer mr;

    void Start()
    {
        mr = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 currentOffset = mr.material.mainTextureOffset;
        mr.material.mainTextureOffset = currentOffset + new Vector2(1f*x,1f*y)  * Time.deltaTime;

    }
}
