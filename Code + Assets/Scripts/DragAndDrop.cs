using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Collider2D))]

public class DragAndDrop : MonoBehaviour
{
    private bool isDragging = false;
    private bool hasBeenDragged = false;
    private Rigidbody2D rb2D;
    private Vector2 originalPosition;
    private string timetocheck = "n";
    private bool isDraggable = true;

    private SFXManager sfxManager;
    public ScoreManager scoreManager;
    public GameOverScreen GameOverScreen;

    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        originalPosition = transform.position;

        sfxManager = FindObjectOfType<SFXManager>();
        scoreManager = FindObjectOfType<ScoreManager>();
        GameOverScreen = FindObjectOfType<GameOverScreen>();

    }

    void Update()
    {
        if (isDragging)
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector2(mousePosition.x, originalPosition.y); // Use transform.position to set the position
        }
    }

    public void OnMouseDown()
    {
        if (Merge.spawnedYet == "y")
        {
            Merge.spawnedYet = "n";
        }

        if (!hasBeenDragged && isDraggable)
        {
            isDragging = true;
        }
    }

    private IEnumerator HandleMouseUp()
    {
        yield return new WaitForSeconds(0.15f);
        hasBeenDragged = true;
        rb2D.bodyType = RigidbodyType2D.Dynamic;
    }
    
    public void OnMouseUp()
    {
        if (isDragging)
        {
            isDragging = false;
            StartCoroutine(HandleMouseUp());
            StartCoroutine(chkGameOver());
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (gameObject.tag == "9" || collision.gameObject.tag == "9")
        {
            return;
        }
        
        if (collision.gameObject.tag==gameObject.tag)
        {
            Merge.spawnPos = transform.position;
            Merge.newKue = "y";
            Merge.whichKue = int.Parse(gameObject.tag);
            Destroy(gameObject);
            scoreManager.AddPoint(collision.gameObject.tag);
            sfxManager.audioSource.PlayOneShot(sfxManager.click);
        }
    }

    public void SetDraggable(bool draggable)
    {
        isDraggable = draggable;
    }

    IEnumerator chkGameOver()
    {
        yield return new WaitForSeconds(5.0f);
        timetocheck = "y";
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if ((other.gameObject.name == "limit") && (timetocheck == "y"))
        {
            Debug.Log("game over");
            GameOverScreen.Setup();
        }
    }
}