using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Others : MonoBehaviour
{
    private int id;
    private bool enter;
    private static int totalCount = 1;

    private float mvSpeed = 0.285f;

    // Start is called before the first frame update
    void Start()
    {
        enter = false;
        var x = Random.Range(-12.5f, 12.5f);
        var y = Random.Range(-12.5f, 12.5f);
        transform.position = new Vector3(x, 0, y);
        StartCoroutine(Move());

        //id = totalCount;
        //totalCount++;
        //StartCoroutine(Check());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Move() 
    {
        while (true) 
        {
            var x = Random.Range(-12.5f, 12.5f);
            var y = Random.Range(-12.5f, 12.5f);
            var target = new Vector3(x, 0, y);
            transform.forward = target - transform.position;
            yield return new WaitForSeconds((target-transform.position).magnitude / mvSpeed);
        }
    }

    IEnumerator Check() 
    {
        while (true) 
        {
            Debug.Log(id + ": " + transform.position.z);
            yield return new WaitForSeconds(10);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player") 
        {
            enter = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            enter = false;
        }
    }

    private void OnDestroy()
    {
        if (enter) 
        {
            Wall.DecCount();
        }
    }
}
