using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectInteract : MonoBehaviour
{
    public static ObjectInteract Instance;

    private void Awake()
    {
        Instance = this;
    }

    [Header("Item Name")]
    [SerializeField] GameObject ItemNameObject;
    [SerializeField] Text ItemNameText;

    private void Update()
    {
        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            ItemNameObject.SetActive(true);
            ItemNameText.text = hit.transform.gameObject.name;
        }
        else
        {
            ItemNameObject.SetActive(false);
        }
    }
}
