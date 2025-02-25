using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CodeReview : MonoBehaviour
{
    // Sistema de Inventário com Estrutura Modular e Documentação
    // Este sistema cobre tipos de variáveis, operadores, condicionais, loops, listas e boas práticas.
    // Desenvolvido para Unity usando C#.

    // ======== ESTRUTURAS FUNDAMENTAIS ========

    // TIPOS DE VARIÁVEIS
    // Variáveis armazenam informações necessárias para o jogo.
    int playerHealth = 100;          // Número inteiro
    float jumpHeight = 2.5f;         // Número com ponto flutuante
    string playerName = "Hero";      // Texto (string)
    bool isAlive = true;             // Valor lógico (verdadeiro ou falso)

    // TIPOS ESPECÍFICOS DO UNITY
    Vector3 position = new Vector3(0, 1, 0);          // Representa uma posição em 3D
    Quaternion rotation = Quaternion.identity;        // Representa uma rotação padrão
    GameObject enemy = GameObject.Find("Enemy");      // Referência a um objeto na cena

    // ======== OPERADORES MATEMÁTICOS E DE COMPARAÇÃO ========

    // OPERADORES MATEMÁTICOS
    int score = 50 + 20;             // Soma: 70
    int difference = 100 - 30;       // Subtração: 70
    float speed = 10.5f * 2;         // Multiplicação: 21
    float time = 100 / 5;            // Divisão: 20
    int remainder = 10 % 3;          // Módulo (resto da divisão): 1

    void ComparacaoConversao()
    {
        // OPERADORES DE COMPARAÇÃO
        bool isHighScore = score >= 100;          // Maior ou igual
        bool isFast = speed < 15;                 // Menor que
        bool hasSameHealth = playerHealth == 100; // Igualdade
        bool isDamaged = playerHealth != 100;     // Diferente


        // ======== CONVERSÃO DE TIPOS ========

        // Conversões explícitas de tipos
        string scoreMessage = "Pontuação: " + score.ToString();  // Converte int para string
        float ratio = (float)score / 200;                        // Converte int para float

    }

    void EstruturasControleRepeticao()
    {

        // ======== ESTRUTURAS DE CONTROLE ========

        // CONDICIONAIS
        if (playerHealth <= 0)
        {
            Debug.Log("Game Over!"); // Executa se a vida do jogador for 0 ou menos
        }
        else if (playerHealth < 50)
        {
            Debug.Log("Cuidado! Vida baixa."); // Executa se a vida for menor que 50
        }
        else
        {
            Debug.Log("Você está seguro!"); // Caso contrário
        }

        // Estrutura SWITCH para múltiplas condições
        string gameState = "Playing";
        switch (gameState)
        {
            case "Playing":
                Debug.Log("O jogo está em andamento.");
                break;
            case "Paused":
                Debug.Log("Jogo pausado.");
                break;
            default:
                Debug.Log("Estado desconhecido.");
                break;
        }

        // ======== ESTRUTURAS DE REPETIÇÃO ========

        // LOOP FOR
        for (int i = 0; i < 10; i++)
        {
            Debug.Log($"Spawnando inimigo {i}.");
        }

        // LOOP WHILE
        int ammo = 5;
        while (ammo > 0)
        {
            Debug.Log("Atirando...");
            ammo--; // Diminui a munição
        }

        // LOOP DO-WHILE
        ammo = 0;
        do
        {
            Debug.Log("Recarregando...");
            ammo++; // Adiciona uma bala
        } while (ammo < 5);

        // LOOP FOREACH
        List<string> inventory = new List<string> { "Espada", "Poção", "Escudo" };
        foreach (string item in inventory)
        {
            Debug.Log($"Item no inventário: {item}");
        }

        // ======== TRABALHANDO COM LISTAS ========

        // Criando e manipulando listas
        List<string> collectedItems = new List<string>();
        collectedItems.Add("Chave");  // Adiciona um item
        collectedItems.Add("Lanterna");
        collectedItems.Remove("Lanterna");  // Remove um item

        // Iteração em listas
        foreach (string item in collectedItems)
        {
            Debug.Log($"Item coletado: {item}");
        }

    }

}

