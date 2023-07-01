using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollbarButtonInterface : MonoBehaviour
{
    private Scrollbar _Scrollbar;

    private float scrollSpeed;

    private void Awake()
    {
        this._Scrollbar = this.GetComponent<Scrollbar>();
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        _Scrollbar.value += scrollSpeed * Time.deltaTime;
    }

    public void ChangeScrollbarValue(float speed)
    {
        scrollSpeed = speed;
    }    
}
