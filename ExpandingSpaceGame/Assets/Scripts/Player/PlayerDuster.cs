using UnityEngine;

public class PlayerDuster : MonoBehaviour
{
    public ParticleSystem dusterAirParticle;

    private void Update()
    {
        //wanneer moet ik de particle wel laten zien en wanneer niet
        if (Input.GetKey(KeyCode.Mouse0))
        {
            dusterAirParticle.Emit(1);
        }
    }

    public void OnCollisionStay(Collision collision)
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            if (collision.gameObject.tag == "ScrapPiece")
            {
                collision.gameObject.GetComponent<ScrapPiece>().pickup();
            }
        }
    }
}