using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionMover : MonoBehaviour
{
    [SerializeField] string triggeringTag;

    public GameObject monsterPrefab;

    [Tooltip("Movement vector in meters per second")]
    [SerializeField] float velocity;

    [Tooltip("Direction vector of the mover")]
    [SerializeField] private Vector3 direction;

    private bool completed = false;
    public bool Completed
    {
        get => completed;
    }
    void Update()
    {
        if (monsterPrefab != null) { 
        monsterPrefab.GetComponent<Animator>().SetInteger("State", 1); 

        monsterPrefab.transform.position += direction * (velocity * Time.deltaTime);
    }
}

    public void SetVelocity(float newVelocity)
    {
        this.velocity = newVelocity;
    }

    public void SetDirection(Vector3 dir)
    {
        this.direction = dir;
    }

   
        private void OnTriggerEnter2D(Collider2D other)
     {
        Debug.Log(other.tag + " other.otherotherotherotherotherotherotherother ");

        if (other.tag == triggeringTag && enabled)
            {
                other.gameObject.SetActive(false);
             completed = true;

        }
    }
    }