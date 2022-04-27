using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChagneCrosshairCol : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    Color crosshairColor;

    [SerializeField]
    Image crossHair;

    public void ChangeCrosshairColor()
    {
       crossHair.GetComponent<Image>().color = crosshairColor;
        Debug.Log(crosshairColor);
    }
}
