using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraConctol : MonoBehaviour
{


    private Vector3 Pos = Vector3.zero;
    public bool isHurt = false;
    float time = 0;

    void Update()
    {
        if (isHurt)
        {
            time += Time.deltaTime;
            if (time <= 0.5f)
            {
                Show();
            }
            if(time>0.5f)
            {
                isHurt = false;
                time = 0;
            }
        }

    }

    public void Show()
    {
        transform.localPosition -= Pos;
        Pos = Random.insideUnitSphere / 3.0f;
        transform.localPosition += Pos;
    }

 }
    
