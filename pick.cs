using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class pick : MonoBehaviour
{
    public GameObject pumkin; 
    public int numberOfpumkin= 1; 
    public float spawnAreaWidth = 1f; // Width of the spawn area
    public float spawnAreaHeight = 1f; // Height of the spawn area

    void Start()
    {
        Spawnpumkins();
    }

    void Spawnpumkins()
    {
        for (int i = 0; i < numberOfpumkin; i++)
        {
            // Generate a random position within the spawn area
            float randomX = Random.Range(-spawnAreaWidth / 1, spawnAreaWidth / 1);
            float randomY = Random.Range(-spawnAreaHeight / 1, spawnAreaHeight / 1);
            Vector2 spawnPosition = new Vector2(randomX, randomY);

            // Instantiate the bird at the random position
            Instantiate(pumkin, spawnPosition, Quaternion.identity);
        }
    }

    // Optional: Draw the spawn area in the Scene view
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(Vector3.zero, new Vector3(spawnAreaWidth, spawnAreaHeight, 0));
    }
}