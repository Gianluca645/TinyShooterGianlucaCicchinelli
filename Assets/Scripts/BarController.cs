using UnityEngine;
using UnityEngine.UI;

public class BarController : MonoBehaviour
{
    private Slider _bar;
    public float _maxValue;

    void Awake()
    {
        _bar = GetComponent<Slider>();
    }

    public void UpdateBar(float points)
    {
        _bar.value = points / _maxValue; // Si points vale 3, 3/3 = 1 y por tanto la barra está llena. Si vale 2, la barra está 2/3 llena etc...
    }
}