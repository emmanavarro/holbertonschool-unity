using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float speed = 30f;
    public int health = 5;
    public Text scoreText;
    public Text healthText;
    public Text winLoseText;
    public Image winLoseBG;

    private Rigidbody rb;
    private float movementX;
    private float movementY;
    private int score = 0;

    // Start is called before the first frame update
    void Start()
    {
        // Sets the value of rb by getting a reference to the Rigidbody component
        // attached to the Player GameObject component
        rb = GetComponent<Rigidbody>();
    }

    // Predefined function for the changes in movement controls
    void OnMove(InputValue movementValue)
    {
        // Stores the input data as a vector
        Vector2 movementVector = movementValue.Get<Vector2>();

        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    // It is called just before performing any physics calculations
    void FixedUpdate()
    {
        //Store user input as a movement vector
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);

        //Apply the movement vector to the current position, which is
        //multiplied by deltaTime and speed for a smooth MovePosition
        // rb.MovePosition(rb.position + movement * speed * Time.deltaTime);

        rb.AddForce(movement * speed);
    }

    // Increment the value of score when the Player touches an object tagged Pickup
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pickup"))
        {
            score += 1;
            SetScoreText();
            other.gameObject.SetActive(false);
        }
        if (other.gameObject.CompareTag("Trap"))
        {
            health -= 1;
            // Debug.Log($"Health: {health}");
            SetHealthText();
        }
        if (other.gameObject.CompareTag("Goal"))
        {
            // Debug.Log("You win!");
            winLoseText.color = Color.black;
            winLoseText.text = "You Win!";
            winLoseBG.color =  Color.green;
            winLoseBG.gameObject.SetActive(true);
            StartCoroutine(LoadScene(2)); // the scene waits 2 seconds to reload
        }
    }

    void Update()
    {
        if (health == 0)
        {
            // Debug.Log("Game Over!");
            winLoseText.color = Color.white;
            winLoseText.text = "Game Over!";
            winLoseBG.color =  Color.red;
            winLoseBG.gameObject.SetActive(true);
            StartCoroutine(LoadScene(2));
        }

        if (Input.GetKey(KeyCode.Escape))
        {
            SceneManager.LoadScene(0);      // Load the main menu
        }
    }

    void SetScoreText()
    {
        scoreText.text = $"Score: {score.ToString()}";
    }

    void SetHealthText()
    {
        healthText.text = $"Health: {health.ToString()}";
    }

    IEnumerator LoadScene(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        SceneManager.LoadScene("maze");
    }
}
