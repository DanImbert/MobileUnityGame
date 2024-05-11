using UnityEngine;

public class MergeableObject : MonoBehaviour
{
	protected int mergeValue = 1; // Value of the merged object
	protected string objectTypeTag; // Tag to identify the object type

	protected virtual void Start()
	{
		// Get the tag of this object to identify its type
		objectTypeTag = gameObject.tag;
	}

	protected virtual void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag(objectTypeTag))
		{
			MergeWithOverlap(other.gameObject);
		}
	}

	protected virtual void OnTriggerExit2D(Collider2D other)
	{
		// Implement if needed
	}

	protected virtual void MergeWithOverlap(GameObject otherObject)
	{
		// Implement merge logic in subclasses
		Debug.Log("Merging with overlap to " + otherObject.tag);

		// Perform merge action here
		// Destroy(gameObject); // Optionally, destroy this object after merging
	}
}
