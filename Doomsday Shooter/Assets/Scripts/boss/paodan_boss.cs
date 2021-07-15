using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class paodan_boss : MonoBehaviour
{

    // Start is called before the first frame update
    public Slider slider;
    int c = 0;
    private float firerate = 5.0f;
    private float nextfire;
    private GameObject swtxPrefab;
    private CameraConctol cameraCon;
    private GameObject hurtAnim;

    private GameObject Audio_tx;

    public float MoveSpeed = 20;

    void Start()
    {
        if (GameController.dead_ == false)
        {
            slider = GameObject.Find("SliderLifebar").GetComponent<Slider>();
            cameraCon = GameObject.Find("Main Camera").GetComponent<CameraConctol>();
            swtxPrefab = Resources.Load<GameObject>("swtx");
            hurtAnim = GameObject.Find("zj").transform.Find("hurt").gameObject;

            Audio_tx = Resources.Load<GameObject>("Particle System");
        }
        Destroy(gameObject, 10);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left * Time.deltaTime * MoveSpeed, Space.Self);

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.tag)
        {
            case "zj":
     
                if (c== 1)
                {         
                    slider.value = slider.value;
               
                    if (slider.value <=0.4f)
                    {
                        cameraCon.isHurt = false;
                    }
                }
                else if(c==0)
                {
                    slider.value = slider.value - 0.2f;

                    Instantiate(Audio_tx, collision.gameObject.transform.position, Quaternion.identity);
                }

                if (slider.value < 0.2)
                {
                
                    Instantiate(swtxPrefab, collision.gameObject.transform.position, Quaternion.identity);
                    collision.gameObject.SetActive(false);

                    GameController.dead_ = true;
                }

                if (slider.value <= 0.4f)
                {

                    hurtAnim.SetActive(true);
                    cameraCon.isHurt = true;

                }
                Destroy(gameObject);

                break;
        }
    }

    public void stopcontrol()
    {
        this.enabled = false;
    }
      
}
