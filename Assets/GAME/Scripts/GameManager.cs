using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject tutorialPanel;
    public Transform[] enemyDestination;
    public Transform  playerPos;
    
    public GameObject bomb;
    void Start()
    {
        TutorialOpen();
    }

    // Update is called once per frame
    void Update()
    {
        
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
}
