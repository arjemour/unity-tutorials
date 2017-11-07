using UnityEngine;

public class DefenderSpawner : MonoBehaviour
{
    public Camera MyCamera;

    private GameObject defenderParent;
    private StarDisplay starDisplay;

    private void Start()
    {
        defenderParent = GameObject.Find("Defenders");
        starDisplay = FindObjectOfType<StarDisplay>();

        if (!defenderParent)
        {
            defenderParent = new GameObject("Defenders");
        }
    }

    private void OnMouseDown()
    {
        int defenderCost = Button.SelectedDefender.GetComponent<Defender>().starCost;
        if (starDisplay.UseStars(defenderCost) == StarDisplay.Status.SUCCESS)
        {
            GameObject defender = Instantiate(Button.SelectedDefender, SnapToGrid(CalculateWorldPointMouseClick()), Quaternion.identity);
            defender.transform.parent = defenderParent.transform;
        }
    }

    private Vector2 CalculateWorldPointMouseClick()
    {
        float mouseX = Input.mousePosition.x;
        float mouseY = Input.mousePosition.y;
        float distanceFromCamera = 10;

        Vector3 triplet = new Vector3(mouseX, mouseY, distanceFromCamera);
        Vector2 worldPos = MyCamera.ScreenToWorldPoint(triplet);

        return worldPos;
    }

    private Vector2 SnapToGrid(Vector2 worldPosition)
    {
        return new Vector2(Mathf.RoundToInt(worldPosition.x), Mathf.RoundToInt(worldPosition.y));
    }
}