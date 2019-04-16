using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.UI.Dropdown;

public class Controls : MonoBehaviour
{

    public Text text = null;

    public Slider slider = null;

    public Toggle toggle =  null;

    public Dropdown dropdown = null;

    public InputField inputField = null;

    public Button button = null;

    public ScrollRect scrollRect = null;

    void Start()
    {
        //Debug.Log(dropdown.options.Count);
        //Debug.Log(dropdown.options[0].text);
        InitializedUGUI();
    }


    public void InitializedUGUI()
    {
        //https://www.jianshu.com/p/cfc496244ec4
        text.text = "<color=#ffff00ff><b>爱生活</b></color> <size=20><color=#00ffffff><b><i> 爱海澜</i></b></color></size>";

        slider.onValueChanged.AddListener(SliderOnValueChanged);

        toggle.onValueChanged.AddListener(ToggleOnValueChanged);

        OptionData optionData0 = new OptionData("爱生活");
        OptionData optionData1 = new OptionData("爱海澜");
        OptionData optionData2 = new OptionData("Hello");
        OptionData optionData3 = new OptionData("World");
        dropdown.options.Add(optionData0);
        dropdown.options.Add(optionData1);
        dropdown.options.Add(optionData2);
        dropdown.options.Add(optionData3);
        dropdown.captionText.text = "默认";
    }

    public void SliderOnValueChanged(float value)
    {
        Debug.Log(value);
    }
    public void ToggleOnValueChanged(bool value)
    {
        Debug.Log($"{value}");
    }


}
