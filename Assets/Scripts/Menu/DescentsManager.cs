using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DescentsManager : MonoBehaviour
{
    [SerializeField] private Text _descentsText;

    private void Awake()
    {
        _descentsText.text = "Descents: " + Data.DescentsCount;
    }
}
