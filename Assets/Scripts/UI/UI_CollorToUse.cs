using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_CollorToUse : MonoBehaviour
{
    [SerializeField] private Image colorVis;
    [SerializeField] private Text colorName;

    public void Init(Color color, int i)
    {
        colorVis.color = color;
        colorName.text = "Color " + i;
    }
}
