using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTeleport : MonoBehaviour
{
    public float distance = 0.2f;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Transform whiteDestination = GameObject.FindGameObjectWithTag("white")?.transform;
            Transform greyDestination = GameObject.FindGameObjectWithTag("grey")?.transform;

            Transform targetDestination = null;
            if (gameObject.CompareTag("white") && greyDestination != null)
            {
                targetDestination = greyDestination;
            }
            else if (gameObject.CompareTag("grey") && whiteDestination != null)
            {
                targetDestination = whiteDestination;
            }

            if (targetDestination != null && Vector2.Distance(transform.position, other.transform.position) > distance)
            {
                other.transform.position = new Vector2(targetDestination.position.x, targetDestination.position.y);
            }
        }
    }
}

// public class PlayerTeleport : MonoBehaviour
// {
//     private Transform whiteDestination;
//     private Transform greyDestination;
//     public float distance = 0.2f;

//     void Update()
//     {
//         whiteDestination = GameObject.FindGameObjectWithTag("white").GetComponent<Transform>();
//         greyDestination = GameObject.FindGameObjectWithTag("grey").GetComponent<Transform>();
//         Debug.Log(whiteDestination);
//     }


//     void OnTriggerEnter2D(Collider2D other)
//     {
//         if (other.CompareTag("Player"))
//         {
//             Transform targetDestination = null;
//             if (gameObject.CompareTag("white") && greyDestination != null)
//             {
//                 targetDestination = greyDestination;
//             }
//             else if (gameObject.CompareTag("grey") && whiteDestination != null)
//             {
//                 targetDestination = whiteDestination;
//             }

//             if (targetDestination != null && Vector2.Distance(transform.position, other.transform.position) > distance)
//             {
//                 other.transform.position = new Vector2(targetDestination.position.x, targetDestination.position.y);
//             }
//         }
//     }
// }
