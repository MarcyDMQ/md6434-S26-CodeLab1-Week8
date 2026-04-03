using TMPro;
using UnityEngine;
using UnityEngine.UI; // 必须引用，因为我们要用到 Image 组件

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI locationNameDisplay;
    public TextMeshProUGUI locationDescriptionDisplay;
    
    // 新增：用于显示背景图片的 UI Image 组件
    public Image backgroundDisplay;

    public Location startingLocation;
    public Location currentLocation;

    public GameObject NorthButton;
    public GameObject EastButton;
    public GameObject WestButton;
    public GameObject SouthButton;

    public static GameManager instance;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        //startingLocation.name = "Yard";//don't do this. just to show you you will overwrite data when you change it in playmode
        Debug.Log("Current Location:"+startingLocation);

        //locationNameDisplay.text = startingLocation.name;
        //locationDescriptionDisplay.text = startingLocation.description;
        
        startingLocation.UpdateLocationDisplay(this);

        currentLocation = startingLocation;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //North=0 East=1 West=2 South=3

    public void MoveDirection(int direction)
    {
        //make the location actually change when this function is called
        //currentLocation = currentLocation.northLocation;
        switch (direction)
        {
            case 0://North
                // 下面这一行注释掉了，因为 ScriptableObject 会保存运行时的修改，通常不需要动态修改地图连接
                // currentLocation.northLocation.southLocation = currentLocation; 
                currentLocation = currentLocation.northLocation;
                break;
            case 1://East
                // currentLocation.eastLocation.westLocation = currentLocation;
                currentLocation = currentLocation.eastLocation;
                break;
            case 2://West
                // currentLocation.westLocation.eastLocation = currentLocation;
                currentLocation = currentLocation.westLocation;
                break;
            case 3://South
                // currentLocation.southLocation.northLocation = currentLocation;
                currentLocation = currentLocation.southLocation;
                break;
        }
        currentLocation.UpdateLocationDisplay(this);
        
    }
}