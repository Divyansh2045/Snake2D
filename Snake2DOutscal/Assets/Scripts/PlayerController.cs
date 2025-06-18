using System;
using System.Collections.Generic;
using System.Linq;
using UnityEditor.Timeline;
using UnityEngine;

public enum Direction
{
    Up,
    Down,
    Left,
    Right
}

public class PlayerController : MonoBehaviour
{
    private Direction currentDirection;
    public float speed;
    public float moveDelay = 0.4f;
    private float moveTimer = 0.0f;
    [SerializeField] List<Vector3> positionHistory = new List<Vector3>();
    List<Quaternion> rotationHistory = new List<Quaternion>();
    public List<GameObject> snakeParts = new List<GameObject>();
    public GameObject snakeBodyPrefab;
    public int stepsBehind;
    bool snakeShield = false;

    private void Awake()
    {
        snakeParts.Add(this.gameObject);
         for (int i = 0; i < 3; i++)
     {
         Vector3 startingPosition = transform.position - new Vector3(0, i + 1, 0);
         GameObject bodySegment = Instantiate(snakeBodyPrefab, startingPosition, Quaternion.identity);
         snakeParts.Add(bodySegment);
     } 

    }

    private void Start()
    {
       // positionHistory.Insert(0,transform.position);
        
       /* for (int i = 0; i < 3; i++)
        {
            Vector3 startingPosition = transform.position - new Vector3(0, i + 1, 0);
            GameObject bodySegment = Instantiate(snakeBodyPrefab, startingPosition, Quaternion.identity);
            snakeParts.Add(bodySegment);
        } */
    }

    private void Update()
    {
        HandleInput();
        MoveCharacter();
    }



    private void HandleInput()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (currentDirection == Direction.Down)
            {
                return;
            }
            currentDirection = Direction.Up;
          
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (currentDirection == Direction.Up)
            {
                return;
            }
            currentDirection = Direction.Down;
         
        }
        else if ( Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (currentDirection == Direction.Right)
            {
                return;
            }
            currentDirection = Direction.Left;
          

        }
        else if (Input.GetKeyDown (KeyCode.RightArrow))
        {
            if (currentDirection == Direction.Left)
            {
                return;
            }
            currentDirection = Direction.Right;
           
        }

    }

    public void growSnake()
    {
        int index = (snakeParts.Count) * stepsBehind;

        Vector3 position;
        Quaternion rotation;
        if (index < positionHistory.Count)
        {
            position = positionHistory[index];
            rotation = rotationHistory[index];
        }
        else
        {
            position = snakeParts[snakeParts.Count - 1].transform.position; // fallback
            rotation = snakeParts[snakeParts.Count - 1].transform.rotation; // fallback rotation
        }

        GameObject newBodySegment = Instantiate(snakeBodyPrefab, position, rotation);
        snakeParts.Add(newBodySegment);

    }

    private void PlayerDie()
    {
        if(snakeShield == true)
        {
            return;
        }

        if (snakeShield == false) 
        {
            Destroy(gameObject);
        }
    }

    public void massBurner()
    {
        if (snakeParts.Count == 0) return;

        GameObject lastSegment = snakeParts[snakeParts.Count - 1];
        snakeParts.RemoveAt(snakeParts.Count - 1);
        Destroy(lastSegment);
    }


    private void MoveCharacter()
    {
        moveTimer += Time.deltaTime;
        if (moveTimer >= moveDelay)
        {
            moveTimer = 0.0f;
            Vector3 moveVector = Vector3.zero;
            //Move Snake
            switch (currentDirection)
            {
                case Direction.Up:
                     moveVector = Vector3.up; 
                    break;
                case Direction.Down:
                    moveVector = Vector3.down;
                    break;
                case Direction.Left:
                    moveVector = Vector3.left;
                    break;
                case Direction.Right:
                    moveVector = Vector3.right;
                    break;
                default:
                    Debug.Log("Player does not move in a path");
                    break;
            }

            transform.position += moveVector * speed;

            switch(currentDirection)
            {
                case Direction.Up:
                    transform.rotation = Quaternion.Euler(0, 0, 0);
                    break;
                case Direction.Down:
                    transform.rotation = Quaternion.Euler(0, 0, -180);
                    break;
                case Direction.Left:
                    transform.rotation = Quaternion.Euler(0, 0, 90);
                    break;
                case Direction.Right:
                    transform.rotation = Quaternion.Euler(0, 0, -90);
                    break;
                
            }
            positionHistory.Insert(0,transform.position);
            rotationHistory.Insert(0,transform.rotation);

            for (int i = 1; i < snakeParts.Count; i++)
            {
                int index = i * stepsBehind;
                //index = Mathf.Min(index, positionHistory.Count - 1);
                if (index < positionHistory.Count)
                {
                    snakeParts[i].transform.position = positionHistory[index];
                    snakeParts[i].transform.rotation = rotationHistory[index];
                }
            }


        }
        
    }
}
