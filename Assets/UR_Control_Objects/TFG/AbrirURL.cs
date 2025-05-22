using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbrirURL : MonoBehaviour
{
    public string url;

    // Start is called before the first frame update
    public void Abre_url()
    {
        Application.OpenURL(url);
    }
}
