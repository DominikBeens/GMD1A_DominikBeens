using UnityEngine;
using System.Collections;

public class ShootableBox : MonoBehaviour
{

    public int currentHealth = 3;

    public Vector3 start;
    public Vector3 turn;
    public float secondsForHalfLoop = 5f;
    public GameObject box;

    public void Damage(int damageAmount)
    {
        currentHealth -= damageAmount;
        if (currentHealth <= 0)
        {
            gameObject.SetActive(false);
        }
    }

    void Start()
    {
        start = transform.position;
    }

    void Update()
    {
        transform.position = Vector3.Lerp(start, turn, Mathf.SmoothStep(0f, 1f, Mathf.PingPong(Time.time / secondsForHalfLoop, 1f)));
    }

}