using UnityEngine;

public class Heart : MergeableObject
{
	protected override void MergeWithOverlap(GameObject otherObject)
	{
		// Check if the overlapped object is also a Heart
		if (otherObject.CompareTag("Heart"))
		{
			// Perform merge action: Upgrade to YellowStar
			Debug.Log("Merging Hearts to upgrade to YellowStar");

			// Instantiate the upgrade object (YellowStar) in place of this object
			GameObject newObject = Instantiate(Resources.Load<GameObject>("YellowStar"), transform.position, Quaternion.identity);
			// Optionally, transfer any properties or values to the new object
			// For example, transfer the merge value
			newObject.GetComponent<Heart>().mergeValue = mergeValue + 1;

			// Destroy the overlapped Heart objects
			Destroy(gameObject);
			Destroy(otherObject);
		}
	}
}
