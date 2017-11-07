using UnityEngine;
using UnityEngine.UI;

public class PinSetter : MonoBehaviour
{
    public GameObject PinSet;

    private Animator _animator;
    private PinCounter _pinCounter;


    // Use this for initialization
    private void Start()
    {
        _animator = GetComponent<Animator>();
        _pinCounter = FindObjectOfType<PinCounter>();

    }

    // Update is called once per frame
    private void Update()
    {

    }

    private void OnTriggerExit(Collider collider)
    {
        GameObject thingLeft = collider.gameObject;

        if (thingLeft.GetComponentInParent<Pin>())
            Destroy(thingLeft.transform.parent.gameObject);
    }

    public void RaisePins()
    {
        foreach (Pin pin in FindObjectsOfType<Pin>())
        {
            pin.Raise();
        }
            
    }

    public void LowerPins()
    {
        foreach (Pin pin in FindObjectsOfType<Pin>())
            pin.Lower();
    }

    public void RenewPins()
    {
        Instantiate(PinSet, new Vector3(0, 0, 1842), Quaternion.identity);
    }

    public void PerformAction(ActionMaster.Action action)
    {
        if (action == ActionMaster.Action.Tidy)
        {
            _animator.SetTrigger("Tidy Trigger");
        }
        else if (action == ActionMaster.Action.EndTurn || action == ActionMaster.Action.Reset)
        {
            _animator.SetTrigger("Reset Trigger");
            _pinCounter.Reset();
        }
        else if (action == ActionMaster.Action.EndGame)
        {
            throw new UnityException("end game");
        }
    }
}