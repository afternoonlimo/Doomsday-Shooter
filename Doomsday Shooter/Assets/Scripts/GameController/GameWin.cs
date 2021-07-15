using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameWin : MonoBehaviour
{


    public Button GameBackButton;     
    public Button GameQuitButton;   

    void Start()
    {
        GameBackButton.onClick.AddListener(GameBackButtonListener);       
        GameQuitButton.onClick.AddListener(GameQuitButtonClickListener);   
    }

    void GameBackButtonListener()
    {
        SceneManager.LoadScene(2);
    }

    void GameQuitButtonClickListener()
    {

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
      Application.Quit();
#endif
    }
}
