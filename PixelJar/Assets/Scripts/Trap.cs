using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Tilemaps;
//using static UnityEngine.RuleTile.TilingRuleOutput;

/// <summary>
/// This is the template class for objects that are placed on the game tile map.
/// </summary>
public class Trap : MonoBehaviour
{
    private UnityEngine.Vector3 mousePositionOffset;
    private bool Placed = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Placed == false)
        {
            transform.position = GameObject.Find("GameGrid").GetComponent<Grid>().GetCellCenterWorld(GameObject.Find("GameGrid").GetComponent<Grid>().WorldToCell(GetMouseWorldPosition() + mousePositionOffset));

            if(Input.GetMouseButtonUp(0))
            {
                GameManager.instance.TriggerEvent("TrapPlaced");
                transform.position = GameObject.Find("GameGrid").GetComponent<Grid>().GetCellCenterWorld(GameObject.Find("GameGrid").GetComponent<Grid>().WorldToCell(GetMouseWorldPosition() + mousePositionOffset));
                this.transform.position = new UnityEngine.Vector3(this.transform.position.x, this.transform.position.y, 30);
                Placed = true;
            }
        }
    }

    public void Purchased()
    {
        UnityEngine.Vector3 mousePos = GetMouseWorldPosition();
        this.transform.position = new UnityEngine.Vector3(mousePos.x, mousePos.y, 1);
        mousePositionOffset = transform.position - mousePos;
        transform.position = GameObject.Find("GameGrid").GetComponent<Grid>().GetCellCenterWorld(GameObject.Find("GameGrid").GetComponent<Grid>().WorldToCell(mousePos + mousePositionOffset));
        Placed = false;
    }

    private UnityEngine.Vector3 GetMouseWorldPosition()
    {
        return Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
}
