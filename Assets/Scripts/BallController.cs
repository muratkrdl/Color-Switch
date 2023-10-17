using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class BallController : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;

    [SerializeField] string currentColor;

    [SerializeField] Color blueColor;
    [SerializeField] Color yellowColor;
    [SerializeField] Color purpleColor;
    [SerializeField] Color pinkColor;

    [SerializeField] float jumpForce = 1000f;

    [SerializeField] Rigidbody2D myRigid;
    [SerializeField] SpriteRenderer spriteRenderer;

    Vector3 currentSpawnPoint;
    int score;

    void Start() 
    {
        score = -1;
        UpdateScoreText();
    }

    public void Jump()
    {
        myRigid.AddForce(new Vector2(0f, jumpForce * Time.fixedDeltaTime));
    }

    void ChangeColor()
    {
        int randomIndex = Random.Range(1,5);

        if(randomIndex == 1)
        {
            spriteRenderer.color = blueColor; 
            currentColor = "Blue";
        }
        else if(randomIndex == 2)
        {
            spriteRenderer.color = yellowColor;
            currentColor = "Yellow";
        }
        else if(randomIndex == 3)
        {
            spriteRenderer.color = purpleColor;
            currentColor = "Purple";
        }
        else if(randomIndex == 4)
        {
            spriteRenderer.color = pinkColor;
            currentColor = "Pink";
        }
    }

    void ChangeTag()
    {
        if(spriteRenderer.color == blueColor)
            gameObject.tag = "Blue";
        else if(spriteRenderer.color == yellowColor)
            gameObject.tag = "Yellow";
        else if(spriteRenderer.color == purpleColor)
            gameObject.tag = "Purple";
        else if(spriteRenderer.color == pinkColor)
            gameObject.tag = "Pink";
    }
    
    void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.gameObject.CompareTag("SpawnPoint"))
        {
            UpdateScoreText();
            ChangeColor();
            ChangeTag();
            Destroy(other.gameObject);
            return;
        }

        if(other.gameObject.tag != currentColor)
        {
            Debug.Log("Game Over !");

            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    void UpdateScoreText()
    {
        score++;
        scoreText.text = score.ToString();
    }

}
