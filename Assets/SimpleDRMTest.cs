using TMPro;
using UnityEngine;

public class SimpleDRMTest : MonoBehaviour
{
    public TextMeshProUGUI legalText;
    public DRMScript drmScript;
    
    public void OnCheck()
    {
        bool cooldownCheck = drmScript.cooldown;
        if (!drmScript.DRMCheck())
        {
            legalText.text = "Oops! You seem to be a pirate matey!";
            legalText.color = Color.red;
        }
        else
        {
            legalText.color = Color.white;
            if (cooldownCheck)
            {
                legalText.text = "DRM on cooldown!";
            }
            else
            {
                legalText.text = "All good!";
            }
        }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
