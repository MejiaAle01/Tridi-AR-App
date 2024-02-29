using UnityEngine;
using System;

public class GameManager : MonoBehaviour {

    // 
    public event Action OnMainMenu;

    // Utilizamos un singleton
    public static GameManager Instance;

    private void Awake() {
        if (Instance != null && Instance != this) {
            Destroy(gameObject);
        } else {
            Instance = this;
        }
    }

    // Start is called before the first frame update
    void Start() {
        MainMenu();
    }

    // Update is called once per frame
    public void MainMenu() {
        OnMainMenu?.Invoke();
        Debug.Log("Main Menu Activated");
    }

    public void CloseApp() {
        Application.Quit();
    }
}
