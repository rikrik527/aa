using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class LineDraw : MonoBehaviour
{
    private LineRenderer lineRend;
    private Vector2 mousePos;
    private Vector2 startMousePos;
    [SerializeField]
    private Transform _yushan;
    private GameObject[] _other;

    [SerializeField]
    private Text distanceText;
    private float distance;


    void Start()
    {
        lineRend = GetComponent<LineRenderer>();
        lineRend.positionCount = 2;
    }

    // Update is called once per frame
    void Update()
    {
        _yushan = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        _other = GameObject.FindGameObjectsWithTag("npc");
        for (int i = 0; i < _other.Length; i++)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Transform target = _other[i].transform;
                if (_other[i])
                {
                    Debug.Log("other");
                    lineRend.SetPosition(0, new Vector3(target.position.x, target.position.y, 0f));
                    lineRend.SetPosition(1, new Vector3(_yushan.position.x, _yushan.position.y, 0f));
                    distance = (target.position - _yushan.position).sqrMagnitude;
                    distanceText.text = distance.ToString("F2") + "meters";
                }
            }
        }

    }
}
