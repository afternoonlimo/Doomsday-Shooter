using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class zjgj : MonoBehaviour
{

    public GameObject zdwz;
    public GameObject goBullet;
    private GameObject bullet;
    public Text text;
    private Animator animator;
    int b = 0;
    private AudioSource source;
    private GameObject khtxPrefab;

    void Start()
    {

        animator = GetComponent<Animator>();
        source = GetComponent<AudioSource>();
        khtxPrefab = Resources.Load<GameObject>("khtx");

    }

   
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && animator.GetBool("yy"))

        {
           Instantiate(khtxPrefab, new Vector3( zdwz.transform.position.x+0.5f, zdwz.transform.position.y, zdwz.transform.position.z), Quaternion.identity);
            bullet = Instantiate(goBullet, zdwz.transform.position, Quaternion.identity);
            source.Play();

        }
        if (Input.GetButtonDown("Fire1") && animator.GetBool("zy"))
        {
            Instantiate(khtxPrefab, new Vector3(zdwz.transform.position.x - 0.5f, zdwz.transform.position.y, zdwz.transform.position.z), Quaternion.identity);
            bullet = Instantiate(goBullet, zdwz.transform.position, Quaternion.Euler(0,0,180));
            source.Play();

        }     
    }

    public void stopcontrol()
    {
        this.enabled = false;
    }

}
