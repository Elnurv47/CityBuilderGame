using UnityEngine;
using System.Collections.Generic;

public class GridBuildingSystemUI : MonoBehaviour
{
    [SerializeField] private List<BuildingButton> buildingButtons;
    public List<BuildingButton> BuildingButtons { get => buildingButtons; }
}
