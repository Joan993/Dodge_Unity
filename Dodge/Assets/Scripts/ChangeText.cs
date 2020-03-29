using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeText : MonoBehaviour
{
    public string scoreLast;
    public static string scoreMax;
    public string score;
    int last;
    private Text m_TextComponent;
    // Start is called before the first frame update
    void Start()
    {
        float lastScore = Traps.Tiempo;
        m_TextComponent = GetComponent<Text>();

            m_TextComponent.text = lastScore + " seconds";

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
