using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragLogic : MonoBehaviour
{
    private bool dragging = false;
    private Vector3 offset;
    public Rigidbody2D rb;

    void Update()
    {
        if (dragging)
        {
            Vector3 newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition) + offset;

            transform.rotation = Quaternion.Euler(0, 0, 0);

            // Überprüfe, ob es zu Kollisionen kommt
            Collider2D[] colliders = Physics2D.OverlapBoxAll(newPosition, transform.localScale, 0);
            foreach (Collider2D collider in colliders)
            {
                if (collider.gameObject != gameObject)
                {
                    // Wenn eine Kollision mit einem anderen Objekt auftritt, breche den Drag-Vorgang ab
                    return;
                }
            }

            // Bewege das Objekt, wenn keine Kollisionen festgestellt wurden
            transform.position = newPosition;
        }
    }

    private void OnMouseDown()
    {
        offset = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
        dragging = true;

        // Setze die Geschwindigkeit des Rigidbody auf Null
        rb.velocity = Vector2.zero;
    }

    private void OnMouseUp()
    {
        dragging = false;
    }
}
