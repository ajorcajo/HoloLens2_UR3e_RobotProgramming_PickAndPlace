using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Reinicio_Escena : MonoBehaviour
{
    public void Reiniciar()
    {
        SceneManager.LoadScene("PruebaUR");
    }
}
