using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ChangeMaterialColor : MonoBehaviour
{
    public Color color = Color.white;
    public Image image = null;

    void Start()
    {
        image = GetComponent<Image>();
        image.material = Instantiate(image.material) as Material;
    }


    void LateUpdate()
    {
        image.material.SetColor("_Color", color);
    }
}
