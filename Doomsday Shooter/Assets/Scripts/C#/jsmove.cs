using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class jsmove : MonoBehaviour
{



    /// <summary>
    /// 人物移动
    /// </summary>

    public GameObject zltx;
    private Rigidbody2D m_rigid;
    private Transform transform;
    private float horizontal = 0;
    private float move = 0;
    public float jumpforce = 300;
    public float movespeed /*= 20*/;
    private Animator animator;
    private bool isdiban = false;
    private bool a = false;
    private float camerawidth;
    private float limitxz;
    private float limitxy;
    private BoxCollider2D jc;

    public static int c;

    bool kg=false;
    public float sumtime;//无敌的时间
    //public GameObject timelabel;
    public GameObject shijian;
    public Slider sj;


    public Text text;//金币数量文本

    public AudioSource coinCollectSound; //收集金币的声音
    public AudioSource WudiCollectSound; //收集无敌道具的声音
    public GameObject Boss;//大Boss
    public GameObject Guaiwu_;//怪物生成

    void Start()
    {
        m_rigid = GetComponent<Rigidbody2D>();
        transform = gameObject.GetComponent<Transform>();
        animator = gameObject.GetComponent<Animator>();
        jc = GetComponent<BoxCollider2D>();
        camerawidth = Camera.main.orthographicSize*Camera.main.aspect-jc.bounds.size.x*0.5f;
        c = 0;
    
        shijian.SetActive(false);
    }

    void Update()
    {
  
        if (Input.GetKeyUp(KeyCode.W)&&a)
        {

            a = false;

            if (m_rigid.position.y > 12)
            {          
                m_rigid.AddForce(new Vector3(0, jumpforce, 0));
                animator.SetBool("isjump", true);

                zltx.SetActive(false);
            }
            if (m_rigid.position.y > 4 && m_rigid.position.y < 12)
            {
                m_rigid.AddForce(new Vector3(0, jumpforce, 0));
                m_rigid.MovePosition(new Vector3(m_rigid.position.x, 13f));
            }

            if (m_rigid.position.y > -10 && m_rigid.position.y < 4)
            {
                m_rigid.AddForce(new Vector3(0, jumpforce, 0));
                m_rigid.MovePosition(new Vector3(m_rigid.position.x, 5f));
            }
        }

        if (Input.GetKeyUp(KeyCode.S))
        {
           // animator.SetBool("isjump", true);
            if (m_rigid.position.y > 12)
            {
                m_rigid.AddForce(new Vector3(0, -jumpforce, 0));
                transform.position = new Vector3(transform.position.x, 6f, transform.position.z);
                m_rigid.MovePosition(transform.position + Vector3.down);
            }
            if (m_rigid.position.y > 4 && m_rigid.position.y < 12)
            {
                m_rigid.AddForce(new Vector3(0, -jumpforce, 0));
                transform.position = new Vector3(transform.position.x, -2f, transform.position.z);
                m_rigid.MovePosition(transform.position + Vector3.down);
            }
        }

        horizontal = Input.GetAxis("Horizontal");
        move = horizontal * movespeed;
        if (move > 0)
        {
            //this.transform.localScale = new Vector3(Mathf.Abs(this.transform.localScale.x),
            //    this.transform.localScale.y,
            //    this.transform.localScale.z);
            animator.SetBool("yy", true);
            animator.SetBool("zy", false);
            animator.SetBool("zyy", true);
            animator.SetBool("zzy", false);
            this.transform.rotation = Quaternion.Euler(0, 0, 0);

        }
        else if (move < 0)
        {
            //this.transform.localScale = new Vector3(-Mathf.Abs(this.transform.localScale.x),
            //    this.transform.localScale.y,
            //    this.transform.localScale.z);
            this.transform.rotation = Quaternion.Euler(0, 180, 0);
            animator.SetBool("zy", true);
            animator.SetBool("yy", false);
            animator.SetBool("zzy", true);
            animator.SetBool("zyy", false);
        }

        limitXz();
        limitXy();

        if ((m_rigid.transform.position.x<limitxz&&move<0)|| (m_rigid.transform.position.x > limitxy && move > 0))
        {
            m_rigid.velocity = new Vector3(0, m_rigid.velocity.y);
        }
        else
        {
            m_rigid.velocity = new Vector3(move, m_rigid.velocity.y);
        }
        
        animator.SetFloat("movespeed", Mathf.Abs(move));

    }


    void limitXz()
    {
        limitxz = Camera.main.transform.position.x - camerawidth;
    }
    void limitXy()
    {
        limitxy = Camera.main.transform.position.x + camerawidth;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "diban")
        {
            animator.SetBool("isjump", false);
            a = true;

            zltx.SetActive(true);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        /// <summary>
        /// 碰撞到无敌
        /// </summary>
        if (collision.gameObject.tag == "dj")
        {
            WudiCollectSound.Play();//播放无敌道具获得声音
            kg = true;

            shijian.SetActive(true);
            StartCoroutine("startcountdown");
            c = 1;
            Destroy(collision.gameObject);
      
        }
        /// <summary>
        /// 碰撞到大金币
        /// </summary>
        if (collision.gameObject.tag == "djjb")
        {
            coinCollectSound.Play();//播放金币获得声音
            GameController.sl = int.Parse(text.text);
            GameController.sl += 10;
            text.text = GameController.sl.ToString();//金币文本显示

            Destroy(collision.gameObject);


            //当关卡为关卡一，且获得金币大于等于15时，跳转到成功结算页面
            if (SelectGameManager.LevelNum == 0 && GameController.sl == 15)
            {
                Guaiwu_.SetActive(false);//关闭怪物生成器
                Boss.SetActive(true);//显示Boss
            }

            //当关卡为关卡二，且获得金币大于等于15时，跳转到成功结算页面
            if (SelectGameManager.LevelNum == 1 && GameController.sl == 15)
            {
                Guaiwu_.SetActive(false);//关闭怪物生成器
                Boss.SetActive(true);//显示Boss
            }

            //当关卡为关卡三，且获得金币大于等于15时，跳转到成功结算页面
            if (SelectGameManager.LevelNum == 2 && GameController.sl == 15)
            {
                Guaiwu_.SetActive(false);//关闭怪物生成器
                Boss.SetActive(true);//显示Boss
            }
        }

        /// <summary>
        /// 碰撞金币
        /// </summary>
        if (collision.gameObject.tag == "jinbi")
        {
            coinCollectSound.Play();//播放金币获得声音
            GameController.sl = int.Parse(text.text);
            GameController.sl += 1;
            text.text = GameController.sl.ToString();
            Destroy(collision.gameObject);

            //当关卡为关卡一，且获得金币大于等于15时，跳转到成功结算页面
            if (SelectGameManager.LevelNum == 0 && GameController.sl == 15)
            {
                Guaiwu_.SetActive(false);//关闭怪物生成器
                Boss.SetActive(true);//显示Boss
            }
            //当关卡为关卡二，且获得金币大于等于15时，跳转到成功结算页面
            if (SelectGameManager.LevelNum == 1 && GameController.sl == 15)
            {
                Guaiwu_.SetActive(false);//关闭怪物生成器
                Boss.SetActive(true);//显示Boss
            }
            //当关卡为关卡三，且获得金币大于等于15时，跳转到成功结算页面
            if (SelectGameManager.LevelNum == 2 && GameController.sl == 15)
            {
                Guaiwu_.SetActive(false);//关闭怪物生成器
                Boss.SetActive(true);//显示Boss
            }
        }

    }
    public void stopcontrol()
    {
        this.enabled = false;
    }
    public IEnumerator startcountdown()
    {   
            while (sumtime >= 0)
            {
            sj.GetComponent<Slider>().value = sumtime;
                //timelabel.GetComponent<Text>().text = "Time:" + sumtime;
                sumtime--;
                
                if (sumtime <= 0)
                {
                c = 0;
                // timelabel.SetActive(false);
                shijian.SetActive(false);
                yield break;
                }
            yield return new WaitForSeconds(1);
             
            }
        }
    public int sfydj()
    {
        return c;
    }

}




