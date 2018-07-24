using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DiceTotalDisplay : MonoBehaviour
{
    private Text displayTotalText;
    private DiceRoller theDiceRoller;

    // Use this for initialization
    void Start()
    {
        displayTotalText = GetComponent<Text>();
        theDiceRoller = FindObjectOfType<DiceRoller>();
    }

    // Update is called once per frame
    void Update()
    {
        displayTotalText.text = "= " + theDiceRoller.DiceTotal.ToString();
    }
}
