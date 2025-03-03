using UnityEngine;

#if UNITY_EDITOR
using UnityEditor; // Necessário para personalizar o Inspector
#endif

public class PlayerController : MonoBehaviour
{
    public enum MovementType
    {
        Simple,        // Movimentação básica (WASD ou setas)
        DiagonalOnly,  // Apenas diagonais
        Circular       // Movimento em círculo com controle
    }

    [Header("Configurações Gerais")]
    public MovementType movementType = MovementType.Simple; // Tipo de movimentação
    public float speed = 5f; // Velocidade de movimento
    public float circularRadius = 3f; // Raio do movimento circular
    public bool isAutoMoveEnabled = false; // Define se o movimento é automático ou baseado no input

    [Header("Movimento Simple")]
    public Vector3 autoMoveDirection = Vector3.forward; // Direção de movimento automático
    public bool normalizeDiagonalMovement = true; // Define se a velocidade deve ser normalizada em movimentos diagonais

    [Header("Reset de Posição")]
    public Vector3 resetPosition = Vector3.zero; // Posição para o reset
    public bool useCustomResetPosition = false; // Define se usa uma posição customizada para reset

    private float circularAngle = 0f; // Ângulo para o movimento circular
    private Vector3 initialPosition; // Armazena a posição inicial

    void Start()
    {
        // Salvar a posição inicial do objeto
        initialPosition = transform.position;
    }

    void Update()
    {
        switch (movementType)
        {
            case MovementType.Simple:
                SimpleMovement();
                break;
            case MovementType.DiagonalOnly:
                DiagonalMovement();
                break;
            case MovementType.Circular:
                CircularMovement();
                break;
        }
    }

    // Função para resetar a posição
    public void ResetPosition()
    {
        if (useCustomResetPosition)
        {
            transform.position = resetPosition;
        }
        else
        {
            transform.position = initialPosition;
        }
    }

    // Movimentação básica com WASD ou setas ou automática
    void SimpleMovement()
    {
        Vector3 movement;

        if (isAutoMoveEnabled)
        {
            // Movimento automático com base na variável autoMoveDirection
            movement = autoMoveDirection.normalized;
        }
        else
        {
            // Movimento baseado no input do jogador
            float moveHorizontal = Input.GetAxis("Horizontal");
            float moveVertical = Input.GetAxis("Vertical");

            movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

            // Normalizar o movimento se ativado e o jogador estiver movendo diagonalmente
            if (normalizeDiagonalMovement && movement.magnitude > 1f)
            {
                movement = movement.normalized;
            }
        }

        Move(movement);
    }

    // Movimentação restrita às diagonais ou automática
    void DiagonalMovement()
    {
        Vector3 movement;

        if (isAutoMoveEnabled)
        {
            movement = new Vector3(1f, 0.0f, 1f).normalized; // Movimento automático
        }
        else
        {
            float moveHorizontal = Input.GetAxis("Horizontal");
            float moveVertical = Input.GetAxis("Vertical");

            if (Mathf.Abs(moveHorizontal) > 0.1f && Mathf.Abs(moveVertical) > 0.1f)
            {
                movement = new Vector3(moveHorizontal, 0.0f, moveVertical).normalized;
            }
            else
            {
                return;
            }
        }

        Move(movement);
    }

    // Movimentação em círculo com controle por input ou automática
    void CircularMovement()
    {
        if (isAutoMoveEnabled)
        {
            // Movimento automático em círculo
            circularAngle += speed * Time.deltaTime;
        }
        else
        {
            // Controle por input do jogador
            float inputHorizontal = Input.GetAxis("Horizontal");
            circularAngle += inputHorizontal * speed * Time.deltaTime;
        }

        float x = Mathf.Cos(circularAngle) * circularRadius;
        float z = Mathf.Sin(circularAngle) * circularRadius;
        transform.position = new Vector3(x, transform.position.y, z);
    }

    // Função para aplicar o movimento ao objeto
    void Move(Vector3 direction)
    {
        transform.Translate(direction * speed * Time.deltaTime, Space.World);
    }
}

#if UNITY_EDITOR
[CustomEditor(typeof(PlayerController))]
public class PlayerControllerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector(); // Desenha os elementos padrão do Inspector

        PlayerController controller = (PlayerController)target;

        if (GUILayout.Button("Resetar Posição"))
        {
            controller.ResetPosition();
        }
    }
}
#endif
