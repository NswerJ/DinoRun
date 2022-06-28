using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public GameObject bullet;
    public Transform pos;
    public float coolTime;
    private float curTime;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.isPlay)
        {
            if (curTime <= 0)
            {
                if (Input.GetKey(KeyCode.Z))
                {
                    Instantiate(bullet, pos.position, transform.rotation); ;
                }
                curTime = coolTime;
            }
            curTime -= Time.deltaTime;

        }
            
        
    }
}
