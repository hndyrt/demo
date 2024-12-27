using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class BirdSpawner : MonoBehaviour
{
    public GameObject birdPrefab; // Prefab của con chim
    public int numberOfBirds = 5; // Số lượng chim để spawn
    public float spawnAreaWidth = 10f; // Độ rộng của khu vực spawn
    public float spawnAreaHeight = 5f; // Chiều cao của khu vực spawn

    void Start()
    {
        // Đảm bảo SpawnBirds được gọi khi game bắt đầu
        SpawnBirds();
    }

    void SpawnBirds()
    {
        // Tạo chim ngẫu nhiên
        for (int i = 0; i < numberOfBirds; i++)
        {
            // Tạo vị trí ngẫu nhiên trong khu vực spawn
            float randomX = Random.Range(-spawnAreaWidth / 2, spawnAreaWidth / 2);
            float randomY = Random.Range(-spawnAreaHeight / 2, spawnAreaHeight / 2);
            Vector2 spawnPosition = new Vector2(randomX, randomY);

            // In vị trí spawn ra Console
            Debug.Log("Spawn Position: " + spawnPosition);

            // Tạo con chim tại vị trí ngẫu nhiên
            Instantiate(birdPrefab, spawnPosition, Quaternion.identity);
        }
    }

    // Vẽ khu vực spawn trong Scene view
    private void OnDrawGizmos()
    {
        // Đảm bảo Gizmos được hiển thị
        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(Vector3.zero, new Vector3(spawnAreaWidth, spawnAreaHeight, 0));
    }
}