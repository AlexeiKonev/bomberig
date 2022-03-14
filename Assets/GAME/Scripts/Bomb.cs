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
}
