using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEngine;

public class planetview : MonoBehaviour
{
    private int dist;
    private int Trip = 0;

    public Camera cam;

    public Vector3 velocity = Vector3.zero;
    private float speed = 10f;
    private Vector3 rv;

    private Transform target;
    Vector3 finalpos;

    public GameObject[] objects;

    public float rLerp = 0.5f;
    private Vector3 previousPosition;

    public Canvas canvas;


    // Start is called before the first frame update
    private void Awake()
    {
        foreach(GameObject obj in objects)
        {
            if(obj.name==data.planetname)
            {
                obj.SetActive(true);
                target = obj.transform;
            }
        }
    }
    void Start()
    {
        setup();
        StartCoroutine(MyCoroutine());
    }

    // Update is called once per frame
    void Update()
    {
        if(Trip==1)
        {
            cam.transform.position = target.position;
            cam.transform.Translate(new Vector3(0, 0, -dist));
            canvas.gameObject.SetActive(true);
        }
        

        if (Input.GetMouseButtonDown(0))
            {
                previousPosition = cam.ScreenToViewportPoint(Input.mousePosition);
                
            }
            else if (Input.GetMouseButton(0))
            {
                Vector3 newPosition = cam.ScreenToViewportPoint(Input.mousePosition);
                Vector3 direction = previousPosition - newPosition;

                float rotationAroundYAxis = -direction.x * 180; // camera moves horizontally
                float rotationAroundXAxis = direction.y * 180; // camera moves verticall

                

                transform.Rotate(new Vector3(1, 0, 0), rotationAroundXAxis);
                transform.Rotate(new Vector3(0, 1, 0), rotationAroundYAxis, Space.World); // <— This is what makes it work!

                cam.transform.rotation = Quaternion.LerpUnclamped(cam.transform.rotation, transform.rotation, rLerp);
                


                previousPosition = newPosition;
            }
        

    }
   

    public void setup()
    {
        if(data.planetname== "sun" || data.planetname== "sunsphere")
        {
            Debug.Log(data.planetname);
            dist = 100;
        }
        else
        {
            dist = 65;
        }

         rv =new Vector3(0, -25, dist);
         finalpos = target.position - rv;
        Debug.Log(finalpos);
    }
    IEnumerator MyCoroutine()
    {
        while(Vector3.Distance(cam.transform.position,finalpos)>0.05f)
        {
            cam.transform.position = Vector3.SmoothDamp(cam.transform.position, finalpos,ref velocity, speed * Time.deltaTime);
            yield return null;
        }
        Trip = 1;
        yield return null;
    }
}
