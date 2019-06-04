using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapCamMovement : MonoBehaviour
{
    public float orthographicSizeMin;
    public float orthographicSizeMax;

    public float xMax;
    public float yMax;

    Vector2 StartPosition;
    Vector2 DragStartPosition;
    Vector2 DragNewPosition;
    Vector2 Finger0Position;
    float DistanceBetweenFingers;
    bool isZooming;

    private void Start()
    {
        GameObject cam = Camera.main.gameObject;
        cam.transform.position = new Vector3(Mathf.Clamp(cam.transform.position.x, -xMax, xMax), Mathf.Clamp(cam.transform.position.y, -yMax, yMax), cam.transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        Camera cam = Camera.main;
        if (Input.touchCount == 0 && isZooming)
        {
            isZooming = false;
        }

        if (Input.touchCount > 0)
        {
            if (!isZooming)
            {
                if (Input.GetTouch(0).phase == TouchPhase.Moved)
                {
                    Vector2 NewPosition = GetWorldPosition(cam);
                    Vector2 PositionDifference = NewPosition - StartPosition;
                    cam.gameObject.transform.Translate(-PositionDifference);
                    Vector3 pos = cam.gameObject.transform.position;
                    cam.gameObject.transform.position = new Vector3(Mathf.Clamp(pos.x, -xMax, xMax), Mathf.Clamp(pos.y, -yMax, yMax), pos.z);
                }
                StartPosition = GetWorldPosition(cam);
            }
        }
        //else if (Input.touchCount == 2)
        //{
        //    if (Input.GetTouch(1).phase == TouchPhase.Moved)
        //    {
        //        isZooming = true;

        //        DragNewPosition = GetWorldPositionOfFinger(1, cam);
        //        Vector2 PositionDifference = DragNewPosition - DragStartPosition;

        //        if (Vector2.Distance(DragNewPosition, Finger0Position) < DistanceBetweenFingers)
        //            cam.orthographicSize += (PositionDifference.magnitude);

        //        if (Vector2.Distance(DragNewPosition, Finger0Position) >= DistanceBetweenFingers)
        //            cam.orthographicSize -= (PositionDifference.magnitude);

        //        DistanceBetweenFingers = Vector2.Distance(DragNewPosition, Finger0Position);

        //        cam.orthographicSize = Mathf.Clamp(cam.orthographicSize, orthographicSizeMin, orthographicSizeMax);
        //    }
        //    DragStartPosition = GetWorldPositionOfFinger(1, cam);
        //    Finger0Position = GetWorldPositionOfFinger(0, cam);
        //}
    }

    Vector2 GetWorldPosition(Camera cam)
    {
        return cam.ScreenToWorldPoint(Input.mousePosition);
    }

    Vector2 GetWorldPositionOfFinger(int FingerIndex, Camera cam)
    {
        return cam.ScreenToWorldPoint(Input.GetTouch(FingerIndex).position);
    }
}
