using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    TestStats stats = new TestStats();

    private void Start()
    {
        stats.currentHealth = 100;
    }
}
