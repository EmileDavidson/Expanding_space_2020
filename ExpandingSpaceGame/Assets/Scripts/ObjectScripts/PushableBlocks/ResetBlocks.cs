using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetBlocks : MonoBehaviour
{
    public GameObject[] blocks;
    public Vector3[] blocksOldPositions;

    private void Start()
    {
        blocksOldPositions = new Vector3[blocks.Length];
        for (int i = 0; i < blocks.Length; i++)
        {
            blocksOldPositions[i] = blocks[i].transform.position;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        for (int i = 0; i < blocks.Length; i++)
        {
            blocks[i].transform.position = blocksOldPositions[i];
        }
    }
}