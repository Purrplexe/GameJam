using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PointManager : MonoBehaviour
{
    public TextMeshProUGUI pointsText; // Drag the PointsText object here in the Inspector
    private int points = 0;

    public void AddPoints(int amount)
    {
        points += amount;
        UpdatePointsDisplay();
    }

    public void SubtractPoints(int amount)
    {
        points -= amount;
        if (points < 0) points = 0; // Prevent negative points
        UpdatePointsDisplay();
    }

    private void UpdatePointsDisplay()
    {
        pointsText.text = "Points: " + points;
    }
}
