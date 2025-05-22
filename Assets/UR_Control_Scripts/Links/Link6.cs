using System;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class Link6 : MonoBehaviour
{
    void FixedUpdate()
    {
        try
        {
            transform.localEulerAngles = new Vector3(-90.0f, 0.0f, 90.0f +(float)(ur_data_processing.UR_Stream_Data.J_Orientation[5] * (180.0 / Math.PI)));
        }
        catch (Exception e)
        {
            Debug.Log("Exception:" + e);
        }
    }
    void OnApplicationQuit()
    {
        Destroy(this);
    }
}
