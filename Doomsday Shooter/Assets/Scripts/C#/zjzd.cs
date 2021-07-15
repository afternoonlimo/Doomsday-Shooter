using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class zjzd : MonoBehaviour
{

    private GameObject boomPrefab;
    Slider slider;
    public float movespeed;
    GameObject player;
    GameObject slider1;
    public GameObject jinbi;
    private GameObject jinbi1;
    private Animator animator;
    private float camerawidth;
    private float limitxz;
    private float limitxy;

    void Start()
    {

        player = GameObject.Find("zj");
        animator = player.GetComponent<Animator>();
        boomPrefab = Resources.Load<GameObject>("boom");
        camerawidth = Camera.main.orthographicSize * Camera.main.aspect;
        limitXz();
        limitXy();
    }
    void Update()
    {
       
        transform.Translate(Vector3.right * movespeed * Time.deltaTime);
        Destroy(gameObject,5);
        if(this.transform.position.x< limitxz|| this.transform.position.x > limitxy)
        {
            Destroy(gameObject);
        }
       
    }
    void FixedUpdate()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
       
        if (collision.gameObject.tag == "gw")
        {
            Destroy(gameObject);
            foreach (Transform t in collision.gameObject.GetComponentsInChildren<Transform>())
            {
                if (t.name == "gwSlider")
                {
                    slider = t.GetComponent<Slider>();
                    slider.value = slider.value - 0.35f;
                    if (slider.value <= 0.1f)
                    {
                       Instantiate(boomPrefab,new Vector3(collision.gameObject.transform.position.x, collision.gameObject.transform.position.y - 1.5f, collision.gameObject.transform.position.z), Quaternion.identity);
                        if (boomPrefab.GetComponent<ParticleSystem>().isStopped)
                        {
                            jinbi1 = Instantiate(jinbi,new Vector3( collision.gameObject.transform.position.x, collision.gameObject.transform.position.y-0.5f, collision.gameObject.transform.position.z), Quaternion.identity);
                            int w = Random.Range(1, 10);
                            Debug.Log(w);
                            if (w > 5)
                            {
                                collision.gameObject.transform.position = new Vector3(Random.Range(-15f, -3f), transform.position.y, transform.position.z);
                            }
                            else
                            {
                                collision.gameObject.transform.position = new Vector3(Random.Range(60f, 100f), transform.position.y, transform.position.z);
                            }
                            slider.value = 1f;

                        }
                        Destroy(jinbi1, 5);

                    }
                }
            }
        }
        if (collision.gameObject.tag == "gw1")
        {
            Destroy(gameObject);
            foreach (Transform t in collision.gameObject.GetComponentsInChildren<Transform>())
            {
                if (t.name == "gw1Slider")
                {
                    slider = t.GetComponent<Slider>();
                    slider.value = slider.value - 0.35f;
                    if (slider.value <= 0.1f)
                    {
                        Instantiate(boomPrefab, new Vector3(collision.gameObject.transform.position.x, collision.gameObject.transform.position.y - 1.5f, collision.gameObject.transform.position.z), Quaternion.identity);
  
                        if (boomPrefab.GetComponent<ParticleSystem>().isStopped)
                        {
                            jinbi1 = Instantiate(jinbi, new Vector3(collision.gameObject.transform.position.x, collision.gameObject.transform.position.y - 0.5f, collision.gameObject.transform.position.z), Quaternion.identity);
                            int w = Random.Range(1, 10);
                            Debug.Log(w);
                            if (w > 5)
                            {
                                collision.gameObject.transform.position = new Vector3(Random.Range(-15f, -3f), transform.position.y, transform.position.z);
                            }
                            else
                            {
                                collision.gameObject.transform.position = new Vector3(Random.Range(60f, 100f), transform.position.y, transform.position.z);
                            }
                            slider.value = 1f;

                        }
                        Destroy(jinbi1, 5);



                    }
                }
            }
        }

    }
   
    public void stopcontrol()
    {
        this.enabled = false;
    }
    IEnumerator wait()
    {
        
        yield return new WaitForSeconds(3f);
    }
    void limitXz()
    {
        limitxz = Camera.main.transform.position.x - camerawidth;
    }
    void limitXy()
    {
        limitxy = Camera.main.transform.position.x + camerawidth;
    }
  

}
