using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Progress;


[Serializable]
public class StoreItemJSON
{
    public string Name;
    public int Cost;
    public string ShortDescription;
    public string LongDescription;
    public string ImagePath;
    public string PrefabPath;
}


/// <summary>
/// An item to purchase from the store
/// </summary>
/// 
[ExecuteInEditMode]
public class StoreItem : MonoBehaviour
{
    private string Name;
    private int Cost;
    private string ShortDescription;
    private string LongDescription;
    private Sprite Image;
    private UnityEngine.Object Prefab;

    public void overloadItem(StoreItemJSON overload)
    {
        this.Name = overload.Name;
        var name = this.transform.Find("Name").GetComponent<TextMeshProUGUI>().text = Name;
        this.Cost = overload.Cost;
        this.transform.Find("Cost").GetComponent<TextMeshProUGUI>().text = "$" + Cost.ToString();
        this.ShortDescription = overload.ShortDescription;
        this.transform.Find("ShortDescription").GetComponent<TextMeshProUGUI>().text = ShortDescription;

        this.LongDescription = overload.LongDescription;
        try
        {
            Texture2D loadedImage = Resources.Load<Texture2D>(overload.ImagePath);
            this.Image = Sprite.Create(loadedImage, new Rect(0, 0, loadedImage.width, loadedImage.height), new Vector2());
            this.transform.Find("Image").GetComponent<Image>().sprite = Image;
        }
        catch (Exception ex)
        {
            Debug.LogError("Failed to load image at path " + overload.ImagePath + " Error: " + ex);
        }

        try
        {
            this.Prefab = Resources.Load(overload.PrefabPath);
        }
        catch (Exception ex)
        {
            Debug.LogError("Failed to load prefab at path: " + overload.PrefabPath + " Error: " + ex);
        }
    }
}
