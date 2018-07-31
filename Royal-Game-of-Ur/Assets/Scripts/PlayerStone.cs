using UnityEngine;

public class PlayerStone : MonoBehaviour
{
    private DiceRoller theDiceRoller;
    private Tile currentTile;

    public Tile StartingTile;

    private void Start()
    {
        theDiceRoller = FindObjectOfType<DiceRoller>();
    }

    private void OnMouseUp()
    {
        Debug.Log("CLICK!");

        if (theDiceRoller.IsDoneRolling == false)
        {
            return;
        }

        int spacesToMove = theDiceRoller.DiceTotal;
        Tile finalTile = currentTile;

        for (int i = 0; i < spacesToMove; i++)
        {
            if(finalTile == null)
            {
                finalTile = StartingTile;
            }
            else
            {
                if (finalTile.NextTiles == null || finalTile.NextTiles.Length == 0)
                {
                    Debug.Log("SCORE! ");
                    Destroy(gameObject);
                    return;
                }
                else if(finalTile.NextTiles.Length > 1)
                {
                    finalTile = finalTile.NextTiles[0];
                }
                else
                {
                    finalTile = finalTile.NextTiles[0];
                }
            }
        }

        if(finalTile == null)
        {
            return;
        }

        this.transform.position = finalTile.transform.position;
        currentTile = finalTile;

    }
}