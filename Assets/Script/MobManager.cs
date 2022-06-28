using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobManager : MonoBehaviour
{
    public List<GameObject> MobPool = new List<GameObject>();
    public GameObject[] Mobs;
    public int objCnt = 1;

    void Start()
    {
        GameManager.instance.onPlay += PlayGame;
    }
    void PlayGame(bool isplay)
    {
        if (isplay)
        {
            for(int i = 0; i<MobPool.Count; i++)
            {
                if (MobPool[i].activeSelf)
                    MobPool[i].SetActive(false);
            }
            StartCoroutine(CreateMob());
        }
            
        else
            StopAllCoroutines();
    }
    private void Awake()
    {
        for(int i = 0; i< Mobs.Length; i++)
        {
            for(int q = 0; q< objCnt; q++)
            {
                MobPool.Add(CreateObj(Mobs[i], transform));
            }
        }
    }
    IEnumerator CreateMob()
    {
        yield return new WaitForSeconds(0.5f);
        while (GameManager.instance.isPlay)
        {
            MobPool[Random.Range(0, MobPool.Count)].SetActive(true);
            yield return new WaitForSeconds(Random.Range(1f, 2f));
        }
        
    }

    GameObject CreateObj(GameObject obj, Transform parent)
    {
        GameObject copy = Instantiate(obj);
        copy.transform.SetParent(parent);
        copy.SetActive(false);
        return copy;
    }
    
    

    // Update is called once per frame
    void Update()
    {
        
    }
}
