using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cjgw2 : MonoBehaviour
{

    public GameObject onemonster;

    void Start()
    {
        StartCoroutine(cjdscgw(4));
    }
    IEnumerator cjdscgw(int num)
    {
        int count = 0;
        while (count < num)
        {
            count++;
            yield return StartCoroutine(cjgw());

            yield return new WaitForSeconds(15);
          
        }
     
    }
    IEnumerator cjgw()
    {

        yield return new WaitForSeconds(10f);
        Vector3 pos = new Vector3(Random.Range(-45f, 2f), transform.position.y, transform.position.z);
        GameObject boss = GameObject.Instantiate(onemonster, pos, Quaternion.identity) as GameObject;

        boss.GetComponent<Transform>().SetParent(transform);
    }

    public void stopcontrol()
    {
        CancelInvoke();
    }

}
