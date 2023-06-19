using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerController : MonoBehaviour
{
    public UnityEvent Landed;
    public UnityEvent Dead;
    private AudioSource audioSource;
    [SerializeField] private float jumpForce;
    [SerializeField] private ContactFilter2D platform;
    [SerializeField] AudioClip audioClip;

    private Rigidbody2D rb;

    private bool isOnPlatform => rb.IsTouching(platform);

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody2D>();
    }

    public void JumpLogic()
    {
        if (isOnPlatform)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            if(!audioSource.isPlaying)
            {
                audioSource.PlayOneShot(audioClip);
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject collisonObject = collision.gameObject;
        if(collisonObject.transform.parent != null)
        {
            if (collisonObject.transform.parent.TryGetComponent(out Platform platform))
                platform.StopMovement();
        }
        if (collisonObject.CompareTag("Wall_Platform"))
            Dead?.Invoke();
        else if(collisonObject.CompareTag("Platform"))
        {
            collisonObject.tag = "Untagged";
            Landed?.Invoke();
        }

    }
}
