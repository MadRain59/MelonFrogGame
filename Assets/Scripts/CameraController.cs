using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    //use [SerializeField] with a component to grab the value of another objects component
    [SerializeField] private Transform player;
    private void Update()
    {
        //use small letters to grab component of own object
        transform.position = new Vector3(player.position.x, player.position.y, -10);
    }
}
