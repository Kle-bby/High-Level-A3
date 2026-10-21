using System.Collections.Generic;
using UnityEngine;

public class PSwitch : Pickup
{
    public BoxCollider2D topTrigger;
    protected new Rigidbody2D rigidbody;
    private Animator animator;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        topTrigger = GetComponent<BoxCollider2D>();
        animator = GetComponent<Animator>();
        pickupType = EPickupType.PSwitch;
    }

    // Update is called once per frame


    protected override void OnPickupActive()
    {
        base.OnPickupActive();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (pickupState == EPickupState.Active)
        {
            if (collision.gameObject.CompareTag("Mario"))
            {
                List<Collider2D> results = new List<Collider2D>();
                collision.Overlap(ContactFilter2D.noFilter, results);

                if (results.Contains(topTrigger))
                {
                    topTrigger.enabled = false;
                    animator.Play("PSwitchPressed");
                    Game.Instance.PSwitchEffect();
                }
            }
        }
    }

}
