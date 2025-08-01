using GestãoRHZdoc.Data;
using GestãoRHZdoc.Menu;
using GestãoRHZdoc.Modelos;

try
{
    var context = new GestaoRHContext();
    var funcionarioDal = new FuncionarioDAL(context);

    //var novoFuncionario = new Funcionario(id: 10,
    //nome: "Lucas Pereira",
    //cargo: "Desenvolvedor",
    //dataAdmissao: DateTime.Now,
    //salario: 4500.00m);
    //funcionarioDal.Adicionar(novoFuncionario);
    //funcionarioDal.Atualizar(novoFuncionario);
    //funcionarioDal.Deletar(novoFuncionario);

    var listaFuncionarios = funcionarioDal.Listar();
    foreach(var funcionario in listaFuncionarios)
    {
        Console.WriteLine(funcionario);
    }
    

}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}
return;

Dictionary<string, Funcionario> funcionariosRegistradas = new();

Dictionary<int, Menu> opcoes = new();
opcoes.Add(1, new MenuMostrarFuncionarios());

opcoes.Add(-1, new MenuSair());
void ExibirMenuPrincipal()
{
    Console.Clear();
    Console.WriteLine("Bem-vindo ao Sistema de Gestão de Recursos Humanos!");
    Console.WriteLine("1. Cadastrar Funcionário");
    Console.WriteLine("2. Mostrar Funcionários");
    Console.WriteLine("-1. Sair");

    Console.Write("\nEscolha uma opção: ");
    string opcao = Console.ReadLine()!;
    int opcaoEscolhida = int.Parse(opcao);
    if (opcoes.ContainsKey(opcaoEscolhida))
    {
        Menu menuExibido = opcoes[opcaoEscolhida];
        menuExibido.Executar(funcionarioDAL);
        if (opcaoEscolhida > 0) ExibirMenuPrincipal();
    }
    else
    {
        Console.WriteLine("Opção inválida, tente novamente.");
    }
}

//ExibirMenuPrincipal();