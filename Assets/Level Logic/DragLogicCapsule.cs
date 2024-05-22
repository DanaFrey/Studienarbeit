using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragLogicCapsule : MonoBehaviour
{
    private bool dragging = false;
    private int count;
    private Vector3 offset;
    public Rigidbody2D rb;
    public World2Level1Logic world2Level1;
    private Rigidbody2D barGoalRb;
    private float startTime;

    void Start()
    {
        startTime = Time.time;
    }

    void Update()
    {
        if (count == 0 && world2Level1 != null)
        {
            GameObject barGoal = world2Level1.barGoal;
            barGoalRb = barGoal.GetComponent<Rigidbody2D>();
            count++;
        }
        if (world2Level1 != null)
        {
            if (dragging)
            {
                Vector3 newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition) + offset;

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
            if (IsGoalReached(barGoalRb))
            {
                world2Level1.goalReached = true;
            }
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

    public bool IsGoalReached(Rigidbody2D goal)
    {
        Bounds bounds = gameObject.GetComponent<SpriteRenderer>().bounds;
        float top = bounds.max.y;
        //float bottom = bounds.min.y;
        float distance = Mathf.Abs(rb.position.y - goal.position.y);
        if (Time.time - startTime >= 1 && distance <= top - rb.position.y && distance >= 0 && dragging == false && rb.velocity.x >= -3 && rb.velocity.x <= 3 && rb.velocity.y >= -8 && rb.velocity.y <= 8)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}