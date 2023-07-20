using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotation : MonoBehaviour
{
    public Transform target;
    public float speed;
    public float var;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var = data.var;
        transform.RotateAround(target.transform.position, target.transform.up, -speed * var * Time.deltaTime);
    }
}
