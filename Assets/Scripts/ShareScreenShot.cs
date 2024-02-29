using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShareScreenShot : MonoBehaviour
{
    // Configuramos el nombre de la captura
    private string screenshotName = "Screenshot " + DateTime.Now.ToString("dd-MM-yyyy HHmmss") + ".png";

    [SerializeField] private GameObject mainMenuCanvas;

    // Funcion que activa y oculta la interfaz
    public void OnOffContent() {
        mainMenuCanvas.SetActive(!mainMenuCanvas.activeSelf);
    }

    // Funcion que toma la captura de pantalla
    public void TakeScreenShot() {
        OnOffContent();
        StartCoroutine(SaveScreenShot());
    }

    // Funcion que reinicia toda la escena
    public void ResetScene() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    // Funcion de corrutina para tomar la captura de pantalla
    private IEnumerator SaveScreenShot() {
        yield return new WaitForEndOfFrame();

        string screenShotPath = Application.dataPath + "/Screenshots/";

        ScreenCapture.CaptureScreenshot(screenshotName);

        Debug.Log("Captura guardada en: " + screenShotPath + " como: " + screenshotName);

        OnOffContent();

        ResetScene();
    }
}