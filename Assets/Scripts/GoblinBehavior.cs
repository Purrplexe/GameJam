using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinBehavior : MonoBehaviour
{
    private bool isCalmed = false;

    public void CalmGoblin()
    {
        if (!isCalmed)
        {
            isCalmed = true;
            Debug.Log("Goblin calmed!");
            Destroy(gameObject); // Remove goblin from the scene
        }
    }

    public void ThrowChaos()
    {
        if (!isCalmed)
        {
            // Add chaos-throwing logic (e.g., instantiate a projectile)
            Debug.Log("Goblin threw chaos!");
        }
    }
}
