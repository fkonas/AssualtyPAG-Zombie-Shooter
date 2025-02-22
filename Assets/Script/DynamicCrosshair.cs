using UnityEngine;
using UnityEngine.UI;

public class DynamicCrosshair : MonoBehaviour
{
    public DynamicCrosshair Instance { get; set; }

    public RectTransform Crosshair;

    public float maxSize;
    public float minSize;
    public float currentSize;

    public float speed;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    private void Update()
    {
        Inputs();
        SetSize();
    }

    void SetSize()
    {
        Crosshair.sizeDelta = new Vector2(currentSize, currentSize);
    }

    void Inputs()
    {
        if (!PlayerMovememnnt.isWalking && !PlayerMovememnnt.isRunning)
        {
            SetMin();
        }
        else if (PlayerMovememnnt.isWalking)
        {
            SetMax();
        }
        if (PlayerMovememnnt.isRunning || Input.GetMouseButton(1))
        {
            SetDeactive();
        }
        else
        {
            SetActive();
        }
    }

    void SetMin()
    {
        currentSize = Mathf.Lerp(currentSize, minSize, speed * Time.deltaTime);
    }

    void SetMax()
    {
        currentSize = Mathf.Lerp(currentSize, maxSize, speed * Time.deltaTime);
    }

    void SetActive()
    {
        Crosshair.gameObject.SetActive(true);
    }

    void SetDeactive()
    {
        Crosshair.gameObject.SetActive(false);
    }

}
