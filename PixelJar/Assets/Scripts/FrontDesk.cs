using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrontDesk : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == "Adventurer")
        {
            GameManager.instance.curHealth -= 1;
            Destroy(collision.collider.gameObject);
        }
        else if (collision.collider.tag == "Monster")
        {
            GameManager.instance.coinCount += 100;
            Destroy(collision.collider.gameObject);
        }
    }
}
