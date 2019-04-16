using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Example9 : MonoBehaviour
{
    public Button button = null;
    // Use this for initialization
    void Start()
    {
        button.onClick.AddListener(() => { Debug.Log("This is Example9"); });
    }

    // Update is called once per frame
    void Update()
    {

    }
}
