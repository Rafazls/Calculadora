using System;
using System.Collections.Generic;
namespace Calculadora
{
    public class Calculadora
    {
        private Stack<Operacoes> historicoOperacoes;
        public Calculadora()
        {
            historicoOperacoes = new Stack<Operacoes>();
        }
        public Operacoes calcular(Operacoes operacao)
        {
            switch (operacao.operador)
            {
                case '+': operacao.resultado = soma(operacao); break;
                case '-': operacao.resultado = subtracao(operacao); break;
                case '*': operacao.resultado = multiplicacao(operacao); break;
                case '/': operacao.resultado = divisao(operacao); break; // Adicionado a operação de divisão
                default: operacao.resultado = 0; break;
            }
            AdicionarAoHistorico(operacao);
            return operacao;
        }
        public long soma(Operacoes operacao)
        {
            return operacao.valorA + operacao.valorB;
        }
        public long subtracao(Operacoes operacao)
        {
            return operacao.valorA - operacao.valorB;
        }
        public long multiplicacao(Operacoes operacao)
        {
            return operacao.valorA * operacao.valorB;
        }
        public decimal divisao(Operacoes operacao)
        {
            if (operacao.valorB == 0)
            {
                throw new DivideByZeroException("Não é possível dividir por zero");
            }
            return (decimal)operacao.valorA / operacao.valorB;
        }
        private void AdicionarAoHistorico(Operacoes operacao)
        {
            historicoOperacoes.Push(operacao);
        }
        public IEnumerable<Operacoes> Historico()
        {
            return historicoOperacoes;
        }

    }
}
