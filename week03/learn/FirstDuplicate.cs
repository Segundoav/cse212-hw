using System;
using System.Collections.Generic; // ¡IMPORTANTE! Esto permite usar el HashSet

public static class FirstDuplicate
{
    public static void Run() 
    {
        // Escenario de prueba: "abcddef"
        string texto = "abcddef";
        HashSet<char> vistos = new HashSet<char>();
        
        foreach (char letra in texto) 
        {
            // Comportamiento: El HashSet busca la letra en O(1)
            if (vistos.Contains(letra)) 
            {
                Console.WriteLine($"Primer duplicado: {letra}");
                return; // Se detiene al encontrar el primero
            }
            vistos.Add(letra); // Propósito: Guardar la letra para comparar después
        }
        
        Console.WriteLine("No hay duplicados.");
    }
}