using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ClickWithForce : MonoBehaviour, IPointerClickHandler
{
    private Camera cam;
    [SerializeField]
    public GameObject dotPrefab;

    void Start()
    {
        cam = Camera.main;
    }

    public void OnPointerClick(PointerEventData pointerEventData)
    {
      float force = 100;

        Vector3 worldPoint = new Vector3();
        Vector2 screenPoint = new Vector2();

        // Get the click position from Event.
        screenPoint.x = pointerEventData.pressPosition.x;
        screenPoint.y = cam.pixelHeight - pointerEventData.pressPosition.y;

        worldPoint = cam.ScreenToWorldPoint(new Vector3(screenPoint.x, screenPoint.y, cam.nearClipPlane));

        Vector3 dir = worldPoint - transform.position;
           
        GameObject dot = Instantiate<GameObject>(dotPrefab, worldPoint, Quaternion.identity);
    }
}