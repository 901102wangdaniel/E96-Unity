using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCursor : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Convert mouse position to world coordinates
        Vector2 cursorPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        // Update the position of the GameObject to the cursor position
        transform.position = cursorPosition;
    }
}
