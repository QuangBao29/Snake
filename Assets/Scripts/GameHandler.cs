using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GameHandler : MonoBehaviour {
    [SerializeField]
    private GameObject prefab;
    [SerializeField]
    private GameObject pts;
    private void Start()
    {
        pts.GetComponent<Text>().text = "Point: " + SnakeController.countPoint.ToString();
        Instantiate(prefab);
    }
    private void Update()
    {
        pts.GetComponent<Text>().text = "Point: " + SnakeController.countPoint.ToString();
    }

}
