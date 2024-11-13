using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections.Generic;

public class PlayerUIController : MonoBehaviour
{
    public Image playerImage;
    public TextMeshProUGUI playerNameText;
    public TextMeshProUGUI playerElectorNumberText;
    public TextMeshProUGUI playerMoneyNumberText;

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
    }

    public void UpdatePlayerUI()
    {
        string candidateName = GameManager.Instance.SelectedCandidate;

        playerNameText.text = candidateName;
        playerImage.sprite = GetCandidateSprite(candidateName);

        playerElectorNumberText.text = GameManager.Instance.Electors.ToString();
        playerMoneyNumberText.text = GameManager.Instance.Money.ToString();
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
