using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundbg : MonoBehaviour
{
    [SerializeField] AudioSource source;

    public static soundbg instance;

    private void Awake()
    {
        if(instance== null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        source.PlayDelayed(1);
    }

    // Update is called once per frame
   
}
