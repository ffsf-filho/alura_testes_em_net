﻿namespace JornadaMilhas.Test.Exercicio
{
    public class Musica
    {
        public Musica(string nome)
        {
            Nome = nome;
        }

        public string Nome { get; set; }
        public int Id { get; set; }

        public string? artista;
        public string? Artista 
        { 
            get => artista;
            set 
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    artista = "Artista desconhecido";
                }
                else
                {
                    artista = value;
                }
            }
        }

        private int? anoLancamento;
        public int? AnoLancamento
        {
            get => anoLancamento;
            set
            {
                if (value <= 0)
                {
                    anoLancamento = null;
                }
                else
                {
                    anoLancamento = value;
                }
            }
        }

        public void ExibirFichaTecnica()
        {
            Console.WriteLine($"Nome: {Nome}");

        }

        public override string ToString()
        {
            return @$"Id: {Id} Nome: {Nome}";
        }
    }
}
