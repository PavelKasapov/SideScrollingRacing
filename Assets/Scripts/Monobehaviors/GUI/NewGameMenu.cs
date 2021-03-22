using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class NewGameMenu : MonoBehaviour
{
    public Image imagePlaceholder;
    public Button startButton;
    private NewGameService _newGameService;
    private string SelectedVehicleName;


    private Dictionary<int, string> VehicleName = new Dictionary<int, string>()
    {
        [0] = "Monster Truck",
        [1] = "Sport Car"
    };

    [Inject]
    public void Construct(NewGameService newGameService)
    {
        _newGameService = newGameService;
    }

    public void SelectButtonClickHandler(int value)
    {
        SelectedVehicleName = VehicleName[value];
        startButton.interactable = true;
        imagePlaceholder.sprite = Resources.Load<Sprite>("Images/" + SelectedVehicleName + " Image");
    }

    public void StartButtonClickHandler()
    {
        _newGameService.StartNewGame("Prefabs/" + SelectedVehicleName);
    }
}
