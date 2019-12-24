using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour {
    public int damage = 1;
    public float Speed;
    public GameObject effect;
    private Animator camAnim;

    void Start() {
        camAnim = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Animator>();
    }
    private void Update() {
        transform.Translate(Vector2.left * Speed * Time.deltaTime);
    }
    void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player")) {
            camAnim.SetTrigger("Shake");
            Instantiate(effect, transform.position, Quaternion.identity);

            // Player takes damage
            other.GetComponent<Player>().health -= damage;
            Debug.Log(other.GetComponent<Player>().health);
            Destroy(gameObject);
        }
    }
}