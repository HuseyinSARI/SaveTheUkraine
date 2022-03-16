using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField]   private GameObject levelFinishParent;

    private bool levelFinished = false;
    public bool GetLevelFinished
    {
        get
        {
            return levelFinished;
        }
    }
    
    void Start()
    {
        
    }

    void Update()
    {
        int enemyCount = FindObjectsOfType<Enemy>().Length;

        if (enemyCount <=0)
        {
            levelFinishParent.gameObject.SetActive(true);
            levelFinished = true;
        }
        else
        {
            levelFinishParent.gameObject.SetActive(false);
            levelFinished = false;
        }
    }
    public void RestartLevel()
    {
        SceneManager.LoadScene(0);
    }

}
