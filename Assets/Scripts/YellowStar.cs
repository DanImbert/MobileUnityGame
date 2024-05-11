using UnityEngine;

public class YellowStar : MergeableObject
{
	protected override void MergeWithOverlap(GameObject otherObject)
	{
		if (otherObject.CompareTag("YellowStar"))
		{
			MergeToGoldCoin();
			Destroy(gameObject);
			Destroy(otherObject);
		}
	}

	private void MergeToGoldCoin()
	{
		Debug.Log("Merging two Yellow Stars to upgrade to Gold Coin");

		// Instantiate GoldCoin object in place of this object
		GameObject newObject = Instantiate(Resources.Load<GameObject>("GoldCoin"), transform.position, Quaternion.identity);
		// Optionally, transfer the merge value to the new object
		// newObject.GetComponent<GoldCoin>().SetMergeValue(mergeValue + 1);
		// Destroy the YellowStar objects
		Destroy(gameObject);
	}
}
