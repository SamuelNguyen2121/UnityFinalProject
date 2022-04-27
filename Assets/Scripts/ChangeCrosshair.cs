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

    // Start is called before the first frame update
    public void OnMouseDown()
    {
        currentCrosshair.GetComponent<Image>().sprite = newCrosshair;
    }


}
