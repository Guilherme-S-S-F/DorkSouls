using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerUI : MonoBehaviour
{
    PlayerController playerController;

    public TextMeshProUGUI dashCooldown_text;

    private void Start()
    {
        playerController = GetComponent<PlayerController>();
    }

    private void Update()
    {
        dashCooldown_text.text = playerController.dashTimer.ToString("F1");
    }
}
