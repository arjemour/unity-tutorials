using UnityEngine;

public class Button : MonoBehaviour
{
    public GameObject DefenderPrefab;
    private Button[] buttonArray;
    public static GameObject SelectedDefender;

    // Use this for initialization
    private void Start()
    {
        buttonArray = FindObjectsOfType<Button>();
    }

    // Update is called once per frame
    private void Update()
    {
    }

    private void OnMouseDown()
    {
        foreach (Button button in buttonArray)
            button.GetComponent<SpriteRenderer>().color = Color.black;

        GetComponent<SpriteRenderer>().color = Color.white;
        SelectedDefender = DefenderPrefab;
    }
}