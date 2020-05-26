using UnityEngine;

public class AllowPushChecker : MonoBehaviour
{
    private bool canMove = true;

    //wanneer dit object met iets collide wat niet gelijk is aan de player
    //dan zet hij canmove naar false
    private void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.tag.Equals("Player") && !other.gameObject.tag.Equals("PressurePlate"))
        {
            canMove = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        print(other.gameObject.name);
        print(other.gameObject.tag);
        if (!other.gameObject.tag.Equals("Player") || !other.gameObject.tag.Equals("PressurePlate"))
        {
            canMove = true;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (!other.gameObject.tag.Equals("Player") && !other.gameObject.tag.Equals("PressurePlate"))
        {
            canMove = false;
        }
    }

    public bool getCanMove()
    {
        return this.canMove;
    }
}