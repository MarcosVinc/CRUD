﻿using System;

namespace BacanasBurgues.Entidades
{
    public class Produto
    {
        public string Identificador { get; set; }
        public string Nome { get; set; }
        public string Tipo { get; set; }
        public int Quantidade { get; set; }
        public decimal Preco { get; set; }
        public int Lucro { get; set; }

        //Nome: Nome do produto
        //Tipo: Em qual tipo esse produto se enquadra
        // Quantidade: Quantidade de produdo a ser adicionada
        // Preco: O preço do produto em si, sem o o adicional.
        // Lucro : E quantos porcentos  do valor o cliente quer adicionar ao produto.

        public Produto(decimal preco, string nome, string tipo, int quantidade, int lucro)
        {
            Preco = preco;
            Nome = nome;
            Tipo = tipo;
            Lucro = lucro;
            Quantidade = quantidade;
        }

        public Produto() 
        {
            Identificador = Guid.NewGuid().ToString();
        }
    }
}
