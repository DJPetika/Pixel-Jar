using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Conditional : MonoBehaviour
{
    public string OnEvent;
    public string OffEvent;

    public GameObject Element;

    // Start is called before the first frame update
    void Start()
    {
        GameManager.instance.StartListening(OnEvent, delegate { Element.SetActive(true); });
        GameManager.instance.StartListening(OffEvent, delegate { Element.SetActive(false); });
    }
}
