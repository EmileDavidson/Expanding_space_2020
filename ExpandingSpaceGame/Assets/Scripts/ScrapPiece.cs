using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrapPiece : MonoBehaviour
{
    public int pieceNum = -999;

    public void Start()
    {
        /*
        zorg dat wanneer het stuk al is opgepakt hij het niet nog een keer laat zien!
        het object moet dus echt weg blijven!
         */

        //wanneer hij nog geen echte nummer heeft gekregen return ik hem
        //anders krijgen we een error "not found"
        if (pieceNum == -999)
        {
            return;
        }
        if (pieceNum == 1)
        {
            if (StaticData.scrapPiece1 == true)
            {
                this.gameObject.SetActive(false);
            }
        }

        if (pieceNum == 2)
        {
            if (StaticData.scrapPiece2 == true)
            {
                this.gameObject.SetActive(false);
            }
        }

        if (pieceNum == 3)
        {
            if (StaticData.scrapPiece3 == true)
            {
                this.gameObject.SetActive(false);
            }
        }

        if (pieceNum == 4)
        {
            if (StaticData.scrapPiece4 == true)
            {
                this.gameObject.SetActive(false);
            }
        }

        if (pieceNum == 5)
        {
            if (StaticData.scrapPiece5 == true)
            {
                this.gameObject.SetActive(false);
            }
        }

        if (pieceNum == 6)
        {
            if (StaticData.scrapPiece6 == true)
            {
                this.gameObject.SetActive(false);
            }
        }

        if (pieceNum == 7)
        {
            if (StaticData.scrapPiece7 == true)
            {
                this.gameObject.SetActive(false);
            }
        }
    }

    public void pickup()
    {
        //wanneer hij nog geen echte nummer heeft gekregen return ik hem
        //anders krijgen we een error "not found"
        if (pieceNum == -999)
        {
            return;
        }
        if (pieceNum == 1)
        {
            StaticData.scrapPiece1 = true;
        }

        if (pieceNum == 2)
        {
            StaticData.scrapPiece2 = true;
        }

        if (pieceNum == 3)
        {
            StaticData.scrapPiece3 = true;
        }

        if (pieceNum == 4)
        {
            StaticData.scrapPiece4 = true;
        }

        if (pieceNum == 5)
        {
            StaticData.scrapPiece5 = true;
        }

        if (pieceNum == 6)
        {
            StaticData.scrapPiece6 = true;
        }

        if (pieceNum == 7)
        {
            StaticData.scrapPiece7 = true;
        }

        if (pieceNum == 1)
        {
            StaticData.scrapPiece1 = true;
        }
    }
}