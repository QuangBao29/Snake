using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeController : MonoBehaviour
{
    [SerializeField]
    float speed;
    [HideInInspector]
    public static int countPoint = 0;

    int direc;
    Vector3 newPos = Vector3.up;

    private List<Transform> SegmentList;
    [SerializeField]
    private Transform SegmentPrefab;
    private void Start()
    {
        SegmentList = new List<Transform>();
        SegmentList.Add(this.transform);
        
    }
    private void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow) && newPos != Vector3.down)
        {
            newPos = Vector3.up;
            gameObject.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
            direc = 1;
        }
        else if (Input.GetKey(KeyCode.DownArrow) && newPos != Vector3.up)
        {
            newPos = Vector3.down;
            gameObject.transform.rotation = Quaternion.Euler(0f, 0f, 180f);
            direc = 3;
        }
        else if (Input.GetKey(KeyCode.RightArrow) && newPos != Vector3.left)
        {
            newPos = Vector3.right;
            gameObject.transform.rotation = Quaternion.Euler(0f, 0f, -90f);
            direc = 2;
        }
        else if (Input.GetKey(KeyCode.LeftArrow) && newPos != Vector3.right) { 
            newPos = Vector3.left;
            gameObject.transform.rotation = Quaternion.Euler(0f, 0f, 90f);
            direc = 4;
        }

        //transform.Translate(Vector3.right * speed * Time.deltaTime);
        //this.GetComponent<Rigidbody2D>().MovePosition(transform.position + (Vector3.right * speed * Time.deltaTime));
        
    }
    private void FixedUpdate()
    {
        for (int i = SegmentList.Count - 1; i > 0; i--)
        {
            SegmentList[i].position = SegmentList[i - 1].position;
            SegmentList[i].rotation = SegmentList[i - 1].rotation;
        }

        this.transform.position = new Vector3(
            Mathf.Round(this.transform.position.x) + newPos.x,
            Mathf.Round(this.transform.position.y) + newPos.y,
            0.0f
            );
    }
    private void Grow()
    {
        Transform segment = Instantiate(SegmentPrefab);
        segment.position = SegmentList[SegmentList.Count - 1].position;
        SegmentList.Add(segment);
    }
    private void ResetSnake()
    {
        for (int i = 1; i < SegmentList.Count; i++)
        {
            Destroy(SegmentList[i].gameObject);
        }
        SegmentList.Clear();
        SegmentList.Add(this.transform);

        this.transform.position = new Vector3(0f, -6f, 0f);
        gameObject.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        newPos = Vector3.up;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "food")
        {
            Grow();
            countPoint++;
        }
        if (collision.tag == "Player" || collision.tag == "Wall")
        {
            ResetSnake();
        }
    }
}