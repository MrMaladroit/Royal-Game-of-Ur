using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DiceTotalDisplay : MonoBehaviour
{
    private Text displayTotalText;
    private DiceRoller theDiceRoller;

    void Start()
    {
        displayTotalText = GetComponent<Text>();
        theDiceRoller = FindObjectOfType<DiceRoller>();
    }

    void Update()
    {
        if (theDiceRoller.IsDoneRolling == false)
        {
            displayTotalText.text = "= " + theDiceRoller.DiceTotal;
        }
        else
        {
            displayTotalText.text = "= " + theDiceRoller.DiceTotal;
        }
    }
}