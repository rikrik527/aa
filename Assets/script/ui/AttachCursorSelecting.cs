using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttachCursorSelecting : MonoBehaviour
{
    [SerializeField] private RectTransform selecting;
    [SerializeField] private RectTransform canvasTransform;
    [SerializeField] private Camera camera;
    public SelectingAnimations selectingAnimations;
    private void Init()
    {

    }
    private void Awake()
    {
        selectingAnimations = GameObject.FindGameObjectWithTag("select").GetComponent<SelectingAnimations>();
        Vector3 screenPos = camera.ScreenToWorldPoint(this.transform.position);
        Vector2 screenPos2D = new Vector2(screenPos.x, screenPos.y);
        Vector2 anchoredPos;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(canvasTransform, screenPos2D, camera, out anchoredPos);
        selecting.anchoredPosition = anchoredPos;

    }
    private void Update()
    {
        selectingAnimations.Selecting();
    }

}
