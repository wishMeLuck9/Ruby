using UnityEngine;
using UnityEngine.UIElements;

public class UI_Handler : MonoBehaviour
{
    private VisualElement m_Healthbar;

    public static UI_Handler instance { get; private set; }

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        UIDocument uiDocument = GetComponent<UIDocument>();
        m_Healthbar = uiDocument.rootVisualElement.Q<VisualElement>("HealthBar");
        SetHealthValue(1.0f);
    }

    public void SetHealthValue(float percentage)
    {
        m_Healthbar.style.width = Length.Percent(54.5f * percentage);
    }
}