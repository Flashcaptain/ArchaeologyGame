using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawMask : MonoBehaviour
{
    private float rayDistance = 10000;

    void Update()
    {
        if ((Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved) || Input.GetMouseButton(0))
        {
            Plane objectPlane = new Plane(Camera.main.transform.forward * -1, transform.position);

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (objectPlane.Raycast(ray, out rayDistance))
            {
                transform.position = ray.GetPoint(rayDistance);
            }
        }
    }
}
