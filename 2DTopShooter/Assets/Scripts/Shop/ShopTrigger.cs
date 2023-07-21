using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopTrigger : MonoBehaviour
{
    public GameObject Shop;
    public GameObject Prompt;

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Prompt.SetActive(true);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Prompt.SetActive(false);
        }
    }

    void Update()
    {
        if(Prompt.activeSelf && Input.GetKeyDown(KeyCode.F))
        {
            Shop.SetActive(true);
            Prompt.SetActive(false);
            Destroy(gameObject);
        }
    }
}
