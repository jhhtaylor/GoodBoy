using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    AudioSource AS;
    public AudioClip bark1;
    public AudioClip bark2;
    public AudioClip bark3;
    public AudioClip bark4;
    public AudioClip bark5;
    public AudioClip bark6;

    public int currentItem;

    public Text itemText;

    // Start is called before the first frame update
    void Start()
    {
        AS = GameObject.FindObjectOfType<AudioSource>();
    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.R))
        {
            int num = Random.Range(1, 7);
            if (num == 1)
            {
                AS.PlayOneShot(bark1);

            }
            else if (num == 2)
            {
                AS.PlayOneShot(bark1);

            }
            else if (num == 3)
            {
                AS.PlayOneShot(bark3);

            }
            else if (num == 4)
            {
                AS.PlayOneShot(bark4);

            }
            else if (num == 5)
            {
                AS.PlayOneShot(bark5);

            }
            else if (num == 6)
            {
                AS.PlayOneShot(bark6);



            }
        }
        if (Input.GetKeyDown(KeyCode.E))
        {

        }

    }

    public void addItem(int itemToAdd)
    {
        currentItem += itemToAdd;
        itemText.text = "Item: " + currentItem;
    }
}
