using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextTMPViewer : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI textPlayerHP;           // Text - TextMeshPro UI [�÷��̾� ü��]

    [SerializeField]
    private TextMeshProUGUI textPlayerPoint;        // Text - TextMeshPro UI [�÷��̾��� ����Ʈ]

    [SerializeField]
    private PlayerHP playerHP;                      // �÷��̾��� ü�� ����

    [SerializeField]
    private PlayerPoint playerPoint;                // �÷��̾��� ����Ʈ ����

    private void Update()
    {
        textPlayerHP.text = playerHP.CurrentHP + "/" + playerHP.MaxHP;
        textPlayerPoint.text = playerPoint.CurrentPoint.ToString();
    }
        
}

/*
 * Flie : TextTMPViewer.cs
 * Desc
 *  : Text-TextMeshPro UI�� ǥ���Ǵ� ���� ���� ������Ʈ
 */
