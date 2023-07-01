using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClockUI : MonoBehaviour
{
    Transform ClockPointer;

    // Start is called before the first frame update
    void Start()
    {
        ClockPointer = this.transform.Find("Pointer");
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.instance.state == GameState.Day)
        {
            float angle = Mathf.Lerp(90.0f, -90.0f, GameManager.instance.time / GameManager.instance.dayLength);
            ClockPointer.eulerAngles = new Vector3(ClockPointer.rotation.eulerAngles.x, ClockPointer.rotation.eulerAngles.y, angle);
        }
        else if (GameManager.instance.state == GameState.Night)
        {
            float angle = Mathf.Lerp(-90.0f, 90.0f, GameManager.instance.time / GameManager.instance.nightLength);
            ClockPointer.eulerAngles = new Vector3(ClockPointer.rotation.eulerAngles.x, ClockPointer.rotation.eulerAngles.y, angle);
        }
    }
}
