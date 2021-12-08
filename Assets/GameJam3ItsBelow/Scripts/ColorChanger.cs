using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Random = UnityEngine.Random;


public class ColorChanger : MonoBehaviour
{
    [SerializeField]public List<Color> TintColors;

    private void OnEnable()
    {
        Color c = TintColors[Random.Range(0, TintColors.Count)];

        GetComponent<Renderer>().material.color = c;
    }
}
