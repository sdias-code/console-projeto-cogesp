using AppRelacionamento.Models;
using AppRelacionamento.Controller;
using System;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace AppRelacionamento
{
    class Program
    {
        static async Task Main(string[] args)
        {

            await MenuOpcoesAsync();
        }

        private static async Task MenuOpcoesAsync()
        {
            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("=================================");
                Console.WriteLine("Escolha uma opção: \n1 - Usuario \n2 - Conta \n3 - Transacao \n4 - para sair!");
                Console.WriteLine("=================================");
                Console.WriteLine();

                string resposta = Console.ReadLine();
                if (resposta == "4")
                {
                    break;
                }
                // Opcoes de Cliente
                if (resposta == "1")
                {
                    Console.WriteLine("Escolha uma opção: \n1 - Cadastrar Usuarios, \n2 - Listar Usuarios, \n3 - Atualizar Usuarios, \n4 - Deletar Usuarios \n5 - Listar Clientes (API)");
                    string escolha = Console.ReadLine();
                    Console.WriteLine();

                    if (escolha == "1")
                    {
                        Console.WriteLine("Cadastrando Usuário");
                        CadastrarClientes();
                    }

                    if (escolha == "2")
                    {
                        Console.WriteLine("Listando Usuário");
                        ListarClientes();
                    }

                    if (escolha == "3")
                    {
                        Console.WriteLine("Atualiando Usuário");
                        AtualizarCliente();
                    }

                    if (escolha == "4")
                    {
                        Console.WriteLine("Deletando Usuário");
                        ExcluirCliente();
                    }

                    if (escolha == "5")
                    {
                        Console.WriteLine("listar clientes (API)");
                        await BuscarClientesApiAsync();                        

                    }
                }

                // Opcoes de Conta
                if (resposta == "2")
                {
                    Console.WriteLine("Escolha uma opção: \n1 - Listar Contas \n2 - Cadastrar conta \n3 - Atualizar conta \n4 - Deletar conta \n5 - Listar contas (API)");
                    string escolha = Console.ReadLine();

                    if (escolha == "1")
                    {
                        Console.WriteLine("Listando contas!");
                        ListarContas();
                    }

                    if (escolha == "2")
                    {
                        Console.WriteLine("Cadastrando conta!");
                        CadastrarConta();
                    }

                    if (escolha == "3")
                    {
                        Console.WriteLine("Atualizar conta!");
                        AtualizarConta();
                    }

                    if (escolha == "4")
                    {
                        Console.WriteLine("Deletar conta!");
                        DeletarConta();
                    }

                    if (escolha == "5")
                    {
                        Console.WriteLine("Listar contas (API)!");
                        await BuscarContasApiAsync();
                    }

                   
                }

                // Opcoes de Transações
                if (resposta == "3")
                {
                    Console.WriteLine("Escolha uma opção: \n1 - Depóstio \n2 - Retirada \n3 - Verificar maior depósito \n4 - Maior Deposito (API)");
                    string escolha = Console.ReadLine();

                    if (escolha == "1")
                    {
                        Console.WriteLine("Realizar Depósito");
                        Depositar();
                    }

                    if (escolha == "2")
                    {
                        Console.WriteLine("Realizar Retirada)");
                        Retirar();
                    }                    

                    if (escolha == "3")
                    {
                        Console.WriteLine("Verificar maior depósito)");
                        MaiorDeposito();
                    }

                    if (escolha == "4")
                    {
                        Console.WriteLine("Verificar maior depósito (Consumindo Api)");
                        await BuscarMaiorDepositoApiAsync();                        
                    }
                }
                                
            }
        }

        
        private static void CadastrarClientes()
        {           
            ClienteController clientecontroller = new ClienteController();
            clientecontroller.CadastrarClientes();            
        }

        private static void ListarClientes()
        {
            ClienteController clientecontroller = new ClienteController();
            clientecontroller.ListarClientes();
        }

        private static void AtualizarCliente()
        {            
            ClienteController clientecontroller = new ClienteController();            
            clientecontroller.AtualizarCliente();            
        }

        private static void ExcluirCliente()
        {           
            ClienteController clientecontroller = new ClienteController();
            clientecontroller.ExcluirCliente();
        }

        private static void CadastrarConta()
        {            
            ContaController contaController = new ContaController();
            contaController.CadastrarConta();
        }

        private static void ListarContas()
        {
            ContaController contaController = new ContaController();
            contaController.ListarContas();
        }

        private static void AtualizarConta()
        {
            ContaController contaController = new ContaController();
            contaController.AtualizarConta();
        }

        private static void DeletarConta()
        {
            ContaController contaController = new ContaController();
            contaController.ExcluirConta();            
        }

        private static void Depositar()
        {
            TransacaoController transacaoController = new TransacaoController();
            transacaoController.Depositar();
        }

        private static void Retirar()
        {
            TransacaoController transacaoController = new TransacaoController();
            transacaoController.Retirar();
        }

        private static void MaiorDeposito()
        {
            TransacaoController transacaoController = new TransacaoController();
            transacaoController.MaiorDeposito();
        }

        //fazer  chamadas http - consumindo api
        static async Task BuscarClientesApiAsync()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new System.Uri("https://localhost:44388");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = await client.GetAsync("api/clientes");
                if (response.IsSuccessStatusCode)
                {  //GET
                    string cliente = await response.Content.ReadAsStringAsync();

                    var clientesJson = JsonConvert.DeserializeObject<List<Cliente>>(cliente);

                    foreach (Cliente item in clientesJson)
                    {
                        Console.WriteLine("Id: {0} Nome: {1} Sobrenome: {2} CPF: {3}",
                            item.Id, item.Nome, item.Sobrenome, item.Cpf);
                    }           
                               
                    
                }
                
            }
        }

        static async Task BuscarContasApiAsync()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new System.Uri("https://localhost:44388");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = await client.GetAsync("api/contas");
                if (response.IsSuccessStatusCode)
                {  //GET
                    string contas = await response.Content.ReadAsStringAsync();
                    var contasJson = JsonConvert.DeserializeObject<List<ContaModel>>(contas);

                    foreach (ContaModel item in contasJson)
                    {
                        Console.WriteLine("Id: {0} Client: {1} Agencia: {2} Número: {3} Saldo: {4}", 
                            item.Id, item.ClienteId, item.Agencia, item.Numero, item.Saldo);
                    }                    
                    

                }

            }
        }

        static async Task BuscarMaiorDepositoApiAsync()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new System.Uri("https://localhost:44388");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = await client.GetAsync("api/transacoes/maior");

                if (response.IsSuccessStatusCode)

                {  //GET
                    string maiorDeposito = await response.Content.ReadAsStringAsync();
                    Console.WriteLine("O maior valor depositado foi de: " + maiorDeposito);                    
                }

            }
        }



    }

    
}
