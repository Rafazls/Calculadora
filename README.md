# Calculadora
Case para Engenharia de Software JR

Você precisa corrigir os seguintes problemas no codigo:
  1. Aplicação só está processando o primeiro item da fila infinitamente.
  2. Implemente a funcionalidade de divisão.
  3. Aplicação não está calculando a penultima operação corretamente.
     
     	Saída esperada no console:
     
     		14 - 8 = 6
     
     		5 * 6 = 30
     
     		2147483647 + 2 = 2147483649
     
     		18 / 3 = 6

  5. Implemente uma funcionalidade para imprimir toda a lista de operaçõoes a ser processada após cada calculo realizado.
  6. Crie uma nova pilha (Stack) para guardar o resultado de cada calculo efetuado e imprima a pilha ao final


Não existe resposta certa ou errada, o objetivo do case é avaliar a linha de raciocínio de cada candidato.
Você é livre para fazer na linguagem de sua preferência, desde que aplique as mesmas funcionalidades e tarefas deste case.
Dica: Utilize Visual Code ou Visual Studio Community para realizar as tarefas.

---
## Problemas Corrigidos

### 1. Aplicação só está processando o primeiro item da fila infinitamente.
**Solução:** Foi alterada para a função `Dequeue()` de modo que após a execução o item é removido da fila.

```csharp
Operacao operacao = filaOperacoes.Dequeue();
```

### 2. Implemente a funcionalidade de divisão.
**Solução:** Implementada a funcionalidade de divisão.

```csharp
        case '/': operacao.resultado = divisao(operacao); break; // Adicionado a operação de divisão

        public decimal divisao(Operacoes operacao)
        {
            if (operacao.valorB == 0)
            {
                throw new DivideByZeroException("Não é possível dividir por zero");
            }
            return (decimal)operacao.valorA / operacao.valorB;
        }
```

### 3. Aplicação não está calculando a penultima operação corretamente.
**Solução:** Corrigido o erro de cálculo da penúltima operação. Alterar o tipo de dado para `long` ao invés de `int`.

```csharp
public long valorA { get; set; }
public long valorB { get; set; }
```

### 4. Implemente uma funcionalidade para imprimir toda a lista de operaçõoes a ser processada após cada calculo realizado.
**Solução:** Implementada a funcionalidade de imprimir a lista de operações a ser processada após cada cálculo usando `foreach`.

```csharp
                if (filaOperacoes.Count > 0)
                {
                    Console.WriteLine("Operações restantes na fila:");
                    foreach (var op in filaOperacoes)
                    {
                        Console.WriteLine("   {0} {1} {2}", op.valorA, op.operador, op.valorB);
                    }
                    Console.WriteLine();
                    Console.WriteLine("===============================");
                    Console.WriteLine();

                }
```

### 5. Crie uma nova pilha (Stack) para guardar o resultado de cada calculo efetuado e imprima a pilha ao final
**Solução:** Implementada a funcionalidade de guardar o resultado de cada cálculo efetuado e imprimir a pilha ao final, usando a classe `Stack<decimal>`. A implementação foi feita em Calculadora.cs, seguindo o princípio da Responsabilidade Única (SRP) do SOLID, já que o histórico de cálculos é parte da responsabilidade da calculadora.
Além disso, a solução favorece a reusabilidade, permitindo que o histórico seja aproveitado em outros contextos.

```csharp
// Adicionado no Calculadora.cs
        private Stack<Operacoes> historicoOperacoes;
        public Calculadora()
        {
            historicoOperacoes = new Stack<Operacoes>();
        }

        private void AdicionarAoHistorico(Operacoes operacao)
        {
            historicoOperacoes.Push(operacao);
        }
        public IEnumerable<Operacoes> Historico()
        {
            return historicoOperacoes;
        }
// Program.cs
            Console.WriteLine("Histórico de operações:");
            foreach (var op in calculadora.Historico())
            {
                Console.WriteLine("   {0} {1} {2} = {3}", op.valorA, op.operador, op.valorB, op.resultado);
            }  
```
