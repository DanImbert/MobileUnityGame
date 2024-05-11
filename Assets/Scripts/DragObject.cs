using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragObject : MonoBehaviour
{
	private Vector2 touchPosition;
	private float offsetX, offsetY;
	private bool isBeingDragged = false;
	private static bool touchReleased;

	private void Update()
	{
		if (Input.touchCount > 0)
		{
			Touch touch = Input.GetTouch(0);

			if (touch.phase == TouchPhase.Began && !isBeingDragged)
			{
				RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(touch.position), Vector2.zero);

				if (hit.collider != null && hit.collider.gameObject == gameObject && !isBeingDragged)
					{
					isBeingDragged = true;
					touchPosition = touch.position;
					touchPosition = Camera.main.ScreenToWorldPoint(touchPosition);

					offsetX = touchPosition.x - transform.position.x;
					offsetY = touchPosition.y - transform.position.y;
				}
			}
			else if (touch.phase == TouchPhase.Moved && isBeingDragged)
			{
				touchPosition = touch.position;
				touchPosition = Camera.main.ScreenToWorldPoint(touchPosition);

				transform.position = new Vector2(touchPosition.x - offsetX, touchPosition.y - offsetY);
			}
			else if (touch.phase == TouchPhase.Ended && isBeingDragged)
			{
				isBeingDragged = false;
				touchReleased = true;
			}
		}
	}

	private void OnTriggerStay2D(Collider2D collision)
	{
		if (touchReleased && gameObject.CompareTag("YellowStar") && collision.gameObject.CompareTag("YellowStar"))
		{
			Instantiate(Resources.Load("GoldCoin_Object"), transform.position, Quaternion.identity);
			touchReleased = false;
			Destroy(collision.gameObject);
			Destroy(gameObject);
		}

		else if (touchReleased && gameObject.CompareTag("GoldCoin") && collision.gameObject.CompareTag("GoldCoin"))
		{
			Instantiate(Resources.Load("Diamond_Object"), transform.position, Quaternion.identity);
			touchReleased = false;
			Destroy(collision.gameObject);
			Destroy(gameObject);
		}
		else if (touchReleased && gameObject.CompareTag("Diamond") && collision.gameObject.CompareTag("Diamond"))
		{
			Instantiate(Resources.Load("LightningBolt_Object"), transform.position, Quaternion.identity);
			touchReleased = false;
			Destroy(collision.gameObject);
			Destroy(gameObject);
		}
		else if (touchReleased && gameObject.CompareTag("LightningBolt") && collision.gameObject.CompareTag("LightningBolt"))
		{
			Instantiate(Resources.Load("BlackStar_Object"), transform.position, Quaternion.identity);
			touchReleased = false;
			Destroy(collision.gameObject);
			Destroy(gameObject);
		}
	}
}
