using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticData
{
    /*
     Een class met daarin static data dat wij kunnen opvragen (over de scenes heen)
     dit zodat we dit niet kwijtraken wanneer je van scene switched
     */
    public static bool setupGeweest = false;
    public static int scrapPiecesAmount = 0;
    public static Dictionary<int, bool> scrapPieces = new Dictionary<int, bool>();

    public static void setup()
    {
        if (setupGeweest == false)
        {
            for (int i = 0; i < scrapPiecesAmount; i++)
            {
                scrapPieces.Add(i, false);
            }

            Debug.Log(scrapPieces);
            setupGeweest = true;
        }
    }
}