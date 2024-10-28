using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections.Generic;

public class PlayerUIController : MonoBehaviour
{
    // Für Spieler
    public Image playerImage;
    public TextMeshProUGUI playerNameText;
    public TextMeshProUGUI playerElectorNumberText;
    public TextMeshProUGUI playerMoneyNumberText;

    // Für Computer
    public Image computerImage;
    public TextMeshProUGUI computerNameText;
    public TextMeshProUGUI computerElectorNumberText;
    public TextMeshProUGUI computerMoneyNumberText;

    // Bilder für Kandidaten
    public Sprite AngelaMerkelUI;
    public Sprite BillClintonUI;
    public Sprite EmmanuelMacronUI;
    public Sprite GiorgiaMeloniUI;
    public Sprite KeirStarmerUI;
    public Sprite VladimirPutinUI;
    public Sprite WolodymyrZelenskyiUI;
    public Sprite XiJinPingUI;

    private void Start()
    {
        UpdatePlayerUI();
        UpdateComputerUI();
    }

    public void UpdatePlayerUI()
    {
        string candidateName = GameManager.Instance.SelectedCandidate;

        playerNameText.text = candidateName;
        playerImage.sprite = GetCandidateSprite(candidateName);

        playerElectorNumberText.text = GameManager.Instance.Electors.ToString();
        playerMoneyNumberText.text = GameManager.Instance.Money.ToString();
    }

    public void UpdateComputerUI()
    {
        string computerCandidateName = GameManager.Instance.ComputerCandidate;

        computerNameText.text = computerCandidateName;
        computerImage.sprite = GetCandidateSprite(computerCandidateName);

        computerElectorNumberText.text = GameManager.Instance.Electors.ToString();
        computerMoneyNumberText.text = GameManager.Instance.Money.ToString();
    }

    private Sprite GetCandidateSprite(string candidateName)
    {
        switch (candidateName)
        {
            case "AngelaMerkel": return AngelaMerkelUI;
            case "BillClinton": return BillClintonUI;
            case "EmmanuelMacron": return EmmanuelMacronUI;
            case "GiorgiaMeloni": return GiorgiaMeloniUI;
            case "KeirStarmer": return KeirStarmerUI;
            case "VladimirPutin": return VladimirPutinUI;
            case "WolodymyrZelenskyi": return WolodymyrZelenskyiUI;
            case "XiJinPing": return XiJinPingUI;
            default: return null;
        }
    }
}
