using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalGun : MonoBehaviour
{
    Camera cam;
    [SerializeField] public GameObject whitePortalPrefab; // Prefab for white portal
    [SerializeField] public GameObject greyPortalPrefab; // Prefab for grey portal
    private GameObject currentWhitePortal;  // Current white portal instance
    private GameObject currentGreyPortal;  // Current grey portal instance



    void Start()
    {
        cam = Camera.main;
    }

    void Update()
    {
        // GameObject validBRight = null; // You need to define what this GameObject is
        // GameObject validBLeft = null; // Define this GameObject as well



        if (Input.GetMouseButtonDown(0)
            //&& the PORTAL IS IN VALID SPOT

        ) // Assuming left click for white portal
        {
            Vector2 cursorPos = cam.ScreenToWorldPoint(Input.mousePosition);
            if (whitePortalPrefab != null)
            {
                Destroy(whitePortalPrefab);
                Debug.Log("Destroyed old white portal, instantiating new one");
            }
            whitePortalPrefab = Instantiate(whitePortalPrefab, new Vector3(cursorPos.x, cursorPos.y, 0), Quaternion.identity);
            BoxCollider2D boxCollider1 = whitePortalPrefab.GetComponent<BoxCollider2D>();
            if (boxCollider1 != null)
            {
                boxCollider1.enabled = true;   // Re-enable the collider
            }
            whitePortalPrefab.tag = "white";
        }
        

        if (Input.GetMouseButtonDown(1)) // Assuming right click for grey portal
        {
            Vector2 cursorPos = cam.ScreenToWorldPoint(Input.mousePosition);
            if (greyPortalPrefab != null)
            {
                Destroy(greyPortalPrefab);
            }
            greyPortalPrefab = Instantiate(greyPortalPrefab, new Vector3(cursorPos.x, cursorPos.y, 0), Quaternion.identity);
             BoxCollider2D boxCollider2 = greyPortalPrefab.GetComponent<BoxCollider2D>();
            if (boxCollider2 != null)
            {
                boxCollider2.enabled = true;   // Re-enable the collider
            }
            greyPortalPrefab.tag = "grey";
        }

// where we check the right and left
        // if (validBRight != null && TouchingBRight(validBRight) || validBLeft != null && TouchingBLeft(validBLeft))
        // {
        //     if (TouchingBRight(validBRight))
        //     {
        //         // Touching right
        //         // Allow place right portal (rotate portal, make x scale negative)
        //     }
        //     else if (TouchingBLeft(validBLeft))
        //     {
        //         // Touching left
        //         // Allow place left portal
        //     }
        // }
        
    }

    public bool TouchingBRight(GameObject validBRight)
    {
        Vector2 cursorPos = cam.ScreenToWorldPoint(Input.mousePosition);
        return validBRight.GetComponent<Collider2D>().OverlapPoint(cursorPos);
    }
    // Debug.Log(TouchingBRight);

    public bool TouchingBLeft(GameObject validBLeft)
    {
        Vector2 cursorPos = cam.ScreenToWorldPoint(Input.mousePosition);
        return validBLeft.GetComponent<Collider2D>().OverlapPoint(cursorPos);
    }
}






// public class PortalGun : MonoBehaviour
// {

//     Camera cam;
//     public GameObject assingedPortal;  // Ensure this is assigned the prefab of the portal in the Unity Inspector
//     private GameObject currentPortal;  // To keep track of the current portal instance

//     // public GameObject pivot;

//     // Start is called before the first frame update
//     void Start()
//     {
//         cam = Camera.main;
//     }

//     // Update is called once per frame
//     void Update()
//     {



// //instantiate portal
//         if (Input.GetMouseButtonDown(0))
//         {
//             Vector2 cursorPos = cam.ScreenToWorldPoint(Input.mousePosition);
//             // GameObject oldPortal = GameObject.FindGameObjectWithTag("white");

//             if (assingedPortal != null)
//             {
//                 Destroy(assingedPortal);
//                 // Destroy(portal);
//             }

//             assingedPortal = Instantiate(assingedPortal, new Vector3(cursorPos.x, cursorPos.y, 0), Quaternion.identity);

//         }
//     }
// }