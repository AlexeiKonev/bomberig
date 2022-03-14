using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 2f;
    public Transform[] moveTargets;
    public Transform point1;
    bool CanGo = true;
    public float waitTime = 2f;
   private int rand;
    void Start()
    {
        //StartCoroutine(EnemyMove());
        gameObject.transform.position = new Vector3(point1.position.x, point1.position.y, transform.position.z);
          rand = Random.Range(0, moveTargets.Length - 1);
    }


    void Update()
    {

    }
    void FixedUpdate()
    {

      
         
            if (CanGo)
                transform.position = Vector3.MoveTowards(transform.position, point1.position, speed * Time.deltaTime);
            if (transform.position == point1.position)
            {
                //Transform t = point1;
                point1 = moveTargets[rand];
                //point2 = t;
                CanGo = false;
           rand= Random.Range(0, moveTargets.Length - 1);
                StartCoroutine(Wait());
            }



            //if (CanGo == true)
            //{
            //    var rand = Random.Range(0, moveTargets.Length - 1);
            //    transform.position = Vector3.MoveTowards(transform.position, moveTargets[rand].position, speed * Time.deltaTime);

            //}

        }
    //IEnumerator EnemyMove()
    //{
    //    yield return new WaitForSeconds(2f);
    //    for (int i = 0; i < moveTargets.Length - 1; i++)
    //    {
    //        var temp = Random.Range(0, moveTargets.Length - 1);

    //        Debug.Log($"{temp}");



    //    }
    //}


    IEnumerator Wait()
    {
        yield return new WaitForSeconds(waitTime);
        //if (transform.rotation.y == 0)
        //    transform.eulerAngles = new Vector3(0, 180, 0);
        //else
        //    transform.eulerAngles = new Vector3(0, 0, 0);
        CanGo = true;
    }

}
//public Transform point1;
//public Transform point2;
//public float speed = 2f;
//public float waitTime = 3f;
//bool CanGo = true;
//// Start is called before the first frame update
//void Start()
//{
//    gameObject.transform.position = new Vector3(point1.position.x, point1.position.y, transform.position.z);

//}



//if (CanGo)
//    transform.position = Vector3.MoveTowards(transform.position, point1.position, speed * Time.deltaTime);
//if (transform.position == point1.position)
//{
//    Transform t = point1;
//    point1 = point2;
//    point2 = t;
//    CanGo = false;
//    StartCoroutine(Wait());
//}

//IEnumerator Wait()
//{
//    yield return new WaitForSeconds(waitTime);
//    if (transform.rotation.y == 0)
//        transform.eulerAngles = new Vector3(0, 180, 0);
//    else
//        transform.eulerAngles = new Vector3(0, 0, 0);
//    CanGo = true;
//}
//    }
//}