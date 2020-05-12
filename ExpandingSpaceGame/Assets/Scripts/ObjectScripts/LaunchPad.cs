using UnityEngine;

public class LaunchPad : MonoBehaviour
{
    public float jumpPower = 10f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Player"))
        {
            //zet de Y velocity van de speler naar jumpPower dit zorgt dat hij de lucht in geschoten word!
            other.gameObject.GetComponent<PlayerMovement>().moveDirection.y = jumpPower;
            //zorg dat charactercontroller de speler moved met de juiste movedirection dit zorgt ervoor dat hij word geupdate! als je dit niet doet
            //gebeurd er ook niks
            other.gameObject.GetComponent<PlayerMovement>().controller.Move(other.gameObject.GetComponent<PlayerMovement>().moveDirection * Time.deltaTime);
        }
    }
}