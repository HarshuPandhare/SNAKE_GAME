using NUnit.Framework;  
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SocialPlatforms.Impl;

public class snake : MonoBehaviour

{
   
    private Vector2 _direction = Vector2.right;

    public List<Transform> _segments;
    public Transform prefabSegment;
    public int initialSize = 5;
    public GameObject gameOverPanel;

    private void Start()
    {
        _segments = new List<Transform>();
        _segments.Add(this.transform);
        Reset();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) && _direction != Vector2.down)
        {
            _direction = Vector2.up;
        }
        else if (Input.GetKeyDown(KeyCode.S) && _direction != Vector2.up)
        {
            _direction = Vector2.down;
        }
        else if (Input.GetKeyDown(KeyCode.D) && _direction != Vector2.left)
        {
            _direction = Vector2.right;
        }
        else if (Input.GetKeyDown(KeyCode.A) && _direction != Vector2.right)
        {
            _direction = Vector2.left;
        }
    }
    public void grow()
    {
        FindFirstObjectByType<gamescore>().AddScore();

        Transform segment = Instantiate(this.prefabSegment);
        segment.position = _segments[_segments.Count - 1].position;
        _segments.Add(segment);
    }



    public void Reset()
    {
        gamescore score = FindAnyObjectByType<gamescore>();

        if (score != null)
        {
            score.ResetScore();
        }

        for (int i = 1; i < _segments.Count; i++)
        {
            Destroy(_segments[i].gameObject);
        }
        _segments.Clear();
        _segments.Add(this.transform);
        for(int i = 1; i < initialSize; i++)
        {
            _segments.Add(Instantiate(this.prefabSegment));
        }
        this.transform.position = Vector3.zero;

    }



    


    

    private void FixedUpdate()
    {
        for (int i = _segments.Count - 1; i > 0; i--)
        {
            _segments[i].position = _segments[i - 1].position;
        }
        this.transform.position = new Vector3(Mathf.Round(this.transform.position.x + _direction.x), Mathf.Round(this.transform.position.y + _direction.y), Mathf.Round(0f));
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Food")
        {
            grow();
        }
        if(collision.tag == "Respawn")
        {

            FindFirstObjectByType<GameManager>().GameOver();
        }
    }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
}
