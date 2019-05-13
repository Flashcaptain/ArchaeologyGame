using UnityEngine;
using System.Collections;

public class ExampleTouchManagerUse : MonoBehaviour
{
    void Update()
    {
        //Option 1
        Vector3 pos = TouchManager.Instance.GetTouchPosition();
        if (pos != Vector3.zero)
        {
            transform.position = pos;
        }

        //Option 2
        if (Input.touchCount > 0 )
        {            
            transform.position = TouchManager.Instance.GetTouchPosition();
        }
    }
}