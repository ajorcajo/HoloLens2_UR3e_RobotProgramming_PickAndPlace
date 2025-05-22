using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApareceDelante : MonoBehaviour
{
    public Transform target;

    public void ComeHere()
    {
        transform.position = new Vector3(target.position.x, (float)(target.position.y - 0.2), (float)(target.position.z + 0.6));

    }

}
