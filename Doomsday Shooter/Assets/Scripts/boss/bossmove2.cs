
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class bossmove2 : MonoBehaviour
{ 

enum MonsterState
    {
        PATROL,
        CHASING,
        ATTACK,
        DIE,
    };
    private Transform[] target;
    int target0 = 0;
    private Transform[] target1;
    int target00= 0;
    private MonsterState monsterstate;
    public GameObject slider;
    public GameObject gwzdwz;
    GameObject player;
    public float monsterspeed;
    public float speed;
   // float a;
    public GameObject paodan;
    private GameObject bullet;
    public float firerate = 2.0f;
    public float nextfire;
    private GameObject gwxlwzy1;
    private GameObject gwxlwzz1;
    public GameObject jinbi;
    private float hp;
    private float camerawidth;
    private float limitxz;
    private float limitxy;
    private bool isfirst = true;
    private bool isfirst1 = true;
    void Start()
    {
        target= new Transform[2];
        target1 = new Transform[2];
        player = GameObject.Find("zj");
        monsterstate = MonsterState.PATROL;
        slider = GameObject.Find("gwSlider");
        gwzdwz= GameObject.Find("gwzdwz");
        gwxlwzy1 = GameObject.Find("gwxlwzy1");
        gwxlwzz1 = GameObject.Find("gwxlwzz1");
        target[0] = gwxlwzz1.transform;
        target[1] = gwxlwzy1.transform;
        target1[0] = gwxlwzy1.transform;
        target1[1] = gwxlwzz1.transform;
        camerawidth = Camera.main.orthographicSize * Camera.main.aspect;
        limitXz();
        limitXy();
    }
    // Update is called once per frame
    void Update()
    {
        nextfire += Time.deltaTime;

        //slider.transform.position = xtwz.transform.position;
        float a = Mathf.Abs( Vector3.Distance(player.transform.position, this.transform.position));
      
        switch (monsterstate)
        {
            case MonsterState.PATROL:
                if (player.transform.position.y > 4 && player.transform.position.y < 12)
                {
                   
                        monsterstate = MonsterState.CHASING;
                }
                else
                {
                   
                    transform.position += Vector3.right * monsterspeed * Time.deltaTime;

                    if ((transform.position.x) > 55)
                   
                    {
                        this.transform.rotation = Quaternion.Euler(0, 180, 0);
                        monsterspeed = -monsterspeed;

                    }
                    if ((transform.position.x) < -20)
                    {
                        monsterspeed = -monsterspeed;
                        this.transform.rotation = Quaternion.Euler(0, 0, 0);
                    }

                }
                break;
            case MonsterState.CHASING:
               
                if (player.transform.position.y > 4 && player.transform.position.y < 12)
                {
                    isfirst = true;
                    isfirst1= true;
                    if (a < 20.0f)
                    {
                        Debug.Log(3333);
                        monsterstate = MonsterState.ATTACK;
                    }
                    else
                    {
                        if (player.transform.position.x > this.transform.position.x)
                        {
                            this.transform.rotation = Quaternion.Euler(0, 0, 0);
                            transform.Translate(Vector3.right * Time.deltaTime * speed);
                        }

                        else if (player.transform.position.x < this.transform.position.x)
                        {
                            this.transform.rotation = Quaternion.Euler(0, 180, 0);
                            transform.Translate(Vector3.right * Time.deltaTime * speed);
                        }
                        else
                        {
                            this.transform.position = player.transform.position;
                        }


                    }
                }
                else
                {


                    if (isfirst && player.transform.position.x < transform.position.x && monsterspeed > 0)
                    {
                        this.transform.rotation = Quaternion.Euler(0, 0, 0);
                        isfirst = false;
                    }
                    if (isfirst1 && player.transform.position.x > transform.position.x && monsterspeed < 0)
                    {
                        this.transform.rotation = Quaternion.Euler(0, 180, 0);
                        isfirst1 = false;
                    }
                    transform.position += Vector3.right * monsterspeed * Time.deltaTime;

                    if ((transform.position.x) > 55)
                  
                    {
                        this.transform.rotation = Quaternion.Euler(0, 180, 0);
                        monsterspeed = -monsterspeed;

                    }
                    if ((transform.position.x) < -20)
                    {
                        monsterspeed = -monsterspeed;
                        this.transform.rotation = Quaternion.Euler(0, 0, 0);
                    }
                }
                break;
            case MonsterState.ATTACK:
        
               
                if (player.transform.position.y > 4 && player.transform.position.y < 12)
                {
                    isfirst = true;
                    isfirst1 = true;
                    if (player.transform.position.x > this.transform.position.x)
                    {
                        this.transform.rotation = Quaternion.Euler(0, 0, 0);
                        transform.Translate(Vector3.right * Time.deltaTime * speed);
                    }

                    else if (player.transform.position.x < this.transform.position.x)
                    {
                        this.transform.rotation = Quaternion.Euler(0, 180, 0);
                        transform.Translate(Vector3.right * Time.deltaTime * speed);
                    }
                    if (a < 20.0f && this.transform.position.x > limitxz && this.transform.position.x < limitxy)
                    {
                        if (nextfire > firerate)
                        {
                            Vector3 dir = player.transform.position - this.transform.position;
                            nextfire = 0;
                     

                            bullet = Instantiate(paodan, transform.position, Quaternion.identity);
                      
                            Rigidbody2D m_rigid = bullet.GetComponent<Rigidbody2D>();
                            Vector3 fs = Vector3.Normalize(dir);
                            Debug.Log(fs.x);
                            if (fs.x > 0)
                            {
                                bullet.transform.rotation = Quaternion.Euler(0, 180, 0);
                            }
                            else
                            {
                                bullet.transform.rotation = Quaternion.Euler(0, 0, 0);
                            }
                            m_rigid.AddForce(new Vector3(1000.0f * fs.x, 0, 0));
                            if (dir == Vector3.zero)
                            {
                                Destroy(bullet);
                            }
                        }
                    }
                    else 
                    {
                        monsterstate = MonsterState.CHASING;
                        Debug.Log(6666);
                    }
                }
                else
                {
                       
                    if (isfirst&& player.transform.position.x < transform.position.x&&monsterspeed > 0)
                    {
                        this.transform.rotation = Quaternion.Euler(0, 0, 0);
                        isfirst = false;
                    }
                    if (isfirst1 && player.transform.position.x > transform.position.x && monsterspeed < 0)
                    {
                        this.transform.rotation = Quaternion.Euler(0, 180, 0);
                        isfirst1 = false;
                    }
                    transform.position += Vector3.right * monsterspeed * Time.deltaTime;

                    if ((transform.position.x) > 55)
                 
                    {
                        this.transform.rotation = Quaternion.Euler(0, 180, 0);
                        monsterspeed = -monsterspeed;

                    }
                    if ((transform.position.x) < -20)
                    {
                        monsterspeed = -monsterspeed;
                        this.transform.rotation = Quaternion.Euler(0, 0, 0);
                    }
                }
                break;    
        }

    }


    public void stopcontrol()
    {
        this.enabled = false;
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


