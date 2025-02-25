// ==========================================================
// Demonstra��o dos M�todos Padr�o do Unity
// Este script cobre todos os m�todos padr�o mencionados, com explica��es detalhadas.
// Cada m�todo � integrado ao ciclo de vida do Unity e executado automaticamente.
// ==========================================================

using UnityEngine;

public class UnityLifecycleMethods : MonoBehaviour
{
    // ==========================================================
    // 1. M�TODOS DE INICIALIZA��O
    // ==========================================================

    // Chamado antes de qualquer outro m�todo, incluindo Start().
    // Usado para inicializar vari�veis ou configurar depend�ncias cr�ticas.
    void Awake()
    {
        Debug.Log("Awake: Inicializa��o do objeto.");
    }

    // Chamado ap�s Awake() e antes do primeiro quadro do jogo.
    // Usado para inicializa��es que dependem de outros objetos j� estarem configurados.
    void Start()
    {
        Debug.Log("Start: Configura��o inicial do objeto.");
    }

    // ==========================================================
    // 2. M�TODOS DE EXECU��O POR QUADRO
    // ==========================================================

    // Chamado uma vez por quadro.
    // Ideal para l�gica baseada no tempo, como movimenta��o ou entrada do jogador.
    void Update()
    {
        Debug.Log("Update: Executado a cada quadro.");
    }

    // Chamado ap�s todos os m�todos Update() no mesmo quadro.
    // Usado para ajustes que dependem de outros objetos j� terem atualizado suas transforma��es.
    void LateUpdate()
    {
        Debug.Log("LateUpdate: Ajustes finais do quadro.");
    }

    // ==========================================================
    // 3. M�TODOS DE EXECU��O COM F�SICA
    // ==========================================================

    // Chamado em intervalos fixos, independente da taxa de quadros.
    // Ideal para c�lculos de f�sica, como movimenta��o com Rigidbody.
    void FixedUpdate()
    {
        Debug.Log("FixedUpdate: Executado em intervalos fixos para f�sica.");
    }

    // ==========================================================
    // 4. M�TODOS DE EVENTOS E DESTRUI��O
    // ==========================================================

    // Chamado quando o GameObject � ativado.
    void OnEnable()
    {
        Debug.Log("OnEnable: Objeto ativado.");
    }

    // Chamado quando o GameObject � desativado.
    void OnDisable()
    {
        Debug.Log("OnDisable: Objeto desativado.");
    }

    // Chamado antes de o GameObject ser destru�do.
    // �til para liberar recursos ou desconectar eventos.
    void OnDestroy()
    {
        Debug.Log("OnDestroy: Objeto sendo destru�do.");
    }

    // ==========================================================
    // 5. M�TODOS DE EVENTOS DE COLIS�O
    // ==========================================================

    // Chamado ao colidir com outro objeto.
    void OnCollisionEnter(Collision collision)
    {
        Debug.Log($"OnCollisionEnter: Colis�o com {collision.gameObject.name}");
    }

    // Chamado enquanto dois objetos permanecem colidindo.
    void OnCollisionStay(Collision collision)
    {
        Debug.Log($"OnCollisionStay: Colis�o cont�nua com {collision.gameObject.name}");
    }

    // Chamado quando os objetos param de colidir.
    void OnCollisionExit(Collision collision)
    {
        Debug.Log($"OnCollisionExit: Colis�o encerrada com {collision.gameObject.name}");
    }

    // ==========================================================
    // 6. M�TODOS DE EVENTOS DE TRIGGER
    // ==========================================================

    // Chamado quando outro objeto entra no Trigger.
    void OnTriggerEnter(Collider other)
    {
        Debug.Log($"OnTriggerEnter: Objeto entrou no trigger: {other.gameObject.name}");
    }

    // Chamado enquanto o objeto permanece no Trigger.
    void OnTriggerStay(Collider other)
    {
        Debug.Log($"OnTriggerStay: Objeto no trigger: {other.gameObject.name}");
    }

    // Chamado quando o objeto sai do Trigger.
    void OnTriggerExit(Collider other)
    {
        Debug.Log($"OnTriggerExit: Objeto saiu do trigger: {other.gameObject.name}");
    }

    // ==========================================================
    // 7. M�TODOS DE RENDERIZA��O E VISIBILIDADE
    // ==========================================================

    // Chamado quando o objeto se torna vis�vel pela c�mera.
    void OnBecameVisible()
    {
        Debug.Log("OnBecameVisible: O objeto est� vis�vel.");
    }

    // Chamado quando o objeto n�o est� mais vis�vel pela c�mera.
    void OnBecameInvisible()
    {
        Debug.Log("OnBecameInvisible: O objeto n�o est� mais vis�vel.");
    }

    // ==========================================================
    // 8. OUTROS M�TODOS �TEIS
    // ==========================================================

    // Chamado quando o jogo � encerrado.
    // �til para salvar dados ou liberar recursos.
    void OnApplicationQuit()
    {
        Debug.Log("OnApplicationQuit: O jogo est� sendo encerrado.");
    }

    // Chamado sempre que valores no Inspetor s�o alterados.
    // Usado para valida��o de entradas ou ajustes autom�ticos.
    void OnValidate()
    {
        Debug.Log("OnValidate: Valores no Inspetor foram alterados.");
    }
}
