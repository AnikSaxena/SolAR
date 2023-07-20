using System.Collections;
using System.Collections.Generic;
using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class PlaceOnPlane : MonoBehaviour
{

    public GameObject[] arObjectToSpawn = new GameObject[11];
    public GameObject placementIndicator;
   
    private GameObject spwanedObject;

    public ARPointCloudManager PointCloud;
    public ARPlaneManager planeManager;


    private Pose PlacementPose;
    private ARRaycastManager aRRaycastManager;
    private bool placementPoseIsValid = false;

    [SerializeField] Canvas canvas;
    [SerializeField] Slider slider;
        void Start()
    {
        aRRaycastManager = FindObjectOfType<ARRaycastManager>();
    }
     // need to update placement indicator, placement pose and spawn
   void Update()
    {
        if(spwanedObject == null && placementPoseIsValid && Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            ARPlacedObject();
            canvas.gameObject.SetActive(true);
            slider.minValue = 0;
            slider.maxValue = 360;
            slider.onValueChanged.AddListener(rotatemodel);

        }

        UpdatePlacementPose();
        UpdatePlacementIndicator();
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Screen.orientation = ScreenOrientation.LandscapeLeft;
            SceneManager.LoadScene("SampleScene 1");
        }
    }

    void UpdatePlacementIndicator()
    {
        if (spwanedObject == null && placementPoseIsValid)
        {
            placementIndicator.SetActive(true);
            placementIndicator.transform.SetPositionAndRotation(PlacementPose.position, PlacementPose.rotation);
        }
            
    else
        {
            placementIndicator.SetActive(false);
        }
           
    }

    void UpdatePlacementPose()
    {
        var screenCenter = Camera.main.ViewportToScreenPoint(new Vector3(0.5f, 0.5f));
        List<ARRaycastHit> hits = new List<ARRaycastHit>();
        aRRaycastManager.Raycast(screenCenter, hits, TrackableType.Planes);

        placementPoseIsValid = hits.Count > 0;
        if (placementPoseIsValid)
        {
            PlacementPose = hits[0].pose;
        }
          
    }

    void ARPlacedObject()
    {
        PointCloud.enabled = false; // stops from making new ones

        foreach (var Point in PointCloud.trackables) // removes the existing ones.
        {
            Point.gameObject.SetActive(false);
        }
        foreach(var plane in planeManager.trackables)
        {
            plane.gameObject.SetActive(false);
        }
        planeManager.enabled = false;

        foreach(var obj in arObjectToSpawn)
        {
            if(obj.name == data.planetname)
            {
                spwanedObject = Instantiate(obj, PlacementPose.position, PlacementPose.rotation);
            }
        }

    }
    
  void rotatemodel(float value)
    {
        spwanedObject.transform.localEulerAngles = new Vector3(spwanedObject.transform.rotation.x, value, spwanedObject.transform.rotation.z);
    }

}