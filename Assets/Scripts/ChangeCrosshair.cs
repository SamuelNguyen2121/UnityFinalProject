using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeCrosshair : MonoBehaviour
{
    [SerializeField]
    Image currentCrosshair;

    [SerializeField]
    Sprite newCrosshair;

    public void OnMouseDown()
    {
        //Change the crosshair to the one selected
        currentCrosshair.GetComponent<Image>().sprite = newCrosshair;
    }


}
