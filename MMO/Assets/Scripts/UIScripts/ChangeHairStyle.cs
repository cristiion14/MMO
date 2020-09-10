using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeHairStyle : MonoBehaviour
{
    public Sprite[] hairStyles;
    public Image currentHairStyle;
    public int hairStyle;

    // Start is called before the first frame update
    void Start()
    {
        hairStyle = 0;
       
    }

    // Update is called once per frame
    void Update()
    {
        switch(hairStyle)
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


    public void OnMouseClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (hairStyle < hairStyles.Length)
            {
                hairStyle += 1;
            }
            if (hairStyle >= hairStyles.Length)
            {
                hairStyle = 0;
            }
        }

    }
}
