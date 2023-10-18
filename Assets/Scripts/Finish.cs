using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    private AudioSource finishSound;

    //false because when level begins, we have not completed it
    private bool levelCompleted = false;
    // Start is called before the first frame update
    private void Start()
    {
        finishSound = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //detects when player has collided with the Finish flag, and whether level is completed.
        if (collision.gameObject.name == "Player" && !levelCompleted)
        {
            finishSound.Play();
            levelCompleted = true;
            //Invoke method used to delay command such as eg. ("CompleteLevel")
            //when calling Invoke, no longer have to write command again.
            Invoke("CompleteLevel", 1f);
        }

    }
    private void CompleteLevel()
    {
        //used to load the next scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
