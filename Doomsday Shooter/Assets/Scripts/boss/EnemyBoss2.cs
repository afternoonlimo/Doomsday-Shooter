using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EnemyBoss2 : MonoBehaviour
{


    public int m_life = 500;          
    public Slider HP_Enemy;           
    public GameObject Slider_HP_Enemy;
    public int BeAttack = 50;         

    public GameObject BoltParticleSystem;
    public AudioSource Enemy_audioSource;


    public float EnemySpeed = 30;
  
    public Vector2 Vec_Enemy;

    public int Enemy_Can_Move_num = 0;


    public Vector2 Vec_01;
    public Vector2 Vec_02;
    public Vector2 Vec_03;
    public Vector2 Vec_04;
    public Vector2 Vec_05;
    public Vector2 Vec_06;

    public Vector2 Vec_Next;

    public Slider slider;
    int c = 0;
    private CameraConctol cameraCon;
    private GameObject swtxPrefab;
    private GameObject hurtAnim;

    public bool hurt = false;   
    public float hurt_num = 3;  
    public GameObject player;   

    public GameObject LaserBoss03;

    void Start()
    {
        Vec_Enemy = this.transform.position;
  
        Vec_Next = transform.position;

        slider = GameObject.Find("SliderLifebar").GetComponent<Slider>();
        cameraCon = GameObject.Find("Main Camera").GetComponent<CameraConctol>();
        swtxPrefab = Resources.Load<GameObject>("swtx");
        hurtAnim = GameObject.Find("zj").transform.Find("hurt").gameObject;
    }

    void Update()
    {

        Enemy_AI();


        if (hurt == true)
        {
            hurt_num -= Time.deltaTime;
            if (hurt_num<0)
            {
                hurt = false;
                hurt_num = 3;
            }
        }

    }

    void Enemy_AI()
    {
 
        float dis_r = Vector2.Distance(transform.position, Vec_Next);
        if (dis_r > 1)
        {
      
            transform.position = Vector2.MoveTowards(transform.position, Vec_Next, EnemySpeed * Time.deltaTime);
        }
        else
        {
            GameObject LaserBoss3 = GameObject.Instantiate(LaserBoss03, this.gameObject.transform.position, Quaternion.identity) as GameObject;

         
            int n = Random.Range(0, 6);
            if (n == 0)
            {
                Vec_Next = Vec_01;
            }
            if (n == 1)
            {
                Vec_Next = Vec_02;
            }
            if (n == 2)
            {
                Vec_Next = Vec_03;
            }
            if (n == 3)
            {
                Vec_Next = Vec_04;
            }
            if (n == 4)
            {
                Vec_Next = Vec_05;
            }
            if (n == 5)
            {
                Vec_Next = Vec_06;
            }
        }

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "heroBullet")
        {
            Destroy(collision.gameObject);
            OnDamage(BeAttack);
        }

        if (collision.tag == "zj")
        {
            if (hurt == false)
            {
                hurt = true;

   
                if (c == 1)
                {
                    slider.value = slider.value;
               
                    if (slider.value <= 0.4f)
                    {
                 
                        cameraCon.isHurt = false;
                    }
                }
                else if (c == 0)
                {
                    slider.value = slider.value - 0.2f;
            
                }

                if (slider.value < 0.2)
                {
                
                    Instantiate(swtxPrefab, collision.gameObject.transform.position, Quaternion.identity);
                    collision.gameObject.SetActive(false);
                }

                if (slider.value <= 0.4f)
                {

                    hurtAnim.SetActive(true);
                    cameraCon.isHurt = true;

                }
          
            }              
        }
    }

    public void OnDamage(int damage)
    {
        m_life -= damage;
        HP_Enemy.value = m_life;

        if (m_life <= 0)
        {
            Enemy_audioSource.Play();
            Instantiate(BoltParticleSystem, this.transform.position, this.transform.rotation);
            Slider_HP_Enemy.SetActive(false);

            SelectGameManager.LevelNum = 3;
            GameController.win_ = true;
            player.SetActive(false);

       
            Destroy(this.gameObject);
        }
    }

    void GameWin()
    {
        Debug.Log(999000);
    }
}
