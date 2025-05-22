using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prueba_realPos : MonoBehaviour
{
    public Vector3 real_pos;
    public List<Vector3> vectorSamples = new List<Vector3>();
    public bool bandera;

    // Start is called before the first frame update
    void Start()
    {
        real_pos = new Vector3();
    }

    // Update is called once per frame
    void Update()
    {
        real_pos.x = (float)ur_data_processing.UR_Stream_Data.C_Position[0];
        real_pos.y = (float)ur_data_processing.UR_Stream_Data.C_Position[1];
        real_pos.z = -(float)ur_data_processing.UR_Stream_Data.C_Position[2];


        transform.localPosition = real_pos;

        if (bandera == true)
        {
            vectorSamples.Add(real_pos);
        }
    }
}
