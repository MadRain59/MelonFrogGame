using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickyPlatform : MonoBehaviour
{


    private void OnTriggerEnter2D(Collider2D collision)
    {
        //calls player as gameObject
        if (collision.gameObject.name == "Player")
        {
            //sticks player to current position of moving platform
            collision.gameObject.transform.SetParent(transform);
            
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            //used to exit parent of moving platform
            collision.gameObject.transform.SetParent(null);
        }
    }
}
