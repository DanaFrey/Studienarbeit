using UnityEngine;

public class DragLogicRoof : MonoBehaviour
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

                transform.rotation = Quaternion.Euler(0, 0, -45);

                Collider2D[] colliders = Physics2D.OverlapBoxAll(newPosition, transform.localScale, 0);
                foreach (Collider2D collider in colliders)
                {
                    if (collider.gameObject != gameObject)
                    {
                        return;
                    }
                }
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

        rb.velocity = Vector2.zero;
    }

    private void OnMouseUp()
    {
        dragging = false;
    }

    public bool IsGoalReached(Rigidbody2D goal)
    {
        float distance = Mathf.Abs(rb.position.y - goal.position.y);
        if (Time.time - startTime >= 1 && distance <= 82 && distance >= 0 && dragging == false && rb.velocity.x >= -3 && rb.velocity.x <= 3 && rb.velocity.y >= -8 && rb.velocity.y <= 8)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
