using System;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class Link3 : MonoBehaviour
{
    void FixedUpdate()
    {
        try
        {
            transform.localEulerAngles = new Vector3(0.0f, (float)(ur_data_processing.UR_Stream_Data.J_Orientation[2] * (180.0 / Math.PI)), 0.0f );
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
