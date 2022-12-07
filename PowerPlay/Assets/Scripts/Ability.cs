using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ability : MonoBehaviour
{
    private Transform transform;
    private Rigidbody rigidbody;

    public Transform player1Transform;
    public Rigidbody player1Rigidbody;

    public Transform player2Transform;
    public Rigidbody player2Rigidbody;

    private float max_y;

    // Start is called before the first frame update
    void Start()
    {
        transform = GetComponent<Transform>(); 
        rigidbody = GetComponent<Rigidbody>();

        max_y = transform.position.y;

        transform.position = new Vector3(transform.position.x, 
            transform.position.y - Random.Range(30, 200), transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        float degree = 60.0f * Time.deltaTime;
        transform.Rotate(degree, degree, degree);

        if (transform.position.y < max_y)
        {
            rigidbody.velocity = new Vector3(0, Random.Range(0.0f, 5.0f), 0);
        } else {
            rigidbody.velocity = Vector3.zero;
        } 
    }

    void OnTriggerEnter(Collider target) {
        if (target.tag == "Player1" || target.tag == "Player2") {
            transform.position = new Vector3(transform.position.x, 
                transform.position.y - Random.Range(100, 400), transform.position.z);

            if (target.tag == "Player1") {
                useAbility(player1Transform, player1Rigidbody);
            } else {
                useAbility(player2Transform, player2Rigidbody);
            }
        }
    }

    void useAbility(Transform playerTransform, Rigidbody playerRigidbody) {
        if (gameObject.tag == "ability_mass") {
            playerRigidbody.mass -= .5f; 
        } else if (gameObject.tag == "ability_speed") {
            playerRigidbody.drag = 3;
        } else {
            playerTransform.localScale += new Vector3(.5f, 0, .5f); 
        }
    }
}
