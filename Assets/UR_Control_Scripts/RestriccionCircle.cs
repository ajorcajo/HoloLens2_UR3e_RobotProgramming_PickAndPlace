using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestriccionCircle : MonoBehaviour
{
    public float radius = 0.5f; // Radio de la circunferencia
    public GameObject origin; // Objeto que define el centro de la circunferencia

    void Update()
    {
        // Obtén la posición del centro de la circunferencia
        Vector3 center = origin.transform.position;

        // Calcula la posición de la esfera respecto al centro de la circunferencia
        Vector3 offset = transform.position - center;

        // Calcula el ángulo actual de la esfera en la circunferencia
        float angle = Mathf.Atan2(offset.z, offset.x);

        // Calcula la nueva posición en la circunferencia manteniendo el radio constante
        float newX = center.x + radius * Mathf.Cos(angle);
        float newZ = center.z + radius * Mathf.Sin(angle);

        // Actualiza la posición de la esfera
        transform.position = new Vector3(newX, transform.position.y, newZ);
    }
}
