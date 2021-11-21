using UnityEngine;
using System.Collections;
using UnityEngine.UI;

// �¾�� ü���� �ִ�ü������ �Ѵ�.
// ���� �÷��̾ ������ �� ü���� �����Ѵ�.
// ü���� ����Ǹ� UI���� �ݿ��Ѵ�.
public class PlayerHP : MonoBehaviour
{
    int hp;
    public int maxHP = 100;
    public Slider sliderHP;
    private Color red = new Color(255,0,0, 0.9f);
    private Color green = new Color(0, 255, 0, 0.6f);


    public static bool gameOver = false;

    public GameObject mainCam;

    public void SetHP(int value)
    {
        hp = value;
        sliderHP.value = value;
    }
    public int GetHP()
    {
        return hp;
    }

    void Start()
    {
        sliderHP.maxValue = maxHP; //�ִ�ġ�� ����
        SetHP(maxHP);
        
    }

    public void addDamage(int damage = -1)
    {
        SetHP(GetHP() - damage);
        if (hp > 100)
            SetHP(100);
        else if (hp <= 0)
            SetHP(0);
    }

    private void Update()
    {
        if (GetHP() <= 30)
        {
            sliderHP.gameObject.transform.Find("Fill Area").Find("Fill").GetComponent<Image>().color = red;
        }
        else
        {
            sliderHP.gameObject.transform.Find("Fill Area").Find("Fill").GetComponent<Image>().color = green;


        }
        if (GetHP() == 0)
        {
            gameOver = true;
            SetHP(-1);
        }
    }
}