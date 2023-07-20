using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class cameramove : MonoBehaviour
{

    [SerializeField] private Camera cam;
    [SerializeField] public Transform target;
    float distanceToTarget = 500;
    public float rLerp = 0.5f;
    

    private Vector3 previousPosition;

    private void Start()
    {
        setsun();
    }

    void Update()
    {
        
            if (Input.GetMouseButtonDown(0) && !ClickedOnUi())
            {
                previousPosition = cam.ScreenToViewportPoint(Input.mousePosition);
            }
            else if (Input.GetMouseButton(0) && !ClickedOnUi())
            {
                Vector3 newPosition = cam.ScreenToViewportPoint(Input.mousePosition);
                Vector3 direction = previousPosition - newPosition;

                float rotationAroundYAxis = -direction.x * 180; // camera moves horizontally
                float rotationAroundXAxis = direction.y * 180; // camera moves vertically

                cam.transform.position = target.position;

                cam.transform.Rotate(new Vector3(1, 0, 0), rotationAroundXAxis);
                cam.transform.Rotate(new Vector3(0, 1, 0), rotationAroundYAxis, Space.World); // <— This is what makes it work!

                cam.transform.Translate(new Vector3(0, 0, -distanceToTarget));

                previousPosition = newPosition;
            
        }

        // cam.transform.rotation = Quaternion.Lerp(cam.transform.rotation, transform.rotation, rLerp);
        //cam.transform.Rotate(new Vector3(0, 0, 1), 0f);

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

        

        

    }
    void setsun()
    {
        cam.transform.position = target.position;
        cam.transform.Translate(new Vector3(0, 0, -distanceToTarget));
    }
    bool ClickedOnUi()
    {

        PointerEventData eventDataCurrentPosition = new PointerEventData(EventSystem.current);
        eventDataCurrentPosition.position = Input.GetTouch(0).position;
        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventDataCurrentPosition, results);
        // return results.Count > 0;
        foreach (var item in results)
        {
            if (item.gameObject.CompareTag("UI"))
            {
                return true;
            }
        }
        return false;
    }
}