using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Hero Data", menuName = "ScriptableObjects/Hero")]
public class Hero : ScriptableObject 
{

    public Sprite heroSprite;
    public string heroName;
    public int damageVal;
    public int health;
    public float speed;
    public float detectRange;

    public void Attack(){

    }

    public void GetDestination(){

    }

}
