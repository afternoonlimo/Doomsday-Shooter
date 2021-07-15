using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SelectGameManager : MonoBehaviour {
    


    public GameObject lv1;
    public GameObject lv2;
    public GameObject lv3;
    public GameObject lv1no;
    public GameObject lv2no;
    public GameObject lv3no;

    public Button ReturnButton;

    public static int LevelNum = 0;    

    void Start () {

        ReturnButton.onClick.AddListener(ReturnButtonClickListener);   

        if (LevelNum==0)
        {
            lv1.SetActive(true);
            lv2.SetActive(false);
            lv3.SetActive(false);
            lv1no.SetActive(false);
            lv2no.SetActive(true);
            lv3no.SetActive(true);
        }
        else if (LevelNum == 1)
        {
            lv1.SetActive(true);
            lv2.SetActive(true);
            lv3.SetActive(false);
            lv1no.SetActive(false);
            lv2no.SetActive(false);
            lv3no.SetActive(true);
        }
        else if (LevelNum >= 2)
        {
            lv1.SetActive(true);
            lv2.SetActive(true);
            lv3.SetActive(true);
            lv1no.SetActive(false);
            lv2no.SetActive(false);
            lv3no.SetActive(false);
        }

    }
	

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    void ReturnButtonClickListener()
    {
        SceneManager.LoadScene(0);
    }
}
