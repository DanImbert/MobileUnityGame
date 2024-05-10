using UnityEngine;

public class MergeObjects : MonoBehaviour
{
	private bool isDragging = false; // Flag to track if the object is being dragged
	private Vector3 touchOffset; // Offset between touch position and object position

	private void Update()
	{
		if (Input.touchCount > 0)
		{
			Touch touch = Input.GetTouch(0); // Get the first touch

			switch (touch.phase)
			{
				case TouchPhase.Began:
					// Check if the touch position is within the bounds of the object
					if (IsTouchingObject(touch.position))
					{
						isDragging = true;
						// Calculate the offset between touch position and object position
						touchOffset = transform.position - Camera.main.ScreenToWorldPoint(touch.position);
					}
					break;
				case TouchPhase.Moved:
					// Check if the object is being dragged
					if (isDragging)
					{
						// Update object position based on touch position
						Vector3 newPosition = Camera.main.ScreenToWorldPoint(touch.position) + touchOffset;
						transform.position = new Vector3(newPosition.x, newPosition.y, transform.position.z);
					}
					break;
				case TouchPhase.Ended:
					// Check if the object is overlapping with another mergeable object
					if (IsOverlappingMergeable())
					{
						MergeWithOverlap();
					}
					// Reset flag when touch ends
					isDragging = false;
					break;
			}
		}
	}

	private bool IsTouchingObject(Vector2 touchPosition)
	{
		// Raycast to check if the touch position hits the object's collider
		RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(touchPosition), Vector2.zero);
		return hit.collider != null && hit.collider.gameObject == gameObject;
	}

	private bool IsOverlappingMergeable()
	{
		Collider2D[] colliders = Physics2D.OverlapBoxAll(transform.position, transform.localScale * 1.2f, 0);
		foreach (var collider in colliders)
		{
			if (collider.CompareTag("Mergeable") && collider.gameObject != gameObject)
			{
				return true;
			}
		}
		return false;
	}

	private void MergeWithOverlap()
	{
		// Example merge action
		Debug.Log("Merging with overlap");
		// Perform your merge logic here
		// Destroy(gameObject); // Optionally, destroy this object after merging
	}
}
