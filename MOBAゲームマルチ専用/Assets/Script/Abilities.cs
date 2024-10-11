using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class Abilities : MonoBehaviour
{
    //スキル１
    [Header("Ability_1")]
    public Image abilityImage1;
    public TextMeshProUGUI abilityText1;
    public KeyCode abilityKey1;
    public float abilityCooldown1 = 5;

    //スキル２
    [Header("Ability_2")]
    public Image abilityImage2;
    public TextMeshProUGUI abilityText2;
    public KeyCode abilityKey2;
    public float abilityCooldown2 = 7;

    //スキル３
    [Header("Ability_3")]
    public Image abilityImage3;
    public TextMeshProUGUI abilityText3;
    public KeyCode abilityKey3;
    public float abilityCooldown3 = 10;

    //スキル４
    [Header("Ability_4")]
    public Image abilityImage4;
    public TextMeshProUGUI abilityText4;
    public KeyCode abilityKey4;
    public float abilityCooldown4 = 10;

    private bool isAbilityCooldown1 = false;
    private bool isAbilityCooldown2 = false;
    private bool isAbilityCooldown3 = false;
    private bool isAbilityCooldown4 = false;
 
    private float currentAbilityCooldown1;
    private float currentAbilityCooldown2;
    private float currentAbilityCooldown3;
    private float currentAbilityCooldown4;

    //開始
    void Start()
    {
        AbilitySetup();
    }

    //更新
    void Update()
    {
        Ability1Input();
        Ability2Input();
        Ability3Input();
        Ability4Input();

        AbilityCooldown(ref currentAbilityCooldown1, abilityCooldown1, ref isAbilityCooldown1, abilityImage1, abilityText1);
        AbilityCooldown(ref currentAbilityCooldown2, abilityCooldown2, ref isAbilityCooldown2, abilityImage2, abilityText2);
        AbilityCooldown(ref currentAbilityCooldown3, abilityCooldown3, ref isAbilityCooldown3, abilityImage3, abilityText3);
        AbilityCooldown(ref currentAbilityCooldown4, abilityCooldown4, ref isAbilityCooldown4, abilityImage4, abilityText4);
    }

    private void AbilitySetup()
    {
        //スキルリセット
        abilityImage1.fillAmount = 0;
        abilityImage2.fillAmount = 0;
        abilityImage3.fillAmount = 0;
        abilityImage4.fillAmount = 0;
        
        abilityText1.text = " ";
        abilityText2.text = " ";
        abilityText3.text = " ";
        abilityText4.text = " ";
    }

    //スキル１(Q)
    private void Ability1Input()
    {
        if(Input.GetKeyDown(abilityKey1) && !isAbilityCooldown1)
        {
            isAbilityCooldown1 = true;
            currentAbilityCooldown1 = abilityCooldown1;
        }
    }

    //スキル２(W)
    private void Ability2Input()
    {
        if(Input.GetKeyDown(abilityKey2) && !isAbilityCooldown2)
        {
            isAbilityCooldown2 = true;
            currentAbilityCooldown2 = abilityCooldown2;
        }
    }

    //スキル３(E)
    private void Ability3Input()
    {
        if(Input.GetKeyDown(abilityKey3) && !isAbilityCooldown3)
        {
            isAbilityCooldown3 = true;
            currentAbilityCooldown3 = abilityCooldown3;
        }
    }

    //スキル４(R)
    private void Ability4Input()
    {
        if(Input.GetKeyDown(abilityKey4) && !isAbilityCooldown4)
        {
            isAbilityCooldown4 = true;
            currentAbilityCooldown4 = abilityCooldown4;
        }
    }

    private void AbilityCooldown(ref float currentCooldown, float maxCooldown, ref bool isCooldown, Image skillImage, TextMeshProUGUI skillText)
    {
        if(isCooldown)
        {
            currentCooldown -= Time.deltaTime;

            if(currentCooldown <= 0f)
            {
                isCooldown = false;
                currentCooldown = 0f;

                if(skillImage != null)
                {
                    skillImage.fillAmount = 0f;
                }
                if(skillText != null)
                {
                    skillText.text = "";
                }
            }
            else
            {
                if(skillImage != null)
                {
                    skillImage.fillAmount = currentCooldown / maxCooldown;
                }
                if(skillText.text != null)
                {
                    skillText.text = Mathf.Ceil(currentCooldown).ToString();
                }
            }
        }
    }
}
