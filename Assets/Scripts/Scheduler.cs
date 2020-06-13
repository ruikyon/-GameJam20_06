using System;
using System.Collections;
using UnityEngine;

//遅延実行用のクラス
public class Scheduler : MonoBehaviour
{
    private static Scheduler instance;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
        {
            Debug.Log("eroor: scheduler already exists");
            Destroy(gameObject);
        }
    }

    ///<summary>
    ///time秒後にactionを実行する。
    ///</summary>    
    public static Coroutine AddEvent(float time, Action action)
    {
        return instance.StartCoroutine(ExeOnDelay(time, action));
    }

    private static IEnumerator ExeOnDelay(float time, Action action)
    {
        yield return new WaitForSeconds(time);

        action();
    }
}