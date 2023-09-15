using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public void SelectCarMenu()
    {
        SceneManager.LoadScene("CarSelectMenu");

    }
    public void Car1()
    {
        SceneManager.LoadScene("GameWeatherWithCar");
    }
    public void Sqoote()
    {
        SceneManager.LoadScene("GameWeatherWithSqoote");
    }
    public void VehicleBig()
    {
        SceneManager.LoadScene("GameWeatherWithVehicleBig");
    }
    public void VehicleSmall()
    {
        SceneManager.LoadScene("GameWeatherWithVehicleSmall");
    }
    public void RallyCar()
    {
        SceneManager.LoadScene("GameWeatherWithRallyCar");
    }
    public void PoliceCar()
    {
        SceneManager.LoadScene("GameWeatherWithPoliceCar");
    }
    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
