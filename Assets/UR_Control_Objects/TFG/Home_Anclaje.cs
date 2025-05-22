using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Home_Anclaje : MonoBehaviour
{
    public GameObject yo;
    public GameObject ejes;
    public GameObject impresora;
    public GameObject ui_impresora;
    public GameObject chevron;

    public void inicio()
    {
        ejes.SetActive(true);
        impresora.SetActive(false);
        ui_impresora.SetActive(true);
        chevron.SetActive(false);
        yo.SetActive(false);

    }
}
