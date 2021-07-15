using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class loadgame : MonoBehaviour
{


    AsyncOperation async;
    public Text text;
    public float num = 0;
    public Image load;
    public Slider slider;

    // Start is called before the first frame update
    void Start()
    {

        slider = GameObject.Find("Slider").GetComponent<Slider>();
        StartCoroutine(Loadgame());

    }
    IEnumerator Loadgame()
    {
        async = SceneManager.LoadSceneAsync("LevelSelect");
        async.allowSceneActivation = false;
        yield return async;
    }

    // Update is called once per frame
    void Update()
    {
        if (async == null)
        {
            return;
        }
        int shu = 0;
        if (async.progress < 0.9f)
        {
            shu = (int)async.progress * 100;
        }
        else
        {
            shu = 100;
        }
        if (num < shu)
        {
            num = num + 0.2f;
            load.fillAmount = num / 100f;
            text.text = num.ToString("0") + "%";
            slider.value = num / 100;
        }
        StartCoroutine(Wait());
       
        if (num >= 100)
        {
            StartCoroutine(Loadgame1());        
        }

        IEnumerator Loadgame1()
        {
            yield return new WaitForSeconds(1);
            async.allowSceneActivation = true;
        }
        IEnumerator Wait()
        {
            yield return new WaitForSeconds(2);
            //async.allowSceneActivation = true;
        }

    }
}
