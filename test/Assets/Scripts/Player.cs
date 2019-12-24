using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {

    private Vector2 targetPos;
    public float Yincrement;
    public float speed;
    public float maxHeight;
    public float minHeight;
    public GameObject effect;

    public int health = 3;

    private Animator camAnim;
  
    void Start() {
        camAnim = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Animator>();
    }
    
     // Update is called once per frame
    private void Update()
    {

        if (health <= 0) {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        transform.position = Vector2.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.UpArrow) && (transform.position.y == minHeight || transform.position.y == 0))
        {
            camAnim.SetTrigger("Shake");
            Instantiate(effect, transform.position, Quaternion.identity);
            targetPos = new Vector2(transform.position.x, transform.position.y + Yincrement);
            
        } else if (Input.GetKeyDown(KeyCode.DownArrow) && (transform.position.y == maxHeight || transform.position.y == 0)) {
            camAnim.SetTrigger("Shake");
            Instantiate(effect, transform.position, Quaternion.identity);
            targetPos = new Vector2(transform.position.x, transform.position.y - Yincrement);
        }
    }
}
