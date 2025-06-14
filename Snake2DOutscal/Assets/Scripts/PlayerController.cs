using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
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
    public List<Vector3> positionHistory = new List<Vector3>();
    List<Quaternion> rotationHistory = new List<Quaternion>();
    List<GameObject> snakeParts = new List<GameObject>();
    public GameObject snakeBodyPrefab;
    public int stepsBehind;

    private void Update()
    {
        HandleInput();
        MoveCharacter();
    }

    private void Start()
    {
        snakeParts.Add(this.gameObject);
        for (int i = 0; i < 3; i++)
        {
            Vector3 startingPosition = transform.position - new Vector3(0, i + 1, 0);
            GameObject bodySegment = Instantiate(snakeBodyPrefab, startingPosition, Quaternion.identity);
            snakeParts.Add(bodySegment);
        }
       
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
            transform.rotation = Quaternion.Euler(0,0,0);
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (currentDirection == Direction.Up)
            {
                return;
            }
            currentDirection = Direction.Down;
            transform.rotation = Quaternion.Euler(0, 0, -180);
        }
        else if ( Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (currentDirection == Direction.Right)
            {
                return;
            }
            currentDirection = Direction.Left;
            transform.rotation = Quaternion.Euler(0, 0, 90);

        }
        else if (Input.GetKeyDown (KeyCode.RightArrow))
        {
            if (currentDirection == Direction.Left)
            {
                return;
            }
            currentDirection = Direction.Right;
            transform.rotation = Quaternion.Euler(0, 0, -90f);
        }

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
            positionHistory.Insert(0,transform.position);
            rotationHistory.Insert(0,transform.rotation);

            for (int i = 0; i < snakeParts.Count; i++)
            {
                int index = (i+1) * stepsBehind;
                if(index < positionHistory.Count)
                {
                    snakeParts[i+1].transform.position = positionHistory[index];
                    snakeParts[i+1].transform.rotation = rotationHistory[index];
                }
            }


        }
        
    }
}
