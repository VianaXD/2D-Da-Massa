using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InterfaceControl : MonoBehaviour
{
    public Slider SliderCollections;

    public int TotalCollections = 10;

    private PlayerController scriptPlayerController;
    // Start is called before the first frame update
    void Start()
    {
        SliderCollections.maxValue = TotalCollections;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void UpdateSliderCollections()
    {
        SliderCollections.value = scriptPlayerController.Collections;
    }
}
