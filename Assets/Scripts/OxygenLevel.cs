using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Responsible for updating the oxygen bar value by taking information from the OxygenManager.
// Updates the colour of the oxygen bar according to the remaining oxygen.
public class OxygenLevel : MonoBehaviour
{
    public Slider oxygenBar;
    public Text oxygenText;
    public PlayerOxygenManager playerOxygen;

    void Start()
    {
        Color lightBlue = new Color(0.3f, 0.4f, 0.6f); 
    }

    void Update()
    {
        oxygenBar.maxValue = playerOxygen.playerMaxOxygen;
        oxygenBar.value = playerOxygen.playerCurrentOxygen;

        double warning1Value;
        double warning2Value;

        //calculate the oxygen values at which the player gets warnings about oxygen running out 
        //first warning is at 20% of maximum oxygen level; the second one is at 10% of maxium oxygen level 
        warning1Value = 0.2 * playerOxygen.playerMaxOxygen;
        warning2Value = 0.1 * playerOxygen.playerMaxOxygen;

        // changes the colour of the oxygen bar according to the remaining oxygen.
        if (oxygenBar.value <= warning1Value & oxygenBar.value > warning2Value)
        {
            oxygenBar.transform.Find("Fill Area").Find("Fill").GetComponent<Image>().color = Color.yellow;
        }
        else if (oxygenBar.value <= warning2Value)
        {
            oxygenBar.transform.Find("Fill Area").Find("Fill").GetComponent<Image>().color = Color.red;
        }
        else
        {
            oxygenBar.transform.Find("Fill Area").Find("Fill").GetComponent<Image>().color = new Color32(82, 231, 245,255);

        }

    }

}
