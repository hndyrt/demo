using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class Complete : MonoBehaviour
{
    [Header("Game Completion UI")]
    public GameObject gameCompletionUI; // Giao diện hiển thị khi hoàn thành game

    [Header("Total Pumpkins to Collect")]
    public int totalPumpkins = 5; // Số lượng Pumpkin cần thu thập

    private int collectedPumpkins = 0; // Biến đếm số Pumpkin đã thu thập

    
    // Hiển thị màn hình hoàn thành game
    private void CompleteGame()
    {
        if (gameCompletionUI != null)
        {
            gameCompletionUI.SetActive(true); // Hiển thị giao diện hoàn thành game
        }

        // (Tùy chọn) Tạm dừng game
        Time.timeScale = 0f;
        Debug.Log("Game Completed!");
    }
}
