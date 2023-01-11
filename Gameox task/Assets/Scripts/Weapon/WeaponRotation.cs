using UnityEngine;
using UnityEngine.EventSystems;

public class WeaponRotation : MonoBehaviour
{


    // Update is called once per frame
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 pos = Input.mousePosition;
            Vector3 newpos = Camera.main.ScreenToWorldPoint(pos);
            newpos.z = 0;

            transform.rotation = Quaternion.LookRotation(Vector3.forward, newpos - transform.position);
        }

    }

    bool IsMouseOverUI() { return EventSystem.current.IsPointerOverGameObject(); }

}
