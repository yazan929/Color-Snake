using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class SnakeMovement : MonoBehaviour
{
    public GameObject[] walls;

    public GameObject SnakeHerself;
    public GameObject GoalColor;
    public bool alive=true;
    public GameObject loseMenu;
    public static int difOption = 2;
    public float timeSpeed = 0.07f;
    private Vector2 direction = Vector2.right;
    private List<Transform> segments;
    public Transform segmentPrefab;
    public bool menu;
    void Start()
    {
        if(difOption== 1){
            timeSpeed =0.1f;
        }
        if(difOption== 2){
            timeSpeed =0.07f;
        }
        if(difOption== 3){
            timeSpeed =0.04f;
        }
        if(menu){
            timeSpeed=0.07f;
        }
        segments = new List<Transform>();
        segments.Add(this.transform);
        if (menu)
        {
            StartCoroutine(Turn());

        }



        Debug.Log("movement number "+ difOption);

    }

    void Update()
    {
        if (!menu && alive)
        {

            if (Input.GetKeyDown(KeyCode.W)|| Input.GetKeyDown(KeyCode.UpArrow))
            {
                if (direction != Vector2.down)
                {
                    direction = Vector2.up;
                }
            }
            else if (Input.GetKeyDown(KeyCode.S)|| Input.GetKeyDown(KeyCode.DownArrow))
            {
                if (direction != Vector2.up)
                {
                    direction = Vector2.down;
                }
            }
            else if (Input.GetKeyDown(KeyCode.A)|| Input.GetKeyDown(KeyCode.LeftArrow))
            {
                if (direction != Vector2.right)
                {
                    direction = Vector2.left;
                }
            }
            else if (Input.GetKeyDown(KeyCode.D)|| Input.GetKeyDown(KeyCode.RightArrow))
            {
                if (direction != Vector2.left)
                {
                    direction = Vector2.right;
                }
            }

        }

        if (Input.GetKey("escape"))
        {
        SceneManager.LoadScene("SnakeMenu");
        }



    }
    IEnumerator Turn()
    {
        while(menu){
        yield return new WaitForSeconds(2.5f);
        direction = Vector2.down;
        yield return new WaitForSeconds(0.5f);
        direction = Vector2.left;
        yield return new WaitForSeconds(2.5f);
        direction = Vector2.up;
        yield return new WaitForSeconds(0.5f);
        direction = Vector2.right;
        }


    }


    private void FixedUpdate()
    {

        for (int i = segments.Count - 1; i > 0; i--)
        {
            segments[i].position = segments[i - 1].position;
        }

        Time.fixedDeltaTime = timeSpeed;

        this.transform.position = new Vector3(
            Mathf.Round(this.transform.position.x + direction.x),
            Mathf.Round(this.transform.position.y + direction.y),
            0.0f
        );
    }

    private void Grow()
    {
        Transform segment = Instantiate(this.segmentPrefab);
        segment.position = segments[segments.Count - 1].position;
        segments.Add(segment);
    }

    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("Goal"))
        {
            Debug.Log("worked");
            Grow();

        }

        if (other.CompareTag("Wall"))
        {
            Debug.Log("Lose");
            alive=false;
            this.GetComponent<Renderer>().enabled = false;
            loseMenu.SetActive(true);
            GoalColor.GetComponent<SnakeFoodSpawn>().loseSnake();
            HideEverything();
        }

    }

    public void HideEverything(){
          walls = GameObject.FindGameObjectsWithTag("Wall");
          foreach (GameObject wall in walls)
        {
            wall.transform.localScale = new Vector3(1000, 1000, 1000);

        }
    }

}
