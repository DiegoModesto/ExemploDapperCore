using ConsoleApp2.Commands;
using ConsoleApp2.Entity;
using System;
using System.Collections.Generic;

namespace ConsoleApp2
{
    class Program
    {


        static void Main(string[] args)
        {
            CommandEstado cmdEstado = new CommandEstado();
            CommandCidade cmdCidade = new CommandCidade();

            //Este comando irá preencher previamente alguns dados
            //Remova-o caso já tenha executado e não queria replicar.
            //SeedBase();

            var rioDeJaneiro = cmdEstado.BuscarPorId(Guid.Parse("088F12D4-861F-4A90-AA4C-DDEA3442848C"));
            rioDeJaneiro.Name = "Linda Cidade - Rio de Janeiro";

            cmdEstado.AtualizarEstado(rioDeJaneiro);

            Console.WriteLine("Acabou a execução!");
        }

        public static void SeedBase()
        {
            var cmdEstado = new CommandEstado();
            var cmdCidade = new CommandCidade();

            //Adicionar Estados
            var listaDeEstados = new List<EstadoEntity>()
                {
                    new EstadoEntity(){
                        Id = Guid.Parse("4C392E7D-92BF-4277-9670-0A500240AF78"),
                        Name = "São Paulo",
                        Short = "SP"
                    },
                    new EstadoEntity(){
                        Id = Guid.Parse("088F12D4-861F-4A90-AA4C-DDEA3442848C"),
                        Name = "Rio de Janeiro",
                        Short = "RJ"
                    },
                    new EstadoEntity(){
                        Id = Guid.Parse("21062173-0028-4A5A-B19D-5F02AF9FFBCC"),
                        Name = "Espirito Santo",
                        Short = "ES"
                    },
                    new EstadoEntity(){
                        Id = Guid.Parse("D8ACB0F1-122C-43E3-840E-E6F9309B215F"),
                        Name = "Tocantins",
                        Short = "TO"
                    },
                    new EstadoEntity(){
                        Id = Guid.Parse("F6BB8AC2-3C80-4B24-A3A9-FD6C1D63A4CD"),
                        Name = "Mato Grosso",
                        Short = "MT"
                    },
                    new EstadoEntity(){
                        Id = Guid.Parse("1D5CF6C2-ED97-48EF-AB65-6CCBAD0D27B2"),
                        Name = "Mato Grosso do Sul",
                        Short = "MS"
                    },
                    new EstadoEntity(){
                        Id = Guid.Parse("70EC3B4C-3AF0-4A50-9579-AF1804AD2EBD"),
                        Name = "Rio Grande do Sul",
                        Short = "RG"
                    }
                };
            cmdEstado.InserirEstados(listaDeEstados);

            var listaDeCidades = new List<CidadeEntity>()
                {
                    new CidadeEntity(){
                        Id = Guid.Parse("F0D7594B-A6A3-4AAB-B7FA-E38A453AB682"),
                        Name = "São Paulo",
                        EstadoId = Guid.Parse("4C392E7D-92BF-4277-9670-0A500240AF78")
                    },
                    new CidadeEntity(){
                        Id = Guid.Parse("3F9FB8DC-A5E2-4157-ACF9-AACB34ACD3B4"),
                        Name = "Carapicuíba",
                        EstadoId = Guid.Parse("4C392E7D-92BF-4277-9670-0A500240AF78")
                    },
                    new CidadeEntity(){
                        Id = Guid.Parse("DA64938F-1696-4215-8C0C-4513436DC52B"),
                        Name = "Itapevi",
                        EstadoId = Guid.Parse("4C392E7D-92BF-4277-9670-0A500240AF78")
                    },
                    new CidadeEntity(){
                        Id = Guid.Parse("CFC4A8CD-9E12-49E4-9A64-42928EA2C47F"),
                        Name = "Rio de Janeiro",
                        EstadoId = Guid.Parse("088F12D4-861F-4A90-AA4C-DDEA3442848C")
                    },
                    new CidadeEntity(){
                        Id = Guid.Parse("80BF52C3-B0E3-43CC-A63F-025E163CE9A5"),
                        Name = "Niterói",
                        EstadoId = Guid.Parse("088F12D4-861F-4A90-AA4C-DDEA3442848C")
                    },
                    new CidadeEntity(){
                        Id = Guid.Parse("9E2E3882-6CC4-4109-8496-5C5E4C2F1D6D"),
                        Name = "Petrópolis",
                        EstadoId = Guid.Parse("088F12D4-861F-4A90-AA4C-DDEA3442848C")
                    },
                    new CidadeEntity(){
                        Id = Guid.Parse("67BC6AE3-A2C6-4EAD-9A14-46AAC6E5F48A"),
                        Name = "Caxias do Sul",
                        EstadoId = Guid.Parse("70EC3B4C-3AF0-4A50-9579-AF1804AD2EBD")
                    },
                    new CidadeEntity(){
                        Id = Guid.Parse("E74D51AE-BCD9-484A-A04F-8CD2E62E6C0B"),
                        Name = "Pelotas",
                        EstadoId = Guid.Parse("70EC3B4C-3AF0-4A50-9579-AF1804AD2EBD")
                    }
                };
            cmdCidade.InserirCidades(listaDeCidades);
        }
    }
}
