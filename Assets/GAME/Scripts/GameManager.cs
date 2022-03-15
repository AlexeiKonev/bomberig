using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public  class GameManager : MonoBehaviour
{
    public Animator anim;
    public GameObject tutorialPanel;
    public GameObject winPanel;
    public GameObject losePanel;
    public Transform[] enemyDestination;
    public Transform  playerPos;
    public int currentLifeEnemy;
    public int currentLifePlayer;
    public Text currentLifeEnemyT;
    public Text currentLifePlayerT;
    
    public GameObject bomb;
    void Start()
    {
         
        TutorialOpen();
    }

    // Update is called once per frame
    void Update()
    {
        currentLifePlayer = Scores.LifePlayer;
        currentLifePlayerT.text = currentLifePlayer.ToString( );
        if (Scores.Damaged == true)
        {
            anim.SetInteger("farm",1);
        }
        if(Scores.Damaged==false)  
        {
            anim.SetInteger("farm", 0);
        }
        currentLifeEnemy = Scores.LifeEnemy;
        currentLifeEnemyT.text = currentLifeEnemy.ToString();
        if (Scores.LifeEnemy <= 0)
        {
            WinPanelOpen();
        }
        if (Scores.LifePlayer <= 0)
        {
            Lose();
        }
    }
    public void BombPlace()
    {
        
        //Instantiate(bomb,playerPos.position,bomb.transform.rotation );
        Instantiate(bomb, new Vector3(Mathf.RoundToInt(playerPos.position.x), Mathf.RoundToInt(playerPos.position.y),bomb.transform.position.z),
bomb.transform.rotation);
    }
   public void TutorialClose()
    {
        Time.timeScale = 1;
        tutorialPanel.SetActive(false);
    }
 public   void TutorialOpen()
    {
        Time.timeScale = 0;
        tutorialPanel.SetActive(true);
    }
    public void WinPanelOpen()
    {
        Time.timeScale = 0;
        winPanel.SetActive(true);
    }
    public void RestartLevel()
    {
        SceneManager.LoadScene(0);
    }
    public void Lose()
    {
        Time.timeScale = 0;
        losePanel.SetActive(true);
    }
}
