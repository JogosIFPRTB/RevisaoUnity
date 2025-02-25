// ==========================================================
// Sistema de Métodos no Unity
// Este código demonstra a estrutura, tipos e exemplos de uso 
// de métodos com e sem parâmetros no Unity.
// ==========================================================

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Methods;

public class Methods : MonoBehaviour
{
    // ==========================================================
    // 1. MÉTODOS BÁSICOS
    // ==========================================================

    // Método sem parâmetros e sem retorno
    // Exibe uma mensagem no console.
    public void MostrarMensagem()
    {
        Debug.Log("Mensagem padrão exibida.");
    }

    // Método com parâmetros
    // Recebe dois números inteiros e retorna a soma deles.
    public int Soma(int a, int b)
    {
        return a + b; // Retorna a soma dos dois números
    }

    // Método com retorno booleano
    // Verifica se o jogador tem vida suficiente para uma ação.
    public bool TemVidaSuficiente(int vidaAtual, int vidaNecessaria)
    {
        return vidaAtual >= vidaNecessaria; // Retorna true ou false
    }

    // ==========================================================
    // 2. SOBRECARGA DE MÉTODOS
    // ==========================================================

    // Método sem parâmetros
    public void MostrarPontuacao()
    {
        Debug.Log("Pontuação padrão: 0.");
    }

    // Método sobrecarregado com parâmetros
    public void MostrarPontuacao(int pontuacao)
    {
        Debug.Log($"Pontuação: {pontuacao}");
    }

    // Método sobrecarregado com dois parâmetros
    public void MostrarPontuacao(int pontuacao, string prefixo)
    {
        Debug.Log($"{prefixo} {pontuacao}");
    }

    // ==========================================================
    // 3. PARÂMETROS OPCIONAIS
    // ==========================================================

    // Método com parâmetro opcional
    public void MostrarMensagemPersonalizada(string mensagem = "Mensagem padrão")
    {
        Debug.Log(mensagem);
    }

    // ==========================================================
    // 4. PARÂMETROS POR REFERÊNCIA
    // ==========================================================

    // Método com parâmetro por referência (ref)
    // Dobra o valor original passado como parâmetro.
    public void DobrarValor(ref int valor)
    {
        valor *= 2; // Modifica o valor original
    }

    // Método com parâmetro de saída (out)
    // Calcula a soma de dois números e retorna o resultado via out.
    public void CalcularSoma(int a, int b, out int resultado)
    {
        resultado = a + b; // Define o resultado
    }

    // ==========================================================
    // ====     MÉTODOS E CORROTINAS 
    // ==========================================================

    int playerHealth = 100;          // Número inteiro

    // MÉTODO PARA CURAR O JOGADOR
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
