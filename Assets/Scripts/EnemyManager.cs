using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] private Others enemyPrefab;
    [SerializeField] private int baseEnemyCount, interval;
    private List<Others> others = new List<Others>();

    // Start is called before the first frame update
    void Start()
    {
        for(var i = 0; i < baseEnemyCount; i++) 
        {
            others.Add(Instantiate(enemyPrefab));
        }

        Scheduler.AddEvent(5, () => StartCoroutine(Decrease()));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator Decrease() 
    {
        while(others.Count > 3) 
        {
            yield return new WaitForSeconds(interval);
            Destroy(others[0].gameObject);
            others.RemoveAt(0);
        }
    }
}
