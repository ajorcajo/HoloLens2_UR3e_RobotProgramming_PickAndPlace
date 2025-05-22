using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class prueba_transform : MonoBehaviour
{
    // Referencia al objeto desde el cual queremos copiar las coordenadas
    public GameObject sourceObject;
    public Vector3 fake_pos;
    public Vector3 real_pos;
    public Vector3 converted1_pos;
    public Vector3 converted2_pos;
    public Vector3 error;
    public Vector3 converted_error;

    public Vector3 real_rot = new Vector3();

    public bool bandera;
    public bool bandera_cogervalor;

    public List<Vector3> vectorSamples = new List<Vector3>();
    public Vector3 averageVector;


    void Start()
    {
        fake_pos = new Vector3();
        real_pos = new Vector3();
        converted1_pos = new Vector3();
        converted2_pos = new Vector3();
        error = new Vector3();
        converted_error = new Vector3();
        averageVector = new Vector3();
        bandera = true;
    }

    void Update()
    {
        fake_pos.x = transform.localPosition.z;
        fake_pos.y = - transform.localPosition.x;
        fake_pos.z = transform.localPosition.y;

        converted1_pos.x = (float)( fake_pos.x * 1.010741 - 0.001423 );
        converted1_pos.y = (float)( fake_pos.y * 1.0116 - 0.001365 );
        converted1_pos.z = (float)( fake_pos.z * 1.006162 - 0.002387 );

        converted1_pos.x = (float)(fake_pos.x * 1.010741 - 0.001423);
        converted1_pos.y = (float)(fake_pos.y * 1.0116 - 0.001365);
        converted1_pos.z = (float)(fake_pos.z * 1.006162 - 0.002387);


        real_pos.x = (float)ur_data_processing.UR_Stream_Data.C_Position[0];
        real_pos.y = (float)ur_data_processing.UR_Stream_Data.C_Position[1];
        real_pos.z = (float)ur_data_processing.UR_Stream_Data.C_Position[2];

        real_rot.x = (float)ur_data_processing.UR_Stream_Data.C_Orientation[0];
        real_rot.y = (float)ur_data_processing.UR_Stream_Data.C_Orientation[1];
        real_rot.z = (float)ur_data_processing.UR_Stream_Data.C_Orientation[2];


        if (bandera == true)
        {
            // Copiar la posición del objeto de origen a este objeto
            transform.position = sourceObject.transform.position;

            // Copiar la rotación del objeto de origen a este objeto
            transform.rotation = sourceObject.transform.rotation;

            error.x = Math.Abs(fake_pos.x - (float) ur_data_processing.UR_Stream_Data.C_Position[0]);
            error.y = Math.Abs(fake_pos.y - (float) ur_data_processing.UR_Stream_Data.C_Position[1]);
            error.z = Math.Abs(fake_pos.z - (float) ur_data_processing.UR_Stream_Data.C_Position[2]);

            converted_error.x = Math.Abs(converted1_pos.x - (float)ur_data_processing.UR_Stream_Data.C_Position[0]);
            converted_error.y = Math.Abs(converted1_pos.y - (float)ur_data_processing.UR_Stream_Data.C_Position[1]);
            converted_error.z = Math.Abs(converted1_pos.z - (float)ur_data_processing.UR_Stream_Data.C_Position[2]);

            // Si quieres copiar solo la posición y no la rotación, comenta la línea de rotación
            // Si quieres ajustar las coordenadas o realizar alguna transformación, puedes hacerlo aquí
        }

        if(bandera_cogervalor == true){
            vectorSamples.Add(fake_pos);
            // Imprimir la media de los valores tomados hasta ahora
            averageVector = CalculateAverageVector3(vectorSamples);
            bandera_cogervalor = false;

        }
    }

    private Vector3 CalculateAverageVector3(List<Vector3> vectors)
    {
        Vector3 sum = Vector3.zero;
        foreach (Vector3 vec in vectors)
        {
            sum += vec;
        }
        return sum / vectors.Count;
    }

}
