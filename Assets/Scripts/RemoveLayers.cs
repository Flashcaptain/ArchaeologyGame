using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveLayers : MonoBehaviour
{
    [SerializeField]
    private Tools _equippedTools;

    [SerializeField]
    private List<int> _toolDamage;

    public void SelectTool(int tool)
    {
        _equippedTools = (Tools)tool;
    }

    private void Update()
    {

        if ((Input.GetMouseButtonDown(0) || Input.touchCount > 0))
        {
            //RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.zero);
            Vector3 _touchPos = TouchManager.Instance.GetTouchPosition();
            RaycastHit2D hit = Physics2D.Raycast(_touchPos, Vector2.zero);
            if (hit.collider == null)
            {
                return;
            }

            if (_equippedTools == Tools.Shovel && (Input.GetMouseButtonDown(0) || Input.GetTouch(0).phase == TouchPhase.Began))
            {
                Debug.Log("Shovel");
            }
            else if (_equippedTools == Tools.Brush && (Input.GetMouseButton(0) || Input.GetTouch(0).phase == TouchPhase.Moved))
            {
                Debug.Log("Brush");
            }
            else if (_equippedTools == Tools.Trowel && (Input.GetMouseButton(0) || Input.GetTouch(0).phase == TouchPhase.Moved))
            {
                Debug.Log("Trowel");
            }
            else return;
            RemoveLayer(hit, _toolDamage[(int)_equippedTools]);
            Debug.Log("RemoveLayer");
        }
    }

    private void RemoveLayer(RaycastHit2D hit, int damage)
    {
        Breakable breakable = hit.collider.gameObject.GetComponent<Breakable>();

        if (breakable != null)
        {
            Debug.Log("hit breakable");
            breakable.RemoveDurability(damage , _equippedTools);
        }
    }
}
