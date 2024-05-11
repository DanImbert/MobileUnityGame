using UnityEngine;

public class Heart : MergeableObject
{
	private const float doubleTapThreshold = 0.5f; // Adjust as needed
	private float lastTapTime = 0f;
	private bool isBuffApplied = false;

	protected override void MergeWithOverlap(GameObject otherObject)
	{
		if (otherObject.CompareTag("BlackStar"))
		{
			MergeToHeart();
			Destroy(gameObject);
			Destroy(otherObject);
		}
	}

	private void MergeToHeart()
	{
		Debug.Log("Merging two Black Stars to upgrade to Heart");

		// Instantiate Heart object in place of this object
		GameObject newObject = Instantiate(Resources.Load<GameObject>("Heart"), transform.position, Quaternion.identity);
		// Transfer the merge value to the new object
		newObject.GetComponent<Heart>().mergeValue = mergeValue + 1;
	}

	private void Update()
	{
		// Detect double tap
		if (!isBuffApplied && Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Began)
		{
			float currentTime = Time.time;
			float timeSinceLastTap = currentTime - lastTapTime;

			if (timeSinceLastTap < doubleTapThreshold)
			{
				ApplyDoublePointBuff();
			}

			lastTapTime = currentTime;
		}
	}

	private void ApplyDoublePointBuff()
	{
		Debug.Log("Double tap detected on Heart! Applying double point buff.");

		// Apply double point buff to the player for 20 seconds
		// You can implement your point system here and double the points for 20 seconds
		// For example:
		// GameManager.Instance.ApplyDoublePointBuff(20f);

		isBuffApplied = true;
		Invoke("Disappear", 20f); // Schedule the Heart to disappear after 20 seconds
	}

	private void Disappear()
	{
		Destroy(gameObject);
	}
}
