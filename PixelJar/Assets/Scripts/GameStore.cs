using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[Serializable]
public class GameStoreJSON
{
    public StoreItemJSON[] items;
}

/// <summary>
///  manages the selection of prefabs to purchase
/// </summary>
/// 
[ExecuteInEditMode]
public class GameStore : MonoBehaviour
{
    public TextAsset GameStorejsonFile;
    public List<StoreItem> items;
    public UnityEngine.Object ItemDisplayPrefab;
    // Start is called before the first frame update
    void Start()
    {
        UpdateStoreItems();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void UpdateStoreItems()
    {
        foreach (Transform child in this.transform.Find("Display").Find("Items")) { DestroyImmediate(child.gameObject); }

        GameStoreJSON StoreItemsInJSON = JsonUtility.FromJson<GameStoreJSON>(GameStorejsonFile.text);

        foreach (StoreItemJSON item in StoreItemsInJSON.items)
        {
            GameObject newItem = (GameObject)Instantiate(ItemDisplayPrefab, this.transform.Find("Display").Find("Items"));
            newItem.GetComponent<StoreItem>().overloadItem(item);
            items.Add(newItem.GetComponent<StoreItem>());
        }
    }
}
