using GestãoRHZdoc.Modelos;

namespace GestãoRHZdoc.Data
{
    public static class GlobalData
    {
        public static Dictionary<string, Funcionario> FuncionariosRegistrados { get; set; } = new();
    }
} 