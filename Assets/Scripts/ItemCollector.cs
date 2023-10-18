using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemCollector : MonoBehaviour
{
    private int melons = 0;
    
    [SerializeField] private TMP_Text melonsText;

    [SerializeField] private AudioSource collectSoundEffect;
    //other method to do this is by using OnCollisionEnter2D
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //first of all must state collision.gameObject.CompareTag("String")) to show which tag to destroy
        if (collision.gameObject.CompareTag("Collectible"))
        {
            //then use Destroy method and code already stated that collision.gameObject is Collectible
            collectSoundEffect.Play();
            Destroy(collision.gameObject);
            //can also write melons = melons + 1;
            melons++;
            melonsText.text = ": " + melons;
        }
        //just to see melons collection in console
        Debug.Log("melons: " + melons);
    }
}
