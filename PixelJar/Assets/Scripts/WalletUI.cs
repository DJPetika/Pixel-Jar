using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WalletUI : MonoBehaviour
{
    TextMeshProUGUI WalletText;

    // Start is called before the first frame update
    void Start()
    {
        WalletText = this.GetComponentInChildren<TextMeshProUGUI>();
        GameManager.instance.StartListening("UpdateWallet", UpdateWallet);
    }

    // Update is called once per frame
    void Update()
    {
        WalletText.text = GameManager.instance.coinCount.ToString("D9");
    }

    public void UpdateWallet()
    {
        WalletText.text = GameManager.instance.coinCount.ToString("D9");
    }
}
