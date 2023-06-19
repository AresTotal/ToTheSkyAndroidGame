using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    private GameObject player;
    private int moveDirection;
    private bool hasToMove = true;
    private float changeSpeed = 0.1f;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        moveDirection = transform.position.x < player.transform.position.x ? 1 : -1;
    }
    private void Update()
    {
        moveSpeed += Time.deltaTime * changeSpeed;
        if (hasToMove)
            transform.position += Vector3.right * moveDirection *  moveSpeed * Time.deltaTime;
    }
    public void StopMovement() => hasToMove = false;
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
