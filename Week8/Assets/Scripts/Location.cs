using UnityEngine;
using UnityEngine.UI; // 必须引用，用于处理 Image 组件

[CreateAssetMenu(fileName = "Location", menuName = "Scriptable Objects/Location")]
public class Location : ScriptableObject
{
    public string name;
    [TextArea(3, 10)] // 让编辑器里的文本框大一点
    public string description;

    // 新增：存放这个场景的背景图片
    public Sprite locationImage;

    public Location northLocation;
    public Location southLocation;
    public Location westLocation;
    public Location eastLocation;

    /*private void OnValidate();
    {
        if (westLocation != null && westLocation.eastLocation != this)
        {
            westLocation.eastLocation = this;
        }

        if (GameManager.instance != null)
        {
            UpdateLocationDisplay(GameManager.instance);
        }
    }*/

    public void UpdateLocationDisplay(GameManager gm)
    {
        gm.locationNameDisplay.text = name;
        gm.locationDescriptionDisplay.text = description;

        // 新增：如果背景图组件存在且当前位置有图片，就更换图片
        if (gm.backgroundDisplay != null && locationImage != null)
        {
            gm.backgroundDisplay.sprite = locationImage;
        }

        if (northLocation == null)
        {
            gm.NorthButton.SetActive(false);
        }
        else
        {
            gm.NorthButton.SetActive(true);
        }

        if (southLocation == null)
        {
            gm.SouthButton.SetActive(false);
        }
        else
        {
            gm.SouthButton.SetActive(true);
        }

        if (westLocation == null)
        {
            gm.WestButton.SetActive(false);
        }
        else
        {
            gm.WestButton.SetActive(true);
        }
        //if westLocation is null then false,turn the button off
        gm.EastButton.SetActive(eastLocation!=null);
    }
}