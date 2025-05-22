using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prueba_convertedPos : MonoBehaviour
{
    // Referencia al objeto desde el cual queremos copiar las coordenadas
    public GameObject sourceObject;
    public Vector3 fake_pos;
    public Vector3 converted_pos;
    public List<Vector3> vectorSamples = new List<Vector3>();
    public bool bandera;

    // Start is called before the first frame update
    void Start()
    {
        fake_pos = new Vector3();
    }

    // Update is called once per frame
    void Update()
    {
        // Copiar la posición del objeto de origen a este objeto
        fake_pos = sourceObject.transform.localPosition;

        // Copiar la rotación del objeto de origen a este objeto
        transform.rotation = sourceObject.transform.rotation;
        /*
        fake_pos.x = transform.localPosition.z;
        fake_pos.y = -transform.localPosition.x;
        fake_pos.z = transform.localPosition.y;
        */
        converted_pos.x = (float)(fake_pos.x * 1.0116 - 0.001365);
        converted_pos.y = (float)(fake_pos.y * 1.006162 - 0.002387);
        converted_pos.z = (float)(fake_pos.z * 1.010741 - 0.001423);


        /*
        converted_pos.x = (float)(fake_pos.x * 1.010741 - 0.001423);
        converted_pos.y = (float)(fake_pos.y * 1.0116 - 0.001365);
        converted_pos.z = (float)(fake_pos.z * 1.006162 - 0.002387);
        */

        transform.localPosition = converted_pos ;

        if (bandera == true)
        {
            vectorSamples.Add(fake_pos);
        }

    }
}
