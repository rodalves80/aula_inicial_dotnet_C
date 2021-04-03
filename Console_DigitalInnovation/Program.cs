using Console_DigitalInnovation.Code;
using System;


namespace Console_DigitalInnovation
{
    class Program
    {
        static void Main(string[] args)
        {
            Aluno[] alunos = new Aluno[5];
            var indiceAluno = 0;
            string opcaousuario = OpcaoObterUsuario();

            while (opcaousuario.ToUpper() != "X")
            {
                switch (opcaousuario)
                {

                    case "1":
                        Console.WriteLine("Informe o Nome do Aluno: ");
                        Aluno aluno = new Aluno();
                        aluno.Nome = Console.ReadLine();

                        Console.WriteLine("Informe a Nota do Aluno: ");                      
                        
                        if (decimal.TryParse(Console.ReadLine(), out decimal nota))
                        {
                            aluno.Nota = nota;
                        }
                        else
                        {
                            throw new ArgumentException("O Valor da Nota Deve Ser Decimal!");
                        }

                        alunos[indiceAluno] = aluno;
                        indiceAluno++;
                         break;

                    case "2":
                        foreach (var al in alunos)
                        {
                            if (!string.IsNullOrEmpty(al.Nome))
                            {
                                Console.WriteLine($"Aluno: {al.Nome} - Nota: {al.Nota}");
                            }    
                        }
                        break;

                    case "3":
                        decimal notaTotal = 0;
                        var nrAlunos = 0;

                        for (int i=0; i < alunos.Length; i++)
                        {
                            if (!string.IsNullOrEmpty(alunos[i].Nome))
                            {
                                notaTotal += alunos[i].Nota;
                                nrAlunos++;
                            }
                        }

                        var mediaGeral = notaTotal / nrAlunos;
                        Conceito conceitoGeral;

                        if(mediaGeral < 3)
                        {
                            conceitoGeral = Conceito.D;
                        } 
                        else if(mediaGeral < 5)
                        {
                            conceitoGeral = Conceito.C;
                        }
                        else if(mediaGeral < 8)
                        {
                            conceitoGeral = Conceito.B;
                        }
                        else 
                        {
                            conceitoGeral = Conceito.A;
                        }

                        Console.WriteLine($"Média Geral: {mediaGeral} - Conceito: {conceitoGeral}");
                        break;

                    default:
                        throw new ArgumentOutOfRangeException();

                }
            
                opcaousuario = OpcaoObterUsuario();

            }
        }

        private static string OpcaoObterUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("Informe a Opção Desejada");
            Console.WriteLine("1- Inserir Novo Aluno");
            Console.WriteLine("2- Listar Alunos");
            Console.WriteLine("3- Cacular Média Geral");
            Console.WriteLine("X- Sair");
            Console.WriteLine();

            string opcaousuario = Console.ReadLine();
            Console.WriteLine();
            return opcaousuario;

        }
    }
}