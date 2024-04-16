using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class HandUpButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public GameObject objectToRotate;
    private float rotationSpeed = 60f;

    private bool isRotating = false;

    public void OnPointerDown(PointerEventData eventData)
    {
        isRotating = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isRotating = false;
    }

    void Update()
    {
        if (isRotating)
        {
            objectToRotate.transform.Rotate(-Vector3.forward * rotationSpeed * Time.deltaTime);
        }
    }
}

