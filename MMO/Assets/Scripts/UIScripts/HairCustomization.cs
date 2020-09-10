using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HairCustomization : MonoBehaviour
{
    //hair color

    public Image hair;
    public Button hairColorChanger;



    List<Color> hairColorList;
    public int colorNumber = 1;



    //hair style

    public Button hairStyleChanger;
    public Sprite[] hairStyles;
    public Image currentHairStyle;
    public int hairStyle;



    // Start is called before the first frame update
    void Start()
    {
        hairStyle = 0;

        hairColorList = new List<Color>();

        hairColorList.Add(Color.black);
        hairColorList.Add(Color.white);
        hairColorList.Add(Color.gray);
        hairColorList.Add(Color.green);
        hairColorList.Add(Color.magenta);
        hairColorList.Add(Color.cyan);
        hairColorList.Add(Color.red);
        hairColorList.Add(Color.yellow);

        hairColorChanger.GetComponent<Button>().onClick.AddListener(ChangeHairColor);


        hairStyleChanger.GetComponent<Button>().onClick.AddListener(ChangeHairStyle);


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeHairColor()
    {
            if (colorNumber < hairColorList.Count)
            {
                Debug.Log("Color number is : " + colorNumber);
                hair.GetComponent<Image>().color = hairColorList[colorNumber];
                colorNumber += 1;
            }
            if (colorNumber >= hairColorList.Count)
            {
                colorNumber = 1;
                Debug.Log("Color number is : " + colorNumber);
            }
    }

    public void ChangeHairStyle()
    {
        if (hairStyle < hairStyles.Length)
        {
            hairStyle += 1;
        }
        if (hairStyle >= hairStyles.Length)
        {
            hairStyle = 0;
        }

        switch (hairStyle)
        {
            case 0:
                currentHairStyle.GetComponent<Image>().sprite = hairStyles[0];
                break;
            case 1:
                currentHairStyle.GetComponent<Image>().sprite = hairStyles[1];
                break;
            case 2:
                currentHairStyle.GetComponent<Image>().sprite = hairStyles[2];
                break;
        }
    }

}
