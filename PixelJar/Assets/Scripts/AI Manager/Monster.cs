using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Monster : MonoBehaviour
{
    public NavMeshAgent NMA;

    private void Start()
    {
        this.NMA = this.GetComponent<NavMeshAgent>();

        this.NMA.SetDestination(GameManager.instance.FrontDesk.transform.position);
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
