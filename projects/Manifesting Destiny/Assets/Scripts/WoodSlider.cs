using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WoodSlider : ExpansionSlider
{
    void Update()
    {
      inventory = Resources.getWood();
      resourceSlider.maxValue = inventory;

      ExpansionController.wood = resourceAmount;
    }
}