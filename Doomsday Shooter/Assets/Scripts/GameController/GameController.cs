using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{

    public int Lever_num = 4;

    public static bool dead_ = false;
    public Button ReturnButton_lose;
    public Button AgainButton_lose; 
    public GameObject OverPanel;

    public static bool win_ = false; 
    public Button ReturnButton_win;
    public Button NextButton_win;   
    public GameObject WinPanel;    

    public static int sl = 0;
    public Text text_lose;          
    public Text text_win;  

    public float time_end = 2;
    public GameObject Guaiwu_;

    void Start()
    {

        ReturnButton_lose.onClick.AddListener(ReturnButton_loseClickListener);   
        AgainButton_lose.onClick.AddListener(AgainButton_loseClickListener);     

        ReturnButton_win.onClick.AddListener(ReturnButton_loseClickListener);   
        NextButton_win.onClick.AddListener(NextButton_winClickListener);        

    }

    void Update()
    {

        if (dead_ == true)
        {
            Guaiwu_.SetActive(false);

            time_end -= Time.deltaTime;
            if (time_end < 0)
            {
                dead_ = false;

                OverPanel.SetActive(true);
                text_lose.text = sl.ToString();

                Time.timeScale = 0;
            }
        }

        if (win_ == true)
        {
            time_end -= Time.deltaTime;
            if (time_end<0)
            {
                win_ = false;

                WinPanel.SetActive(true);
                text_win.text = sl.ToString();

                Time.timeScale = 0;
            }     
        }
    }

    public void ReturnButton_loseClickListener()
    {
        sl = 0;
        Time.timeScale = 1;

        SceneManager.LoadScene(2);           
    }

    public void AgainButton_loseClickListener()
    {
        sl = 0;
        Time.timeScale = 1;

        SceneManager.LoadScene(Lever_num); 
    }

    public void NextButton_winClickListener()
    {
        Time.timeScale = 1;

        SceneManager.LoadScene(Lever_num+1);   
    }

}
