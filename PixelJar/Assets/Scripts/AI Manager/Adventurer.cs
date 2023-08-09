using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;
using UnityEngine.AI;

[Serializable]
public class Stats
{
    public int damageVal;
    public int health;
    public float speed;
    public float defaultSpeed;
    public float detectRange;
}


public class Adventurer : MonoBehaviour
{
    public NavMeshAgent NMA;
    [SerializeField]
    public Stats stats = new Stats();

    private void Start()
    {
        this.NMA = this.GetComponent<NavMeshAgent>();

        this.NMA.SetDestination(GameManager.instance.FrontDesk.transform.position);
        this.NMA.speed = this.stats.speed;
    }


    // Update is called once per frame
    void Update()
    {
    }

    public void takeDamage(int damage)
    {
        this.stats.health -= damage;
        if(stats.health <= 0)
        {
            Destroy(this.gameObject);
            GameManager.instance.TriggerEvent("Death_Hero");
        }
        else
        {
            GameManager.instance.TriggerEvent("Dmg_Hero");
        }
    }

    public void modifySpeed(int modification)
    {
        this.stats.defaultSpeed = this.stats.speed;
        this.stats.speed += modification;
        this.NMA.speed = this.stats.speed;
    }

    public void resetSpeed()
    {
        this.stats.speed = this.stats.defaultSpeed;
        this.NMA.speed = this.stats.speed;
    }
}
