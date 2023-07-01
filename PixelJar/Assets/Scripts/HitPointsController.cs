using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitPointsController : MonoBehaviour
{
    StarUI[] stars;

    // Start is called before the first frame update
    void Start()
    {
        stars = this.GetComponentsInChildren<StarUI>();
        GameManager.instance.StartListening("UpdateHitPoints", UpdateHitPoints);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateHitPoints()
    {
        int HPperStar = GameManager.instance.maxHealth / stars.Length;

        int fullStars = GameManager.instance.curHealth / HPperStar;
        int partialStar = GameManager.instance.curHealth % HPperStar;

        for(int i = 0; i < fullStars; ++i)
        {
            stars[i].SetStarPercentage(1.0f);
        }
        stars[fullStars].SetStarPercentage(partialStar);
    }
}
