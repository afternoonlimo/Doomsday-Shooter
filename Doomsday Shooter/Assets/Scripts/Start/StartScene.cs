using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartScene : MonoBehaviour
{

    public Button StartBtn;



    // Start is called before the first frame update
    void Start()
    {
        StartBtn.onClick.AddListener(StartBtnLis);
    }

    void StartBtnLis()
    {
        SceneManager.LoadScene(1);
    }

}
