using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorToggle : MonoBehaviour
{
    public Animator _AnimatorToggle;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Toggle()
    {
        bool hold = _AnimatorToggle.GetBool("Toggle");

        hold = !hold;

        _AnimatorToggle.SetBool("Toggle", hold);
    }
}
