using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCustomization : MonoBehaviour
{

    List<Color> colorList;
    public int colorNumber = 1;

    public Image componentFirst;
    public Image componentSecond;
    void Start()
    {
        colorList = new List<Color>();

        colorList.Add(new Color (1f, 0.941f, 0.827f) ) ;
        colorList.Add(new Color (1f, 0.867f, 0.647f) ) ;

        colorList.Add(new Color (0.992f, 0.859f, 0.722f) ) ;
        colorList.Add(new Color (0.969f, 0.686f, 0.443f) ) ;

        colorList.Add(new Color (0.969f, 0.733f, 0.58f) ) ;
        colorList.Add(new Color (0.922f, 0.608f, 0.294f) ) ;

        colorList.Add(new Color (0.878f, 0.635f, 0.459f) ) ;
        colorList.Add(new Color (0.875f, 0.549f, 0.216f) ) ;

        colorList.Add(new Color (0.788f, 0.498f, 0.4f) ) ;
        colorList.Add(new Color (0.788f, 0.471f, 0.271f) ) ;

        colorList.Add(new Color (0.565f, 0.325f, 0.216f) ) ;
        colorList.Add(new Color (0.361f, 0.102f, 0f) ) ;

    }
    // Update is called once per frame
    void Update()
    {
        OnMouseClick();
       
    }

    private void OnMouseClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (colorNumber < colorList.Count)
            {


                Debug.Log("Color number is : " + colorNumber);
                componentFirst.GetComponent<Image>().color = colorList[colorNumber];
                componentSecond.GetComponent<Image>().color = colorList[colorNumber];
                colorNumber += 1;
            }
            if (colorNumber >= colorList.Count)
            {
                colorNumber = 1;
                Debug.Log("Color number is : " + colorNumber);
            }
        }
    }
}
