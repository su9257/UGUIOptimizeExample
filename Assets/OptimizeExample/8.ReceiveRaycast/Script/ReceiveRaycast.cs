using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReceiveRaycast : MonoBehaviour
{
   
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(() => { Debug.Log("菜鸟海澜"); });
    }

}
