using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UILayerManager : MonoBehaviour
{
    public void BringToFront()
    {
        transform.SetAsLastSibling();
    }
}
