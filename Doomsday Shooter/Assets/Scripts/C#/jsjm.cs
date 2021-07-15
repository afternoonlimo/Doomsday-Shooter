using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class jsjm : MonoBehaviour
{



    public Slider slider;

    public Text text;
    static int gs;
    public GameObject player;

    void Start()
    {

        slider = this.GetComponent<Slider>();

    }

    void Update()
    {
            gs = int.Parse(text.text);
    }

    public int jbsl()
    {
        return gs;
    }
    
}
