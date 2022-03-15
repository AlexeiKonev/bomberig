using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Bomb : MonoBehaviour
{
    
    public  Transform transBomb;
  

    private void Awake()
    {
      
        
        transBomb = GetComponent<Transform>();
        StartCoroutine(BombAnim());
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator   BombAnim()
    {
        yield return new WaitForSeconds(1f);
        transBomb.localScale = new Vector2(2, 2);
        yield return new WaitForSeconds(1f);
        transBomb.localScale = new Vector2(1, 1);
        StartCoroutine(BombAnim());
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "enemy")
        {
            if (Scores.Damaged==false)
            {
                Scores.Damaged = true;
                Scores.LifeEnemy--;
                Scores.canGo = false;
                
                StartCoroutine(Dirty());
                Debug.Log($"{Scores.Damaged}");

                Destroy(gameObject);
            }
              if (Scores.Damaged == true&&Scores.canGo)
            {
                Scores.Damaged = false;
                Destroy(gameObject);
            }
            
        }
    }

    IEnumerator Dirty()
    {
        yield return new WaitForSeconds(1f);
        Scores.Damaged = true;
        
        Scores.canGo = true;
        Debug.Log($"{Scores.Damaged}");
         
        
    }
}
