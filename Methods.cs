// ==========================================================
// Sistema de M�todos no Unity
// Este c�digo demonstra a estrutura, tipos e exemplos de uso 
// de m�todos com e sem par�metros no Unity.
// ==========================================================

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Methods;

public class Methods : MonoBehaviour
{
    // ==========================================================
    // 1. M�TODOS B�SICOS
    // ==========================================================

    // M�todo sem par�metros e sem retorno
    // Exibe uma mensagem no console.
    public void MostrarMensagem()
    {
        Debug.Log("Mensagem padr�o exibida.");
    }

    // M�todo com par�metros
    // Recebe dois n�meros inteiros e retorna a soma deles.
    public int Soma(int a, int b)
    {
        return a + b; // Retorna a soma dos dois n�meros
    }

    // M�todo com retorno booleano
    // Verifica se o jogador tem vida suficiente para uma a��o.
    public bool TemVidaSuficiente(int vidaAtual, int vidaNecessaria)
    {
        return vidaAtual >= vidaNecessaria; // Retorna true ou false
    }

    // ==========================================================
    // 2. SOBRECARGA DE M�TODOS
    // ==========================================================

    // M�todo sem par�metros
    public void MostrarPontuacao()
    {
        Debug.Log("Pontua��o padr�o: 0.");
    }

    // M�todo sobrecarregado com par�metros
    public void MostrarPontuacao(int pontuacao)
    {
        Debug.Log($"Pontua��o: {pontuacao}");
    }

    // M�todo sobrecarregado com dois par�metros
    public void MostrarPontuacao(int pontuacao, string prefixo)
    {
        Debug.Log($"{prefixo} {pontuacao}");
    }

    // ==========================================================
    // 3. PAR�METROS OPCIONAIS
    // ==========================================================

    // M�todo com par�metro opcional
    public void MostrarMensagemPersonalizada(string mensagem = "Mensagem padr�o")
    {
        Debug.Log(mensagem);
    }

    // ==========================================================
    // 4. PAR�METROS POR REFER�NCIA
    // ==========================================================

    // M�todo com par�metro por refer�ncia (ref)
    // Dobra o valor original passado como par�metro.
    public void DobrarValor(ref int valor)
    {
        valor *= 2; // Modifica o valor original
    }

    // M�todo com par�metro de sa�da (out)
    // Calcula a soma de dois n�meros e retorna o resultado via out.
    public void CalcularSoma(int a, int b, out int resultado)
    {
        resultado = a + b; // Define o resultado
    }

    // ==========================================================
    // ====     M�TODOS E CORROTINAS 
    // ==========================================================

    int playerHealth = 100;          // N�mero inteiro

    // M�TODO PARA CURAR O JOGADOR
    void HealPlayer(int amount)
    {
        playerHealth += amount;
        Debug.Log($"Vida restaurada: {amount} pontos.");
    }

    // CORROTINA PARA AGUARDAR O TEMPO DE RESPAWN
    IEnumerator RespawnPlayer()
    {
        Debug.Log("Respawn iniciando...");
        yield return new WaitForSeconds(3); // Aguarda 3 segundos
        Debug.Log("Jogador respawnado!");
    }

    // ======== DELEGADOS E EVENTOS ========

    // DELEGADO PARA EVENTOS DE MORTE DO JOGADOR
    public delegate void PlayerDeath();
    public static event PlayerDeath OnPlayerDeath;

    // Monitorando a vida do jogador
    void Update()
    {
        if (playerHealth <= 0 && OnPlayerDeath != null)
        {
            OnPlayerDeath(); // Dispara o evento de morte
        }
    }
}
