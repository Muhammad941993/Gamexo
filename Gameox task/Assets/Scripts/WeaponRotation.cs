using UnityEngine;
using Photon.Pun;





public class WeaponRotation : MonoBehaviourPunCallbacks
{


    // Update is called once per frame
    private void FixedUpdate()
    {
        if (!photonView.IsMine) return;

        if (!Input.GetMouseButton(0)) return;

        Vector3 pos = Input.mousePosition;
        Vector3 newpos = Camera.main.ScreenToWorldPoint(pos);
        newpos.z = 0;

        transform.rotation = Quaternion.LookRotation(Vector3.forward, newpos - transform.position);
        

    }



}
