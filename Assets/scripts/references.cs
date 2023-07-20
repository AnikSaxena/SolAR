using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class references : MonoBehaviour
{
    public rotation[] rot;
    public GameObject[] objects;
    private LineRenderer[] line;
    public static float[] speeds = new float[21];


    private void Awake()
    {
        rot = FindObjectsOfType<rotation>();
        objects = GameObject.FindGameObjectsWithTag("Celestial");
        line = FindObjectsOfType<LineRenderer>();
    }

    private void Start()
    {
        Rotgetter();
    }

    //rotation_Setters_getters
    public float[] Rotgetter()
    {
        int i = 0;
       foreach(rotation rt in rot)
        {
            speeds[i++] = rt.speed;
        }
        return speeds;
    }

    public void Rotsetter_zero()
    {
        foreach(rotation rt in rot)
        {
            rt.speed = 0;
        }
    }
    public void Rotsetter()
    {
        int i = 0;
        foreach (rotation rt in rot)
        {
            rt.speed = speeds[i++];
        }
    }

    //Line_Setter_getters

    public void Enableline()
    {
        foreach(LineRenderer lr in line)
        {
            lr.enabled = lr.enabled;
        }
    }
    public void Disableline()
    {
        foreach (LineRenderer lr in line)
        {
               lr.enabled = !lr.enabled;
        }
    }
}
