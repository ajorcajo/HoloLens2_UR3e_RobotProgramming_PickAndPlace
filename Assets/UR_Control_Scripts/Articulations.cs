using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Articulations : MonoBehaviour
{

    public Transform[] joints; // Array de 6 elementos que representa los 6 enlaces del UR3

    // Angulos de las articulaciones
    private float[] jointAngles = new float[6];

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        UpdateJointTransforms();

    }

    void UpdateJointTransforms()
    {
        // Aplicar las rotaciones a cada enlace
        for (int i = 0; i < joints.Length; i++)
        {
            if (joints[i] != null)
            {
                joints[i].localRotation = Quaternion.Euler(0, jointAngles[i], 0);
            }
        }
    }
}
