using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    private Transform Ship;
    [SerializeField]
    private GameObject Way;

    RaycastHit hit;

    private List<GameObject> way;
    private GameObject WayInstanciator;
    private int wayNumber = 0;
    private int followPath = 0;
    private static bool isMoving;

    private SphereCollider WayDistancer;
    [SerializeField]
    private float spaceBetweenCubes;
    public static bool resetGame;


    void Start()
    {
        Ship = GetComponent<Transform>();
        way = new List<GameObject>();
        WayDistancer = Ship.GetComponentInChildren<SphereCollider>();
        isMoving = false;
    }

    void Update()
    {
        //Фиксация нажатия на кубики
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.transform.CompareTag("Cube") && Input.GetMouseButtonDown(0) && Mathf.Abs(Vector3.Distance(WayDistancer.transform.position, hit.transform.position)) < spaceBetweenCubes)
            {
                WayBuilder();
            }
            else
            {
                //Debug.Log("not moving lolz");
            }
        }

        if(resetGame==true)
        {
            GameObject[] wayArray = GameObject.FindGameObjectsWithTag("Way");
            foreach(GameObject way in wayArray)
            {
                Destroy(way);
            }
            way = new List<GameObject>();
            wayNumber = 0;
            followPath = 0;
            WayDistancer.transform.position = new Vector3(Ship.transform.position.x, Ship.transform.position.y-1f, Ship.transform.position.z);
            resetGame = false;
        }
    }

    public void PlayGame()
    {
        //Начать движение
        isMoving = true;
    }

    public void ResetList()
    {
        resetGame = true;
    }

    //Построение маршрута
    private void WayBuilder()
    {
        WayInstanciator = Instantiate(Way);
        WayInstanciator.transform.position = new Vector3(hit.transform.position.x, transform.position.y - 0.8f, hit.transform.position.z);
        way.Add(WayInstanciator);
        MoveWayDistancer();
    }

    //Передвижение маячка, который дает/не дает проложить дальнейший маршрут
    private void MoveWayDistancer()
    {
        WayDistancer.transform.position = new Vector3(way[wayNumber].transform.position.x, way[wayNumber].transform.position.y, way[wayNumber].transform.position.z);
        wayNumber++;
    }

    //Передвижение после построения маршрута
    private void FixedUpdate()
    {
        if (way.Count > followPath && isMoving == true)
        {
                Ship.transform.position = Vector3.MoveTowards(new Vector3(Ship.transform.position.x, Ship.transform.position.y, Ship.transform.position.z), new Vector3(way[followPath].transform.position.x, transform.position.y, way[followPath].transform.position.z), 0.05f);
                if (Ship.transform.position.z == way[followPath].transform.position.z && transform.position.x == way[followPath].transform.position.x)
                {
                    followPath++;
                }
        }

        if (way.Count <= followPath)
        {
            //Debug.Log("GameFinished");
        }
    }
}