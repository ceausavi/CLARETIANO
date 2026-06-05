// Program.cs — Ponto de entrada da aplicação WinForms
namespace Passo1;

internal static class Program
{
    [STAThread]
    static void Main()
    {
        ApplicationConfiguration.Initialize();
        Application.Run(new FormPrincipal());
    }
}
