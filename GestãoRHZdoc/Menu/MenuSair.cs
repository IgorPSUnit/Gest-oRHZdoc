using GestãoRHZdoc.Data;
using GestãoRHZdoc.Menu;
using GestãoRHZdoc.Modelos;

internal class MenuSair : Menu
{
    public override void Executar(FuncionarioDAL funcionarioDAL)
    {
        ExibirTituloDaOpcao("Saindo do RHZDOC");
        Thread.Sleep(2000);
        Environment.Exit(0);
    }
}