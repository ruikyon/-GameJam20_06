using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Caution : MonoBehaviour
{
    private RawImage img;

    // Start is called before the first frame update
    void Start()
    {
        img = GetComponent<RawImage>();
    }

    IEnumerator Blink() 
    {
        while (true) 
        {
            yield return new WaitForFixedUpdate();
                var color = img.color;
                color.a = (Mathf.Sin(Time.time * 4) / 2 + 0.5f) / 2;
                img.color = color;
        }
    }

    private void OnEnable()
    {
        StartCoroutine(Blink());
    }
}
