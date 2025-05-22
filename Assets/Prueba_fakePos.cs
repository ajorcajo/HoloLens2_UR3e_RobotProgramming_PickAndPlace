using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prueba_fakePos : MonoBehaviour
{
    // Referencia al objeto desde el cual queremos copiar las coordenadas
    public GameObject sourceObject;
    public Vector3 fake_pos;
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
        transform.position = sourceObject.transform.position;

        // Copiar la rotación del objeto de origen a este objeto
        transform.rotation = sourceObject.transform.rotation;

        fake_pos = transform.position;

        if(bandera == true)
        {
            vectorSamples.Add(fake_pos);
        }


    }
}
