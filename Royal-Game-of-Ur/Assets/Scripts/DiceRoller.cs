using UnityEngine;
using UnityEngine.UI;

public class DiceRoller : MonoBehaviour
{
    [SerializeField]
    private Sprite[] DiceImageOne;
    [SerializeField]
    private Sprite[] DiceImageZero;

    public int[] DiceValues;
    public int DiceTotal;
    public bool IsDoneRolling;

    private void Start()
    {
        DiceValues = new int[4];
    }

    public void NewTurn()
    {
        IsDoneRolling = false;
    }
    public void RollTheDice()
    {
        DiceTotal = 0;

        for (int i = 0; i < DiceValues.Length; i++)
        {
            DiceValues[i] = Random.Range(0, 2);
            DiceTotal += DiceValues[i];

            if(DiceValues[i] == 0)
            {
                this.transform.GetChild(i).GetComponent<Image>().sprite = DiceImageZero[Random.Range(0, DiceImageZero.Length)];
            }
            else
            {
                this.transform.GetChild(i).GetComponent<Image>().sprite = DiceImageOne[Random.Range(0, DiceImageOne.Length)];
            }

            IsDoneRolling = true;
        }
    }
}
