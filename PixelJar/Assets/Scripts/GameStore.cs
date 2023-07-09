using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


[Serializable]
public class GameStoreJSON
{
    public List<StoreItemJSON> items;
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
        Transform itemsParent = this.transform.Find("Display").Find("Items");
        while (itemsParent.childCount > 0)
        {
            DestroyImmediate(itemsParent.GetChild(0).gameObject); 
        }
        items.Clear();

        GameStoreJSON StoreItemsInJSON = JsonUtility.FromJson<GameStoreJSON>(GameStorejsonFile.text);

        foreach (StoreItemJSON item in StoreItemsInJSON.items)
        {
            GameObject newItem = (GameObject)Instantiate(ItemDisplayPrefab, itemsParent);
            newItem.GetComponent<StoreItem>().overloadItem(item);
            items.Add(newItem.GetComponent<StoreItem>());
        }
    }
}
