// ==========================================================
// Demonstração dos Métodos Padrão do Unity
// Este script cobre todos os métodos padrão mencionados, com explicações detalhadas.
// Cada método é integrado ao ciclo de vida do Unity e executado automaticamente.
// ==========================================================

using UnityEngine;

public class UnityLifecycleMethods : MonoBehaviour
{
    // ==========================================================
    // 1. MÉTODOS DE INICIALIZAÇÃO
    // ==========================================================

    // Chamado antes de qualquer outro método, incluindo Start().
    // Usado para inicializar variáveis ou configurar dependências críticas.
    void Awake()
    {
        Debug.Log("Awake: Inicialização do objeto.");
    }

    // Chamado após Awake() e antes do primeiro quadro do jogo.
    // Usado para inicializações que dependem de outros objetos já estarem configurados.
    void Start()
    {
        Debug.Log("Start: Configuração inicial do objeto.");
    }

    // ==========================================================
    // 2. MÉTODOS DE EXECUÇÃO POR QUADRO
    // ==========================================================

    // Chamado uma vez por quadro.
    // Ideal para lógica baseada no tempo, como movimentação ou entrada do jogador.
    void Update()
    {
        Debug.Log("Update: Executado a cada quadro.");
    }

    // Chamado após todos os métodos Update() no mesmo quadro.
    // Usado para ajustes que dependem de outros objetos já terem atualizado suas transformações.
    void LateUpdate()
    {
        Debug.Log("LateUpdate: Ajustes finais do quadro.");
    }

    // ==========================================================
    // 3. MÉTODOS DE EXECUÇÃO COM FÍSICA
    // ==========================================================

    // Chamado em intervalos fixos, independente da taxa de quadros.
    // Ideal para cálculos de física, como movimentação com Rigidbody.
    void FixedUpdate()
    {
        Debug.Log("FixedUpdate: Executado em intervalos fixos para física.");
    }

    // ==========================================================
    // 4. MÉTODOS DE EVENTOS E DESTRUIÇÃO
    // ==========================================================

    // Chamado quando o GameObject é ativado.
    void OnEnable()
    {
        Debug.Log("OnEnable: Objeto ativado.");
    }

    // Chamado quando o GameObject é desativado.
    void OnDisable()
    {
        Debug.Log("OnDisable: Objeto desativado.");
    }

    // Chamado antes de o GameObject ser destruído.
    // Útil para liberar recursos ou desconectar eventos.
    void OnDestroy()
    {
        Debug.Log("OnDestroy: Objeto sendo destruído.");
    }

    // ==========================================================
    // 5. MÉTODOS DE EVENTOS DE COLISÃO
    // ==========================================================

    // Chamado ao colidir com outro objeto.
    void OnCollisionEnter(Collision collision)
    {
        Debug.Log($"OnCollisionEnter: Colisão com {collision.gameObject.name}");
    }

    // Chamado enquanto dois objetos permanecem colidindo.
    void OnCollisionStay(Collision collision)
    {
        Debug.Log($"OnCollisionStay: Colisão contínua com {collision.gameObject.name}");
    }

    // Chamado quando os objetos param de colidir.
    void OnCollisionExit(Collision collision)
    {
        Debug.Log($"OnCollisionExit: Colisão encerrada com {collision.gameObject.name}");
    }

    // ==========================================================
    // 6. MÉTODOS DE EVENTOS DE TRIGGER
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
    // 7. MÉTODOS DE RENDERIZAÇÃO E VISIBILIDADE
    // ==========================================================

    // Chamado quando o objeto se torna visível pela câmera.
    void OnBecameVisible()
    {
        Debug.Log("OnBecameVisible: O objeto está visível.");
    }

    // Chamado quando o objeto não está mais visível pela câmera.
    void OnBecameInvisible()
    {
        Debug.Log("OnBecameInvisible: O objeto não está mais visível.");
    }

    // ==========================================================
    // 8. OUTROS MÉTODOS ÚTEIS
    // ==========================================================

    // Chamado quando o jogo é encerrado.
    // Útil para salvar dados ou liberar recursos.
    void OnApplicationQuit()
    {
        Debug.Log("OnApplicationQuit: O jogo está sendo encerrado.");
    }

    // Chamado sempre que valores no Inspetor são alterados.
    // Usado para validação de entradas ou ajustes automáticos.
    void OnValidate()
    {
        Debug.Log("OnValidate: Valores no Inspetor foram alterados.");
    }
}
