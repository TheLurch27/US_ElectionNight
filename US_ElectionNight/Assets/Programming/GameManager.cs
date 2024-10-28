using UnityEngine;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public string SelectedCandidate { get; private set; }
    public string ComputerCandidate { get; private set; }

    // Standardwerte für Electors und Money
    public int Electors { get; private set; } = 0;
    public int Money { get; private set; } = 250;

    private List<string> candidates = new List<string>
    {
        "BillClinton", "AngelaMerkel", "EmmanuelMacron", "GiorgiaMeloni",
        "KeirStarmer", "VladimirPutin", "WolodymyrZelenskyi", "XiJinping"
    };

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void SetSelectedCandidate(string candidateName)
    {
        SelectedCandidate = candidateName;
        Debug.Log("Spieler-Kandidat: " + SelectedCandidate);
        ChooseComputerCandidate(); // Wähle den Computer-Kandidaten, sobald der Spieler seinen Kandidaten festgelegt hat
    }

    public void ChooseComputerCandidate()
    {
        List<string> availableCandidates = new List<string>(candidates);
        availableCandidates.Remove(SelectedCandidate);

        int randomIndex = Random.Range(0, availableCandidates.Count);
        ComputerCandidate = availableCandidates[randomIndex];
        Debug.Log("Computer-Kandidat: " + ComputerCandidate);
    }
}
