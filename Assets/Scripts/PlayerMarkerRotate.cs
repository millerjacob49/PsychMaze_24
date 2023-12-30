using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMarkerRotate : MonoBehaviour
{
    public Transform player;
    // Start is called before the first frame update
    void LateUpdate()
    {
        //Vector3 newPosition = player.position;
        //newPosition.y = transform.position.y;
        //transform.position = newPosition;

        transform.rotation = Quaternion.Euler( 0f, 0f, -player.eulerAngles.y);
    }
}
