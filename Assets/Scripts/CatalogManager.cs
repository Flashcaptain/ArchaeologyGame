using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CatalogManager : MonoBehaviour
{
    [SerializeField]
    private Image _objectImage;

    [SerializeField]
    private Text _title;

    [SerializeField]
    private Text _entry;

    public void FillCatalogEntry(CatalogObject catalogObject)
    {
        _objectImage.sprite = catalogObject._sprite;
        _title.text = catalogObject._objectName;
        _entry.text = catalogObject._catalogEntry;
    }
}
