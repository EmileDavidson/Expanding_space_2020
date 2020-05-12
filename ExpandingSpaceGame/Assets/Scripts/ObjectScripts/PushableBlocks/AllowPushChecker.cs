using UnityEngine;

public class AllowPushChecker : MonoBehaviour
{
    private bool canMove = true;

    //wanneer dit object met iets collide wat niet gelijk is aan de player
    //dan zet hij canmove naar false
    private void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.tag.Equals("Player"))
        {
            canMove = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.gameObject.tag.Equals("Player"))
        {
            canMove = true;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (!other.gameObject.tag.Equals("Player"))
        {
            canMove = false;
        }
    }

    public bool getCanMove()
    {
        return this.canMove;
    }
}