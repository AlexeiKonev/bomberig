using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
   [SerializeField] private Rigidbody2D _rb;
    public float speed = 2f;
    public Transform[] moveTargets;
    public Transform point1;
     
    public float waitTime = 2f;
    private int rand;

    private void Awake()
    {
        Scores.LifeEnemy = 6;
        Scores.Damaged = false;
    }

    void Start()
    {
        
        
        gameObject.transform.position = new Vector3(point1.position.x, point1.position.y, transform.position.z);
          rand = Random.Range(0, moveTargets.Length - 1);
    }


    void Update()
    {

    }
    void FixedUpdate()
    {

        Flip();

        if (Scores.canGo) 
        { 
            transform.position = Vector3.MoveTowards(transform.position, point1.position, speed * Time.deltaTime);
        }
         
        else { 
            StartCoroutine(Wait());
        }
          
            if (transform.position == point1.position)
            {

            point1 = moveTargets[rand];
            
            Scores.canGo = false;
            rand = Random.Range(0, moveTargets.Length - 1);
                StartCoroutine(Wait());
            }

        


     }
    
    

   public IEnumerator Wait()
    {
        yield return new WaitForSeconds(waitTime);
        
        Scores.canGo = true;
    }
    
    public void Flip()
    {
        if (_rb.position.x > 3)
        {

            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        if (_rb.position.x <  3)
        {

            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
    }
    
    
}
