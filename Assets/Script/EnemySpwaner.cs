using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpwaner : MonoBehaviour
{
    public float spwanTime = 2f;
    public float curTime;
    public Transform[] spwanPoints;
    public GameObject enemy;
    // Start is called before the first frame update
    void Start()
    {
        
    }


    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.isPlay)
        {
            if (curTime >= spwanTime)
            {
                int x = Random.Range(0, spwanPoints.Length);
                SpwanEnemy(x);
            }
            curTime += Time.deltaTime;
        }
            
    }
    public void SpwanEnemy(int ranNum)
    {
        curTime = 0;
        Instantiate(enemy, spwanPoints[ranNum]);
    }
}
