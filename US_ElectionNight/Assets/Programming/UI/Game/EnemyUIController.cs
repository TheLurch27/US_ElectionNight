using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections.Generic;

public class EnemyUIController : MonoBehaviour
{
    public Image computerImage;
    public TextMeshProUGUI computerNameText;
    public TextMeshProUGUI computerElectorNumberText;
    public TextMeshProUGUI computerMoneyNumberText;

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
        UpdateComputerUI();
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
