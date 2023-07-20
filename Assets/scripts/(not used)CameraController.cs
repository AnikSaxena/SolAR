using UnityEngine;

public class CameraController : MonoBehaviour
{
    
    public float zoomSpeed = 0.1f;
    public float moveSpeed = 10f;
    public float rotateSpeed = 1f;
    public float maxZoom = 10f;
    public float minZoom = 50f;
    public float smoothTime = 0.3f;

    private Camera mainCamera;
    private Vector3 currentVelocity;

    private Vector2 touchStart;
    private Vector2 touchEnd;

    private bool isMovingToTarget;
    private Transform target;
    private Vector3 previousPosition;

    void Start()
    {
        mainCamera = GetComponent<Camera>();
    }

    void Update()
    {
        /*//zoom in out
        if (Input.touchCount == 2)
        {
            Touch touch0 = Input.GetTouch(0);
            Touch touch1 = Input.GetTouch(1);

            Vector2 touch0PrevPos = touch0.position - touch0.deltaPosition;
            Vector2 touch1PrevPos = touch1.position - touch1.deltaPosition;

            float prevTouchDeltaMag = (touch0PrevPos - touch1PrevPos).magnitude;
            float touchDeltaMag = (touch0.position - touch1.position).magnitude;

            float deltaMagnitudeDiff = prevTouchDeltaMag - touchDeltaMag;

            mainCamera.fieldOfView += deltaMagnitudeDiff * zoomSpeed;
            mainCamera.fieldOfView = Mathf.Clamp(mainCamera.fieldOfView, minZoom, maxZoom);
        }//end*/

        if (Input.touchCount == 1)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                touchStart = touch.position;
            }
            /* rotate in 3d
              else if (touch.phase == TouchPhase.Moved)
            {
                float xMovement = -touch.deltaPosition.x * Time.deltaTime * moveSpeed;
                float yMovement = -touch.deltaPosition.y * Time.deltaTime * moveSpeed;

                transform.Translate(xMovement, yMovement, 0);
            }end */

            //selecting object
            else if (touch.phase == TouchPhase.Ended)
            {
                touchEnd = touch.position;

                float swipeDistance = Vector2.Distance(touchStart, touchEnd);

                if (swipeDistance < 10f)
                {
                    Ray ray = mainCamera.ScreenPointToRay(touchEnd);
                    RaycastHit hit;

                    if (Physics.Raycast(ray, out hit) && hit.transform.CompareTag("Celestial"))
                    {
                        isMovingToTarget = true;
                        target = hit.transform;
                    }
                }
            }
        }

        if (isMovingToTarget && target != null)
        {
            Vector3 targetPosition = new Vector3(target.position.x, target.position.y, -10f);
            transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref currentVelocity, smoothTime);

            if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
            {
                isMovingToTarget = false;
                target = null;
            }
        }//end

        //rotates camera in 3d view
         if (Input.GetMouseButtonDown(0))
         {
             previousPosition = mainCamera.ScreenToViewportPoint(Input.mousePosition);
         }
         else if (Input.GetMouseButton(0))
         {
             Vector3 newPosition = mainCamera.ScreenToViewportPoint(Input.mousePosition);
             Vector3 direction = previousPosition - newPosition;

             float rotationAroundYAxis = -direction.x * 180; // camera moves horizontally
             float rotationAroundXAxis = -direction.y * 180; // camera moves vertically


             mainCamera.transform.Rotate(new Vector3(1, 0, 0), rotationAroundXAxis);
             mainCamera.transform.Rotate(new Vector3(0, 1, 0), rotationAroundYAxis, Space.World); // <— This is what makes it work!

             previousPosition = newPosition;
         }
    }
}
