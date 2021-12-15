/*
 * Program Header: UI Controller
 * Robert Wymer - 101070567
 * Last Date Modified - Dec 15, 2021
 * Version 1.0
 * 
 * Handles UI for Win/Lose Conditions of the Game 
 * Also had functions for Virtual Jump Button
 * 
 * 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIController : MonoBehaviour
{
    [Header("UI Elements")]
    public GameObject losePanel;
    public GameObject winPanel;

    public TextMeshProUGUI coinNumText;
    public TextMeshProUGUI scoreNumText;

    [Header("Button Control Events")]
    public static bool jumpButtonDown;

    private PlayerController player;
    public GameObject endDoor;

    private void Start()
    {
        player = FindObjectOfType<PlayerController>();
    }

    private void Update()
    {
        if (player.isDead)
        {
            losePanel.SetActive(true);
            player.gameObject.SetActive(false);
        }
        else if (endDoor.GetComponent<DoorController>().levelComplete)
        {
            winPanel.SetActive(true);

            coinNumText.text = player.GetCoins().ToString();
            scoreNumText.text = player.GetScore().ToString();

            player.gameObject.SetActive(false);
        }
    }

    public void OnJumpButton_Down()
    {
        jumpButtonDown = true;
    }

    public void OnJumpButton_Up()
    {
        jumpButtonDown = false;
    }
}
