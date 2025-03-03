using UnityEngine;

#if UNITY_EDITOR
using UnityEditor; // Necess�rio para personalizar o Inspector
#endif

public class PlayerController : MonoBehaviour
{
    public enum MovementType
    {
        Simple,        // Movimenta��o b�sica (WASD ou setas)
        DiagonalOnly,  // Apenas diagonais
        Circular       // Movimento em c�rculo com controle
    }

    [Header("Configura��es Gerais")]
    public MovementType movementType = MovementType.Simple; // Tipo de movimenta��o
    public float speed = 5f; // Velocidade de movimento
    public float circularRadius = 3f; // Raio do movimento circular
    public bool isAutoMoveEnabled = false; // Define se o movimento � autom�tico ou baseado no input

    [Header("Movimento Simple")]
    public Vector3 autoMoveDirection = Vector3.forward; // Dire��o de movimento autom�tico
    public bool normalizeDiagonalMovement = true; // Define se a velocidade deve ser normalizada em movimentos diagonais

    [Header("Reset de Posi��o")]
    public Vector3 resetPosition = Vector3.zero; // Posi��o para o reset
    public bool useCustomResetPosition = false; // Define se usa uma posi��o customizada para reset

    private float circularAngle = 0f; // �ngulo para o movimento circular
    private Vector3 initialPosition; // Armazena a posi��o inicial

    void Start()
    {
        // Salvar a posi��o inicial do objeto
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

    // Fun��o para resetar a posi��o
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

    // Movimenta��o b�sica com WASD ou setas ou autom�tica
    void SimpleMovement()
    {
        Vector3 movement;

        if (isAutoMoveEnabled)
        {
            // Movimento autom�tico com base na vari�vel autoMoveDirection
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

    // Movimenta��o restrita �s diagonais ou autom�tica
    void DiagonalMovement()
    {
        Vector3 movement;

        if (isAutoMoveEnabled)
        {
            movement = new Vector3(1f, 0.0f, 1f).normalized; // Movimento autom�tico
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

    // Movimenta��o em c�rculo com controle por input ou autom�tica
    void CircularMovement()
    {
        if (isAutoMoveEnabled)
        {
            // Movimento autom�tico em c�rculo
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

    // Fun��o para aplicar o movimento ao objeto
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
        DrawDefaultInspector(); // Desenha os elementos padr�o do Inspector

        PlayerController controller = (PlayerController)target;

        if (GUILayout.Button("Resetar Posi��o"))
        {
            controller.ResetPosition();
        }
    }
}
#endif
