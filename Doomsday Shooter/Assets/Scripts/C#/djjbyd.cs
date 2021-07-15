using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class djjbyd : MonoBehaviour
{

    public int speed;
    private float camerawidth;
    private float limitxy;
    
    void Start()
    {
        camerawidth = Camera.main.orthographicSize * Camera.main.aspect;
        limitXy();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * Time.deltaTime * speed);
        if (transform.position.x >limitxy)
        {
            Destroy(gameObject);
        }
    }
    void limitXy()
    {
        limitxy = Camera.main.transform.position.x + camerawidth;
    }
}
