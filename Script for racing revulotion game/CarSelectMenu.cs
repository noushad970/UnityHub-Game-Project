using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CarSelectMenu : MonoBehaviour
{
    public Button[] carButtons;  // Array of buttons representing each car option
    public GameObject[] carPrefabs;  // Array of car prefabs to instantiate

    private int selectedCarIndex = 0;  // Index of the currently selected car

    private void Start()
    {
        // Attach click event handlers to each car button
        for (int i = 0; i < carButtons.Length; i++)
        {
            int carIndex = i;  // Capture the index in a local variable to avoid closure issues
            carButtons[i].onClick.AddListener(() => SelectCar(carIndex));
        }

        // Select the default car
        SelectCar(selectedCarIndex);
    }

    private void SelectCar(int index)
    {
        // Deselect the previously selected car button
        carButtons[selectedCarIndex].interactable = true;

        // Select the newly clicked car button
        carButtons[index].interactable = false;

        // Set the selected car index
        selectedCarIndex = index;

        // Instantiate or activate the selected car prefab
        for (int i = 0; i < carPrefabs.Length; i++)
        {
            carPrefabs[i].SetActive(i == selectedCarIndex);
        }
    }
}
