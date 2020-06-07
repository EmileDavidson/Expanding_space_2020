using UnityEngine;

public class ScrapPiece : MonoBehaviour
{
    public int pieceNumber;

    public void Start()
    {
        if (StaticData.scrapPieces.ContainsKey(pieceNumber))
        {
            if (StaticData.scrapPieces[pieceNumber] == true)
            {
                //hij is true dus ik moet iets doen om te laten zien dat hij al een keer is opgepakt.
            }
        }
    }

    public void pickup()
    {
        //zorg dat je zeker weet dat de dictonary je nummer bevat
        if (StaticData.scrapPieces.ContainsKey(pieceNumber))
        {
            StaticData.scrapPieces[pieceNumber] = true;
        }
        Destroy(this.gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            pickup();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            pickup();
        }
    }
}