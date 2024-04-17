using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class Tumbler : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;

    public event UnityAction Switching;

    public bool Condition { get; private set; } = false;

    private string _on = "On";
    private string _off = "Off";

    private void Start()
    {
        DisplayText();
    }

    public void Click()
    {
        Turn();
        DisplayText();
        Switching?.Invoke();
        Debug.Log(Condition);
    }

    private void DisplayText()
    {
        if (Condition)
            _text.text = _on;
        else
            _text.text = _off;
    }

    private void Turn()
    {
        if (Condition)
            Condition = false;
        else
            Condition = true;
    }
}
