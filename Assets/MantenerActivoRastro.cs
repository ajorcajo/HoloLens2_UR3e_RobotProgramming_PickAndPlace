using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MantenerActivoRastro : MonoBehaviour
{

    public static TrailRenderer trail;
    // Start is called before the first frame update
    void Start()
    {
        trail = GetComponent<TrailRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (trail != null)
        {
            trail.enabled = true;
        }
    }
}
