using System;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class Link5 : MonoBehaviour
{
    void FixedUpdate()
    {
        try
        {
            transform.localEulerAngles = new Vector3(0.0f, 180.0f + (float)(ur_data_processing.UR_Stream_Data.J_Orientation[4] * (180.0 / Math.PI)), -90.0f);
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
