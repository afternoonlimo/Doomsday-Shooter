using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class djyd : MonoBehaviour
{

    public int speed;
    private float camerawidth;
    private float limitxz;

    void Start()
    {
        camerawidth = Camera.main.orthographicSize * Camera.main.aspect;
        limitXz();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left * Time.deltaTime * speed);
    
        if(transform.position.x<limitxz)
        {
            Destroy(gameObject);
        }
    }
    void limitXz()
    {
        limitxz = Camera.main.transform.position.x - camerawidth;
    }
}
