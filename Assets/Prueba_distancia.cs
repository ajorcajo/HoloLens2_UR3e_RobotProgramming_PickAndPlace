using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prueba_distancia : MonoBehaviour
{
    public Transform objeto1;  // Referencia al primer objeto
    public Transform objeto2;  // Referencia al segundo objeto
    public float distancia;

    void Update()
    {
        // Verifica que ambos objetos estén asignados
        if (objeto1 != null && objeto2 != null)
        {
            // Calcula la distancia entre los dos objetos
            distancia = Vector3.Distance(objeto1.position, objeto2.position);

            // Muestra la distancia en consola (solo para propósitos de demostración)
            //Debug.Log("La distancia entre " + objeto1.name + " y " + objeto2.name + " es: " + distancia);
        }
        else
        {
            //Debug.LogWarning("Asegúrate de asignar los objetos en el inspector.");
        }
    }
}
