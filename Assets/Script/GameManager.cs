using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    #region instance
    public static GameManager instance;
    private void Awake()
    {
        if(instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
    }
    #endregion

    public delegate void OnPlay(bool isplay);
    public OnPlay onPlay;

    public float gameSpeed = 1;
    public bool isPlay = false;
    public GameObject playBtn;

    public Text scoreTxt;
    public Text bestscoreTxt;
    public int score = 0;

    IEnumerator AddScore()
    {
        while (isPlay)
        {
            score++;
            scoreTxt.text = score.ToString();
            gameSpeed = gameSpeed + 0.01f;
            yield return new WaitForSeconds(0.1f);
        }
    }
    void Start()
    {
        bestscoreTxt.text = PlayerPrefs.GetInt("BestScore", 0).ToString();
    }
    public void PlayBtn()
    {
        playBtn.SetActive(false);
        isPlay = true;
        onPlay.Invoke(isPlay);
        scoreTxt.text = score.ToString();
        StartCoroutine(AddScore());
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void GameOver()
    {
        playBtn.SetActive(true);
        isPlay = false;
        onPlay.Invoke(isPlay);
        StopCoroutine(AddScore());
        if (PlayerPrefs.GetInt("BestScore", 0) < score)
        {
            PlayerPrefs.SetInt("BestScore", score);
            bestscoreTxt.text = score.ToString();
        }
        

    }
}
