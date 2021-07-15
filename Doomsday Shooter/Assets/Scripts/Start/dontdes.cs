using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dontdes : MonoBehaviour
{

    public static int dontdes_n =0;

    void Start()
    {
        if (dontdes_n == 0)
        {
                    DontDestroyOnLoad(this.gameObject);
                    dontdes_n = 1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
