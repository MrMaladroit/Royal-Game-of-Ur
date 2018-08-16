using UnityEngine;

public class PlayerStone : MonoBehaviour
{
    private DiceRoller theDiceRoller;
    private Tile currentTile;
    private Vector3 targetPosition;
    private Vector3 velocity;
    private float smoothTime = 0.25f;

    public Tile StartingTile;

    private void Start()
    {
        theDiceRoller = FindObjectOfType<DiceRoller>();
        targetPosition = this.transform.position;
    }

    private void Update()
    {
        if(this.transform.position != targetPosition)
        {
            this.transform.position = Vector3.SmoothDamp(this.transform.position, targetPosition, ref velocity, smoothTime);
        }
    }

    private void SetNewTargetPosition(Vector3 position)
    {
        targetPosition = position;
        velocity = Vector3.zero;
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

        SetNewTargetPosition(finalTile.transform.position);
        currentTile = finalTile;

    }
}