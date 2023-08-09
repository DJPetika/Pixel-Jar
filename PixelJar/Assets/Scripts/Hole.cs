using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hole : Trap
{
    public int damage = 1;
    public int speedModifier = -1;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Adventurer")
        {
            other.gameObject.GetComponent<Adventurer>().takeDamage(this.damage);
            other.gameObject.GetComponent<Adventurer>().modifySpeed(this.speedModifier);
            GameManager.instance.TriggerEvent("PitFall");
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Adventurer")
        {
            other.gameObject.GetComponent<Adventurer>().resetSpeed();
        }
    }
}
