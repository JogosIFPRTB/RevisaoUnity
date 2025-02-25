using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CodeReview : MonoBehaviour
{
    // Sistema de Invent�rio com Estrutura Modular e Documenta��o
    // Este sistema cobre tipos de vari�veis, operadores, condicionais, loops, listas e boas pr�ticas.
    // Desenvolvido para Unity usando C#.

    // ======== ESTRUTURAS FUNDAMENTAIS ========

    // TIPOS DE VARI�VEIS
    // Vari�veis armazenam informa��es necess�rias para o jogo.
    int playerHealth = 100;          // N�mero inteiro
    float jumpHeight = 2.5f;         // N�mero com ponto flutuante
    string playerName = "Hero";      // Texto (string)
    bool isAlive = true;             // Valor l�gico (verdadeiro ou falso)

    // TIPOS ESPEC�FICOS DO UNITY
    Vector3 position = new Vector3(0, 1, 0);          // Representa uma posi��o em 3D
    Quaternion rotation = Quaternion.identity;        // Representa uma rota��o padr�o
    GameObject enemy = GameObject.Find("Enemy");      // Refer�ncia a um objeto na cena

    // ======== OPERADORES MATEM�TICOS E DE COMPARA��O ========

    // OPERADORES MATEM�TICOS
    int score = 50 + 20;             // Soma: 70
    int difference = 100 - 30;       // Subtra��o: 70
    float speed = 10.5f * 2;         // Multiplica��o: 21
    float time = 100 / 5;            // Divis�o: 20
    int remainder = 10 % 3;          // M�dulo (resto da divis�o): 1

    void ComparacaoConversao()
    {
        // OPERADORES DE COMPARA��O
        bool isHighScore = score >= 100;          // Maior ou igual
        bool isFast = speed < 15;                 // Menor que
        bool hasSameHealth = playerHealth == 100; // Igualdade
        bool isDamaged = playerHealth != 100;     // Diferente


        // ======== CONVERS�O DE TIPOS ========

        // Convers�es expl�citas de tipos
        string scoreMessage = "Pontua��o: " + score.ToString();  // Converte int para string
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
            Debug.Log("Voc� est� seguro!"); // Caso contr�rio
        }

        // Estrutura SWITCH para m�ltiplas condi��es
        string gameState = "Playing";
        switch (gameState)
        {
            case "Playing":
                Debug.Log("O jogo est� em andamento.");
                break;
            case "Paused":
                Debug.Log("Jogo pausado.");
                break;
            default:
                Debug.Log("Estado desconhecido.");
                break;
        }

        // ======== ESTRUTURAS DE REPETI��O ========

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
            ammo--; // Diminui a muni��o
        }

        // LOOP DO-WHILE
        ammo = 0;
        do
        {
            Debug.Log("Recarregando...");
            ammo++; // Adiciona uma bala
        } while (ammo < 5);

        // LOOP FOREACH
        List<string> inventory = new List<string> { "Espada", "Po��o", "Escudo" };
        foreach (string item in inventory)
        {
            Debug.Log($"Item no invent�rio: {item}");
        }

        // ======== TRABALHANDO COM LISTAS ========

        // Criando e manipulando listas
        List<string> collectedItems = new List<string>();
        collectedItems.Add("Chave");  // Adiciona um item
        collectedItems.Add("Lanterna");
        collectedItems.Remove("Lanterna");  // Remove um item

        // Itera��o em listas
        foreach (string item in collectedItems)
        {
            Debug.Log($"Item coletado: {item}");
        }

    }

}

