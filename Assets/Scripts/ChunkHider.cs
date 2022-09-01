using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChunkHider : MonoBehaviour
{
    private Terrain[] chunks;

    public float visibleDistance;
    public int chunkSize;
    public float checkRate;

    private void Start()
    {
        chunks = FindObjectsOfType<Terrain>();

        InvokeRepeating("CheckChunks", 0f, checkRate);
    }

    void CheckChunks()
    {
        Vector3 playerPos = transform.position;
        playerPos.y = 0f;

        foreach(Terrain chunk in chunks)
        {
            Vector3 chunkCenterPos = chunk.transform.position + new Vector3(chunkSize / 2, 0f, chunkSize / 2);

            if (Vector3.Distance(playerPos, chunkCenterPos) > visibleDistance)
            {
                chunk.gameObject.SetActive(false);
            }
            else
            {
                chunk.gameObject.SetActive(true);
            }
        }
    }
}
