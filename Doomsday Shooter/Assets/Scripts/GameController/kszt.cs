using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kszt : MonoBehaviour
{

    int a = 0;

    public void Clickthisbutton()
    {
        a++;
        switch(a)
        {
            case 1:
                Time.timeScale = 0;
                break;
            case 2:
                Time.timeScale = 1;
                a = 0;
                break;                 
        }
    }

}
