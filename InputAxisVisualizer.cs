using UnityEngine;

public class InputAxisVisualizer : MonoBehaviour
{
    public enum InputType
    {
        GetAxis,
        GetAxisRaw,
        GetKey,
        GetButton
    }

    [Header("Configurações de Entrada")]
    public InputType inputType = InputType.GetAxis; // Tipo de entrada a ser exibido
    public string horizontalKey = "Horizontal"; // Nome do eixo ou tecla horizontal
    public string verticalKey = "Vertical"; // Nome do eixo ou tecla vertical
    public KeyCode keyPositiveHorizontal = KeyCode.D; // Tecla positiva para eixo horizontal
    public KeyCode keyNegativeHorizontal = KeyCode.A; // Tecla negativa para eixo horizontal
    public KeyCode keyPositiveVertical = KeyCode.W; // Tecla positiva para eixo vertical
    public KeyCode keyNegativeVertical = KeyCode.S; // Tecla negativa para eixo vertical

    [Header("Dimensões e Posicionamento")]
    public float horizontalBarWidth = 200f;
    public float horizontalBarHeight = 30f;
    public float verticalBarWidth = 30f;
    public float verticalBarHeight = 200f;
    public float horizontalSpacing = 20f;
    public float verticalSpacing = 20f;
    public float textBarSpacing = 10f;
    public Vector2 startHorizontalPosition = new Vector2(20f, 20f);
    public Vector2 startVerticalPosition = new Vector2(250f, 20f);

    [Header("Cores das Barras")]
    public Color horizontalColor = Color.red;
    public Color verticalColor = Color.blue;
    public Color backgroundColor = Color.gray;

    [Header("Texto")]
    public int fontSize = 20;
    public Color textColor = Color.white;

    private float horizontalValue; // Valor do eixo horizontal
    private float verticalValue;   // Valor do eixo vertical
    private GUIStyle textStyle;
    private Texture2D horizontalTexture;
    private Texture2D verticalTexture;
    private Texture2D backgroundTexture;

    void Start()
    {
        // Configura o estilo do texto
        textStyle = new GUIStyle
        {
            fontSize = fontSize,
            normal = { textColor = textColor }
        };

        // Inicializa texturas coloridas
        horizontalTexture = CreateColorTexture(horizontalColor);
        verticalTexture = CreateColorTexture(verticalColor);
        backgroundTexture = CreateColorTexture(backgroundColor);
    }

    void Update()
    {
        // Captura os valores com base no tipo de entrada selecionado
        switch (inputType)
        {
            case InputType.GetAxis:
                horizontalValue = Input.GetAxis(horizontalKey);
                verticalValue = Input.GetAxis(verticalKey);
                break;

            case InputType.GetAxisRaw:
                horizontalValue = Input.GetAxisRaw(horizontalKey);
                verticalValue = Input.GetAxisRaw(verticalKey);
                break;

            case InputType.GetKey:
                horizontalValue = (Input.GetKey(keyPositiveHorizontal) ? 1f : 0f) - (Input.GetKey(keyNegativeHorizontal) ? 1f : 0f);
                verticalValue = (Input.GetKey(keyPositiveVertical) ? 1f : 0f) - (Input.GetKey(keyNegativeVertical) ? 1f : 0f);
                break;

            case InputType.GetButton:
                horizontalValue = (Input.GetButton("Fire1") ? 1f : 0f); // Exemplo usando botões
                verticalValue = (Input.GetButton("Fire2") ? 1f : 0f); // Exemplo usando botões
                break;
        }
    }

    void OnGUI()
    {
        // Desenhar o feedback horizontal e vertical
        DrawHorizontalAxisFeedback("Horizontal", horizontalValue, 0, horizontalTexture, startHorizontalPosition, horizontalBarWidth, horizontalBarHeight, horizontalSpacing);
        DrawVerticalAxisFeedback("Vertical", verticalValue, 1, verticalTexture, startVerticalPosition, verticalBarWidth, verticalBarHeight, verticalSpacing);
    }

    private void DrawHorizontalAxisFeedback(string axisName, float value, int index, Texture2D colorTexture, Vector2 startPosition, float barWidth, float barHeight, float spacing)
    {
        float x = startPosition.x;
        float y = startPosition.y + (barHeight + spacing) * index;

        GUI.Label(new Rect(x, y + horizontalBarHeight, 300, barHeight), $"{axisName}: {value:F2}", textStyle);

        float barStartX = x;
        float barStartY = y;
        float normalizedValue = (value + 1) / 2;

        GUI.DrawTexture(new Rect(barStartX, barStartY, barWidth * normalizedValue, barHeight), colorTexture);
        GUI.DrawTexture(new Rect(barStartX + barWidth * normalizedValue, barStartY, barWidth * (1 - normalizedValue), barHeight), backgroundTexture);
    }

    private void DrawVerticalAxisFeedback(string axisName, float value, int index, Texture2D colorTexture, Vector2 startPosition, float barWidth, float barHeight, float spacing)
    {
        float x = startPosition.x + (barWidth + spacing) * index;
        float y = startPosition.y;

        GUI.Label(new Rect(x, y + barHeight + textBarSpacing, 300, barHeight), $"{axisName}: {value:F2}", textStyle);

        float barStartX = x;
        float barStartY = y + barHeight;
        float normalizedValue = (value + 1) / 2;

        GUI.DrawTexture(new Rect(barStartX, barStartY - barHeight * normalizedValue, barWidth, barHeight * normalizedValue), colorTexture);
        GUI.DrawTexture(new Rect(barStartX, barStartY - barHeight, barWidth, barHeight * (1 - normalizedValue)), backgroundTexture);
    }

    private Texture2D CreateColorTexture(Color color)
    {
        Texture2D texture = new Texture2D(1, 1);
        texture.SetPixel(0, 0, color);
        texture.Apply();
        return texture;
    }
}
